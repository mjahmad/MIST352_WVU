using System;
using System.Net;
using System.Text.Json;

namespace Project_1
{
    /// <summary>
    /// Pulls live weather data from TWO NOAA sources:
    ///   1. api.weather.gov  – real 7-day / hourly forecast (no key needed)
    ///   2. NOAA GHCN S3     – historical station records
    /// </summary>
    internal class NOAAService
    {
        private string _location;
        private double _latitude;
        private double _longitude;
        private bool   _coordsReady;

        // Cache so we don't geocode twice
        private WeatherDay[]  _forecastCache;
        private WeatherDay[]  _hourlyCache;

        public NOAAService(string location)
        {
            _location   = location;
            _coordsReady = false;
        }

        // ── public API ────────────────────────────────────────────────────

        /// <summary>Returns up to 7 evening forecast periods from api.weather.gov.</summary>
        public WeatherDay[] Get7DayForecast()
        {
            if (_forecastCache != null) return _forecastCache;

            EnsureCoords();
            _forecastCache = FetchNWS7Day(_latitude, _longitude);
            return _forecastCache;
        }

        /// <summary>Returns tonight's hourly periods (6 PM – midnight) from api.weather.gov.</summary>
        public WeatherDay[] GetEveningHourly()
        {
            if (_hourlyCache != null) return _hourlyCache;

            EnsureCoords();
            _hourlyCache = FetchNWSHourly(_latitude, _longitude);
            return _hourlyCache;
        }

        /// <summary>Returns the single best WeatherDay for tonight.</summary>
        public WeatherDay GetTonight()
        {
            WeatherDay[] forecast = Get7DayForecast();
            if (forecast == null || forecast.Length == 0) return MakePlaceholder();

            // Prefer the period named "Tonight" or "This Evening"
            foreach (WeatherDay d in forecast)
            {
                if (d._name != null &&
                    (d._name.ToLower().Contains("tonight") ||
                     d._name.ToLower().Contains("evening")))
                    return d;
            }
            return forecast[0];
        }

        /// <summary>Pulls historical max-temp + precip from NOAA GHCN for comparison.</summary>
        public double[] GetHistoricalAverages()
        {
            EnsureCoords();
            string[] stations = GetNearestStationIds(_latitude, _longitude);
            if (stations == null || stations.Length == 0 || string.IsNullOrEmpty(stations[0]))
                return new double[] { 65, 2.5 }; // fallback

            double temp = GetMaxTemperature(stations[0], DateTime.Now.Year - 1);
            double rain = GetPrecipitation(stations[0], DateTime.Now.Year - 1);

            if (temp == -999) temp = 65;
            if (rain == -999) rain = 2.5;

            return new double[] { (temp * 9.0 / 5.0) + 32, rain };
        }

        // ── NWS api.weather.gov helpers ───────────────────────────────────

        private WeatherDay[] FetchNWS7Day(double lat, double lon)
        {
            try
            {
                // Step 1: get office + gridX + gridY
                string pointsUrl  = $"https://api.weather.gov/points/{lat:F4},{lon:F4}";
                string pointsJson = HttpGet(pointsUrl);
                if (string.IsNullOrEmpty(pointsJson)) return FallbackForecast();

                string forecastUrl = ExtractString(pointsJson, "\"forecast\":", ",");
                forecastUrl = forecastUrl.Trim().Trim('"');
                if (string.IsNullOrEmpty(forecastUrl)) return FallbackForecast();

                // Step 2: get forecast periods
                string forecastJson = HttpGet(forecastUrl);
                if (string.IsNullOrEmpty(forecastJson)) return FallbackForecast();

                return ParseNWSPeriods(forecastJson, nightOnly: true);
            }
            catch
            {
                return FallbackForecast();
            }
        }

        private WeatherDay[] FetchNWSHourly(double lat, double lon)
        {
            try
            {
                string pointsUrl  = $"https://api.weather.gov/points/{lat:F4},{lon:F4}";
                string pointsJson = HttpGet(pointsUrl);
                if (string.IsNullOrEmpty(pointsJson)) return new WeatherDay[0];

                string hourlyUrl = ExtractString(pointsJson, "\"forecastHourly\":", ",");
                hourlyUrl = hourlyUrl.Trim().Trim('"');
                if (string.IsNullOrEmpty(hourlyUrl)) return new WeatherDay[0];

                string hourlyJson = HttpGet(hourlyUrl);
                if (string.IsNullOrEmpty(hourlyJson)) return new WeatherDay[0];

                return ParseNWSHourlyPeriods(hourlyJson);
            }
            catch
            {
                return new WeatherDay[0];
            }
        }

        // Parses NWS forecast JSON into WeatherDay array (evening periods only if nightOnly=true)
        private WeatherDay[] ParseNWSPeriods(string json, bool nightOnly)
        {
            WeatherDay[] result = new WeatherDay[7];
            int count = 0;

            try
            {
                JsonDocument doc  = JsonDocument.Parse(json);
                JsonElement  root = doc.RootElement;
                JsonElement  periods = root.GetProperty("properties").GetProperty("periods");

                foreach (JsonElement p in periods.EnumerateArray())
                {
                    if (count >= 7) break;

                    string name = GetStr(p, "name");

                    // Skip daytime periods if nightOnly is true
                    if (nightOnly)
                    {
                        bool isDay = GetBool(p, "isDaytime");
                        if (isDay) continue;
                    }

                    WeatherDay day = new WeatherDay();
                    day._name          = name;
                    day._temperature   = GetDouble(p, "temperature");
                    day._shortforecast = GetStr(p, "shortForecast");
                    day._detailedforecast = GetStr(p, "detailedForecast");
                    day._date          = DateTime.Today.AddDays(count).ToString("MM/dd/yyyy");
                    day._sunsettime    = "8:00 PM"; // NWS doesn't give sunset; we set a default

                    // Wind: "5 mph" or "5 to 10 mph"
                    string windSpeed = GetStr(p, "windSpeed");
                    day._windspeed    = ParseWindSpeed(windSpeed);
                    day._winddirection = GetStr(p, "windDirection");

                    // Probability of precipitation (nested object in newer NWS JSON)
                    day._rainchance   = GetNestedDouble(p, "probabilityOfPrecipitation", "value");
                    day._humidity     = GetNestedDouble(p, "relativeHumidity", "value");

                    // Estimate rainfall from precip probability (rough heuristic)
                    day._rainfall     = day._rainchance > 50 ? 1.0 : 0.0;

                    result[count] = day;
                    count++;
                }
            }
            catch { }

            // Trim to actual count
            WeatherDay[] trimmed = new WeatherDay[count];
            for (int i = 0; i < count; i++) trimmed[i] = result[i];
            return trimmed;
        }

        // Parses hourly periods, filtering to 6 PM – midnight tonight
        private WeatherDay[] ParseNWSHourlyPeriods(string json)
        {
            WeatherDay[] result = new WeatherDay[8];
            int count = 0;

            try
            {
                JsonDocument doc     = JsonDocument.Parse(json);
                JsonElement  periods = doc.RootElement
                                         .GetProperty("properties")
                                         .GetProperty("periods");

                DateTime today = DateTime.Today;

                foreach (JsonElement p in periods.EnumerateArray())
                {
                    if (count >= 8) break;

                    string startStr = GetStr(p, "startTime");
                    if (string.IsNullOrEmpty(startStr)) continue;

                    if (!DateTime.TryParse(startStr, out DateTime startTime)) continue;

                    // Only tonight 6 PM through 11 PM
                    if (startTime.Date != today) continue;
                    if (startTime.Hour < 18 || startTime.Hour > 23) continue;

                    WeatherDay d = new WeatherDay();
                    d._name          = startTime.ToString("h tt"); // e.g. "7 PM"
                    d._temperature   = GetDouble(p, "temperature");
                    d._windspeed     = ParseWindSpeed(GetStr(p, "windSpeed"));
                    d._winddirection = GetStr(p, "windDirection");
                    d._shortforecast = GetStr(p, "shortForecast");
                    d._rainchance    = GetNestedDouble(p, "probabilityOfPrecipitation", "value");
                    d._humidity      = GetNestedDouble(p, "relativeHumidity", "value");
                    d._date          = today.ToString("MM/dd/yyyy");

                    result[count] = d;
                    count++;
                }
            }
            catch { }

            WeatherDay[] trimmed = new WeatherDay[count];
            for (int i = 0; i < count; i++) trimmed[i] = result[i];
            return trimmed;
        }

        // ── JSON helpers ──────────────────────────────────────────────────

        private string GetStr(JsonElement el, string key)
        {
            try { return el.GetProperty(key).GetString() ?? ""; } catch { return ""; }
        }

        private double GetDouble(JsonElement el, string key)
        {
            try
            {
                JsonElement v = el.GetProperty(key);
                if (v.ValueKind == JsonValueKind.Number) return v.GetDouble();
                if (v.ValueKind == JsonValueKind.String &&
                    double.TryParse(v.GetString(), out double r)) return r;
            }
            catch { }
            return 0;
        }

        private bool GetBool(JsonElement el, string key)
        {
            try { return el.GetProperty(key).GetBoolean(); } catch { return false; }
        }

        private double GetNestedDouble(JsonElement el, string outerKey, string innerKey)
        {
            try
            {
                JsonElement outer = el.GetProperty(outerKey);
                JsonElement inner = outer.GetProperty(innerKey);
                if (inner.ValueKind == JsonValueKind.Number) return inner.GetDouble();
                if (inner.ValueKind == JsonValueKind.Null)   return 0;
            }
            catch { }
            return 0;
        }

        private double ParseWindSpeed(string windStr)
        {
            if (string.IsNullOrEmpty(windStr)) return 0;
            // "5 mph"  or  "5 to 10 mph"  – take first number
            string[] parts = windStr.Split(' ');
            foreach (string p in parts)
            {
                if (double.TryParse(p, out double v)) return v;
            }
            return 0;
        }

        // Rough substring extractor for simple JSON values (avoids full parse for URLs)
        private string ExtractString(string json, string key, string endChar)
        {
            int start = json.IndexOf(key);
            if (start < 0) return "";
            start += key.Length;
            // skip whitespace / colon
            while (start < json.Length && (json[start] == ' ' || json[start] == ':')) start++;
            int end = json.IndexOf(endChar, start);
            if (end < 0) end = Math.Min(start + 200, json.Length);
            return json.Substring(start, end - start).Trim();
        }

        // ── HTTP helper ───────────────────────────────────────────────────

        private string HttpGet(string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("User-Agent", "BonfirePlannerApp/2.0 student-project");
                client.Headers.Add("Accept",     "application/geo+json, application/json");
                return client.DownloadString(url);
            }
            catch
            {
                return "";
            }
        }

        // ── Geocoding ─────────────────────────────────────────────────────

        private void EnsureCoords()
        {
            if (_coordsReady) return;

            string json = HttpGet(
                "https://nominatim.openstreetmap.org/search?q=" +
                Uri.EscapeDataString(_location) + "&format=json&limit=1");

            _latitude  = 0;
            _longitude = 0;

            try
            {
                JsonDocument doc = JsonDocument.Parse(json);
                if (doc.RootElement.GetArrayLength() > 0)
                {
                    JsonElement first = doc.RootElement[0];
                    _latitude  = double.Parse(first.GetProperty("lat").GetString());
                    _longitude = double.Parse(first.GetProperty("lon").GetString());
                }
            }
            catch { }

            // Fallback: Morgantown, WV
            if (_latitude == 0 && _longitude == 0)
            {
                _latitude  = 39.6295;
                _longitude = -79.9559;
            }

            _coordsReady = true;
        }

        // ── GHCN historical helpers (unchanged from original) ─────────────

        private string[] GetNearestStationIds(double userLat, double userLon)
        {
            string[] ids       = new string[10];
            double[] distances = new double[10];
            for (int i = 0; i < 10; i++) { distances[i] = 999999; ids[i] = ""; }

            try
            {
                WebClient client = new WebClient();
                string data = client.DownloadString(
                    "https://noaa-ghcn-pds.s3.amazonaws.com/ghcnd-stations.txt");
                string[] lines = data.Split('\n');

                foreach (string line in lines)
                {
                    if (line.Length < 72) continue;
                    try
                    {
                        string id  = line.Substring(0, 11).Trim();
                        double lat = double.Parse(line.Substring(12, 8).Trim());
                        double lon = double.Parse(line.Substring(21, 9).Trim());
                        double d   = Haversine(userLat, userLon, lat, lon);
                        InsertStation(ids, distances, id, d);
                    }
                    catch { }
                }
            }
            catch { }

            return ids;
        }

        private static double Haversine(double la1, double lo1, double la2, double lo2)
        {
            double r    = 3958.8;
            double dLat = (la2 - la1) * Math.PI / 180.0;
            double dLon = (lo2 - lo1) * Math.PI / 180.0;
            double a    = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                        + Math.Cos(la1 * Math.PI / 180.0)
                        * Math.Cos(la2 * Math.PI / 180.0)
                        * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            return r * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }

        private static void InsertStation(string[] arr, double[] dist, string val, double d)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (d < dist[i])
                {
                    for (int j = arr.Length - 1; j > i; j--)
                    { dist[j] = dist[j - 1]; arr[j] = arr[j - 1]; }
                    dist[i] = d; arr[i] = val; break;
                }
            }
        }

        private static string[] ReadStationFile(string stationId)
        {
            try
            {
                WebClient c = new WebClient();
                string data = c.DownloadString(
                    "https://noaa-ghcn-pds.s3.amazonaws.com/csv/by_station/" + stationId + ".csv");
                return data.Split('\n');
            }
            catch { return new string[0]; }
        }

        private static double GetMaxTemperature(string stationId, int year)
        {
            double temp = -999;
            foreach (string line in ReadStationFile(stationId))
            {
                string[] p = line.Split(',');
                if (p.Length >= 4 && p[2] == "TMAX" &&
                    p[1].Length >= 4 && int.Parse(p[1].Substring(0, 4)) == year)
                {
                    if (double.TryParse(p[3], out double v)) temp = v / 10.0;
                }
            }
            return temp;
        }

        private static double GetPrecipitation(string stationId, int year)
        {
            double val = -999;
            foreach (string line in ReadStationFile(stationId))
            {
                string[] p = line.Split(',');
                if (p.Length >= 4 && p[2] == "PRCP" &&
                    p[1].Length >= 4 && int.Parse(p[1].Substring(0, 4)) == year)
                {
                    if (double.TryParse(p[3], out double v)) val = v / 10.0;
                }
            }
            return val;
        }

        // ── Fallback data ─────────────────────────────────────────────────

        private WeatherDay[] FallbackForecast()
        {
            // Realistic placeholder for Morgantown, WV late April
            WeatherDay[] days = new WeatherDay[5];

            string[] names = { "Tonight", "Tuesday Night", "Wednesday Night",
                                "Thursday Night", "Friday Night" };
            double[] temps = { 58, 62, 54, 70, 65 };
            double[] winds = { 6,  11, 5,  8,  4  };
            double[] rain  = { 10, 40, 5,  20, 5  };
            double[] humid = { 55, 70, 45, 60, 50 };
            string[] fore  = { "Mostly Clear", "Chance Showers", "Clear",
                                "Partly Cloudy", "Clear" };
            string[] dirs  = { "W", "SW", "NW", "S", "W" };

            for (int i = 0; i < 5; i++)
            {
                WeatherDay d = new WeatherDay();
                d._name          = names[i];
                d._temperature   = temps[i];
                d._windspeed     = winds[i];
                d._winddirection = dirs[i];
                d._rainchance    = rain[i];
                d._humidity      = humid[i];
                d._shortforecast = fore[i];
                d._rainfall      = rain[i] > 50 ? 1.0 : 0.0;
                d._date          = DateTime.Today.AddDays(i).ToString("MM/dd/yyyy");
                d._sunsettime    = "8:12 PM";
                days[i] = d;
            }
            return days;
        }

        private WeatherDay MakePlaceholder()
        {
            WeatherDay d = new WeatherDay();
            d._name        = "Tonight";
            d._temperature = 60;
            d._windspeed   = 7;
            d._humidity    = 55;
            d._rainchance  = 10;
            d._shortforecast = "Mostly Clear";
            return d;
        }
    }
}

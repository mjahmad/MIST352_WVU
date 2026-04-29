using System.Net.Http;
using System.Text.Json;

namespace Project_2
{
    internal class NOAAService
    {
        private static readonly HttpClient _http = new();
        private readonly string _location;
        private double _cachedLat;
        private double _cachedLon;
        private bool _coordsCached;

        public NOAAService(string location)
        {
            _location = location;
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("GardenBonfirePlanner/2.0 (MIST352-Educational)");
            _http.Timeout = TimeSpan.FromSeconds(60);
        }

        // ── Coordinates ──────────────────────────────────────────────

        public (double lat, double lon) GetCoordinates()
        {
            if (_coordsCached) return (_cachedLat, _cachedLon);
            string json = CallGeocodeAPI(_location);
            _cachedLat = ExtractDouble(json, "lat");
            _cachedLon = ExtractDouble(json, "lon");
            _coordsCached = true;
            return (_cachedLat, _cachedLon);
        }

        // ── 7-Day Forecast (api.weather.gov) ─────────────────────────

        public WeatherDay[] Get7DayForecast()
        {
            var (lat, lon) = GetCoordinates();
            if (lat == 0 && lon == 0) return GetFallbackForecast();

            try
            {
                string pointsUrl = $"https://api.weather.gov/points/{lat:F4},{lon:F4}";
                string pointsJson = _http.GetStringAsync(pointsUrl).GetAwaiter().GetResult();
                JsonDocument pointsDoc = JsonDocument.Parse(pointsJson);
                string forecastUrl = pointsDoc.RootElement
                    .GetProperty("properties").GetProperty("forecast").GetString() ?? "";

                if (string.IsNullOrEmpty(forecastUrl)) return GetFallbackForecast();

                string forecastJson = _http.GetStringAsync(forecastUrl).GetAwaiter().GetResult();
                WeatherDay[] parsed = ParseForecastPeriods(forecastJson);
                return parsed.Length > 0 ? parsed : GetFallbackForecast();
            }
            catch
            {
                return GetFallbackForecast();
            }
        }

        private static WeatherDay[] ParseForecastPeriods(string json)
        {
            var days = new List<WeatherDay>();
            JsonDocument doc = JsonDocument.Parse(json);
            var periods = doc.RootElement.GetProperty("properties").GetProperty("periods");

            WeatherDay? current = null;

            foreach (JsonElement p in periods.EnumerateArray())
            {
                bool isDaytime = p.GetProperty("isDaytime").GetBoolean();
                int temp = p.GetProperty("temperature").GetInt32();
                string windSpeedStr = p.GetProperty("windSpeed").GetString() ?? "0 mph";
                string windDir = p.GetProperty("windDirection").GetString() ?? "N";
                string shortFx = p.GetProperty("shortForecast").GetString() ?? "";
                string detFx = p.GetProperty("detailedForecast").GetString() ?? "";
                string startTime = p.GetProperty("startTime").GetString() ?? "";

                int precip = GetNestedInt(p, "probabilityOfPrecipitation");
                int humidity = GetNestedInt(p, "relativeHumidity");
                if (humidity == 0) humidity = 50;

                double windSpeed = 0;
                string[] wParts = windSpeedStr.Split(' ');
                // handle range like "10 to 15 mph"
                if (wParts.Length >= 3 && wParts[1] == "to")
                    double.TryParse(wParts[2], out windSpeed);
                else
                    double.TryParse(wParts[0], out windSpeed);

                DateTime dt = DateTime.TryParse(startTime, out DateTime parsed) ? parsed : DateTime.Now.AddDays(days.Count);

                if (isDaytime)
                {
                    current = new WeatherDay
                    {
                        Date = dt.ToString("MM/dd/yyyy"),
                        DayName = dt.DayOfWeek.ToString(),
                        HighTemp = temp,
                        LowTemp = temp - 18,
                        WindSpeed = windSpeed,
                        WindDirection = windDir,
                        PrecipChance = precip,
                        Humidity = humidity,
                        Description = shortFx,
                        DetailedForecast = detFx,
                        SunriseTime = "06:30",
                        SunsetTime = "20:00"
                    };
                }
                else if (current != null)
                {
                    current.LowTemp = temp;
                    if (precip > current.PrecipChance) current.PrecipChance = precip;
                    days.Add(current);
                    current = null;
                    if (days.Count >= 7) break;
                }
            }

            if (current != null && days.Count < 7) days.Add(current);
            return [.. days];
        }

        private static int GetNestedInt(JsonElement el, string prop)
        {
            if (el.TryGetProperty(prop, out JsonElement outer)
                && outer.TryGetProperty("value", out JsonElement val)
                && val.ValueKind == JsonValueKind.Number)
                return val.GetInt32();
            return 0;
        }

        // ── Historical Data (NOAA GHCN via AWS S3) ───────────────────

        public HistoricalStats[] GetHistoricalMonthlyStats(int year)
        {
            var (lat, lon) = GetCoordinates();
            string[] stationIds = GetNearestStationIds(lat, lon);
            string stationId = stationIds.FirstOrDefault(s => !string.IsNullOrEmpty(s)) ?? "";

            HistoricalStats[] stats = new HistoricalStats[12];
            for (int i = 0; i < 12; i++) stats[i] = new HistoricalStats { Month = i + 1 };

            if (string.IsNullOrEmpty(stationId)) return stats;

            string[] lines = ReadStationFile(stationId);
            var frostByDate = new Dictionary<string, double>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 4) continue;
                if (parts[1].Length < 8) continue;
                if (!int.TryParse(parts[1][..4], out int yr) || yr != year) continue;
                if (!int.TryParse(parts[1][4..6], out int mo) || mo < 1 || mo > 12) continue;
                if (!double.TryParse(parts[3], out double rawVal)) continue;

                double val = rawVal / 10.0;
                var s = stats[mo - 1];
                string element = parts[2];

                switch (element)
                {
                    case "TMAX":
                        double tMaxF = (val * 9.0 / 5.0) + 32;
                        s.SumHighTemp += tMaxF;
                        s.CountHighTemp++;
                        break;
                    case "TMIN":
                        double tMinF = (val * 9.0 / 5.0) + 32;
                        s.SumLowTemp += tMinF;
                        s.CountLowTemp++;
                        if (tMinF < s.MinTemp) s.MinTemp = tMinF;
                        if (tMinF <= 32) s.FrostDays++;
                        frostByDate[parts[1]] = tMinF;
                        break;
                    case "PRCP":
                        s.TotalPrecip += val * 0.0393701;
                        if (val > 0) s.PrecipDays++;
                        break;
                    case "SNOW":
                        s.TotalSnow += val * 0.0393701;
                        if (val > 0) s.SnowDays++;
                        break;
                }
            }

            ComputeFrostDates(stats, frostByDate, year);

            bool hasData = stats.Any(s => s.CountHighTemp > 0);
            return hasData ? stats : GetFallbackHistoricalStats(year);
        }

        private static void ComputeFrostDates(HistoricalStats[] stats, Dictionary<string, double> frostDates, int year)
        {
            // Last spring frost: latest frost date before July
            // First fall frost: earliest frost date after Aug
            DateTime? lastSpring = null;
            DateTime? firstFall = null;

            foreach (var kv in frostDates.OrderBy(k => k.Key))
            {
                if (!DateTime.TryParseExact(kv.Key, "yyyyMMdd", null,
                    System.Globalization.DateTimeStyles.None, out DateTime dt)) continue;

                if (kv.Value <= 32)
                {
                    if (dt.Month <= 6 && (lastSpring == null || dt > lastSpring)) lastSpring = dt;
                    if (dt.Month >= 8 && (firstFall == null || dt < firstFall)) firstFall = dt;
                }
            }

            if (lastSpring != null) stats[lastSpring.Value.Month - 1].LastSpringFrost = lastSpring;
            if (firstFall != null) stats[firstFall.Value.Month - 1].FirstFallFrost = firstFall;
        }

        // ── Station Lookup ────────────────────────────────────────────

        public string[] GetNearestStationIds(double userLat, double userLon)
        {
            string[] ids = new string[10];
            double[] distances = new double[10];
            for (int i = 0; i < 10; i++) { ids[i] = ""; distances[i] = double.MaxValue; }

            try
            {
                string url = "https://noaa-ghcn-pds.s3.amazonaws.com/ghcnd-stations.txt";
                string data = _http.GetStringAsync(url).GetAwaiter().GetResult();

                foreach (string line in data.Split('\n'))
                {
                    if (line.Length < 31) continue;
                    try
                    {
                        string id = line[..11].Trim();
                        double lat = double.Parse(line[12..20].Trim());
                        double lon = double.Parse(line[21..30].Trim());
                        double dist = CalculateDistance(userLat, userLon, lat, lon);
                        InsertStation(ids, distances, id, dist);
                    }
                    catch { }
                }
            }
            catch { }

            return ids;
        }

        private static void InsertStation(string[] ids, double[] distances, string id, double dist)
        {
            for (int i = 0; i < 10; i++)
            {
                if (dist < distances[i])
                {
                    for (int j = 9; j > i; j--)
                    {
                        distances[j] = distances[j - 1];
                        ids[j] = ids[j - 1];
                    }
                    distances[i] = dist;
                    ids[i] = id;
                    break;
                }
            }
        }

        private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 3958.8;
            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                     + Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180)
                     * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            return R * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }

        private string[] ReadStationFile(string stationId)
        {
            string url = $"https://noaa-ghcn-pds.s3.amazonaws.com/csv/by_station/{stationId}.csv";
            try
            {
                string data = _http.GetStringAsync(url).GetAwaiter().GetResult();
                return data.Split('\n');
            }
            catch { return []; }
        }

        // ── Geocoding (Nominatim) ─────────────────────────────────────

        private string CallGeocodeAPI(string location)
        {
            string encoded = Uri.EscapeDataString(location);
            string url = $"https://nominatim.openstreetmap.org/search?q={encoded}&format=json&limit=1";
            try { return _http.GetStringAsync(url).GetAwaiter().GetResult(); }
            catch { return ""; }
        }

        private static double ExtractDouble(string json, string key)
        {
            try
            {
                JsonDocument doc = JsonDocument.Parse(json);
                if (doc.RootElement.GetArrayLength() > 0)
                    return double.Parse(doc.RootElement[0].GetProperty(key).GetString() ?? "0");
            }
            catch { }
            return 0;
        }

        // ── Fallback Historical Stats ─────────────────────────────────

        public static HistoricalStats[] GetFallbackHistoricalStats(int year = 0)
        {
            int refYear = year > 0 ? year : DateTime.Now.Year - 1;
            // Approximate Morgantown, WV monthly normals
            var data = new (int mo, double hi, double lo, double precip, int frost)[]
            {
                (1,  38.2, 21.8, 3.2, 22), (2,  41.8, 24.6, 2.9, 18),
                (3,  52.3, 32.5, 4.1,  8), (4,  63.7, 42.1, 3.7,  1),
                (5,  72.9, 51.4, 4.3,  0), (6,  81.0, 60.2, 4.2,  0),
                (7,  84.6, 64.5, 4.8,  0), (8,  83.4, 63.0, 3.9,  0),
                (9,  76.8, 55.1, 3.4,  0), (10, 64.9, 43.3, 3.1,  1),
                (11, 53.2, 34.7, 3.6,  7), (12, 40.7, 25.4, 3.3, 18),
            };

            var stats = new HistoricalStats[12];
            for (int i = 0; i < 12; i++)
            {
                var (mo, hi, lo, precip, frost) = data[i];
                stats[i] = new HistoricalStats
                {
                    Month = mo,
                    SumHighTemp = hi * 28, CountHighTemp = 28,
                    SumLowTemp  = lo * 28, CountLowTemp  = 28,
                    MinTemp = lo - 8,
                    TotalPrecip = precip,
                    PrecipDays  = (int)(precip * 4),
                    FrostDays   = frost,
                };
            }
            stats[3].LastSpringFrost = new DateTime(refYear, 4, 20);
            stats[9].FirstFallFrost  = new DateTime(refYear, 10, 15);
            return stats;
        }

        // ── Fallback Data ─────────────────────────────────────────────

        private static WeatherDay[] GetFallbackForecast()
        {
            var now = DateTime.Now;
            var data = new (double hi, double lo, double wind, string dir, int precip, string desc)[]
            {
                (68, 52, 8,  "SW", 10, "Mostly Sunny"),
                (72, 55, 5,  "S",  20, "Partly Cloudy"),
                (58, 48, 12, "NW", 60, "Showers Likely"),
                (63, 50, 7,  "W",  30, "Mostly Cloudy"),
                (70, 54, 6,  "S",  15, "Sunny"),
                (74, 57, 4,  "SW", 10, "Sunny and Warm"),
                (65, 51, 9,  "NE", 25, "Partly Cloudy"),
            };

            return data.Select((d, i) =>
            {
                DateTime dt = now.AddDays(i);
                return new WeatherDay
                {
                    Date = dt.ToString("MM/dd/yyyy"),
                    DayName = dt.DayOfWeek.ToString(),
                    HighTemp = d.hi, LowTemp = d.lo,
                    WindSpeed = d.wind, WindDirection = d.dir,
                    PrecipChance = d.precip, Humidity = 55,
                    Description = d.desc, Rainfall = 0,
                    SunriseTime = "06:30", SunsetTime = "20:00"
                };
            }).ToArray();
        }
    }
}

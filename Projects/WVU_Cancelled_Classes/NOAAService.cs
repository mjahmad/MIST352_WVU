using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace Project_1
{
    /// <summary>
    /// Fetches weather data from two sources:
    ///   1. NOAA GHCN-Daily S3 bucket  → full-year historical data (13 elements)
    ///   2. Open-Meteo (no key needed)  → live current-conditions snapshot
    /// </summary>
    internal class NOAAService
    {
        public string _location;

        // Morgantown WV coordinates and primary GHCN station
        private const double LAT             = 39.6295;
        private const double LON             = -79.9559;
        private const string PRIMARY_STATION = "USC00555882"; // MORGANTOWN LOCK 4

        public NOAAService(string location)
        {
            _location = location;
        }

        // ── Historical data (full year from NOAA GHCN) ─────────────────────────

        public WeatherDay[] GetHistoricalData(int year = 2025)
        {
            Console.WriteLine($"  Downloading NOAA GHCN data for station {PRIMARY_STATION} ({year})...");

            string[] csvLines = DownloadStationCSV(PRIMARY_STATION);

            if (csvLines.Length < 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  Could not reach NOAA. Using built-in sample data.");
                Console.ResetColor();
                return FallbackData();
            }

            Dictionary<string, WeatherDay> days = ParseCSV(csvLines, year);

            var list = new List<WeatherDay>(days.Values);
            list.Sort((a, b) => string.Compare(a.Date, b.Date, StringComparison.Ordinal));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Loaded {list.Count} days of NOAA data ({year}).");
            Console.ResetColor();
            return list.ToArray();
        }

        // ── Current conditions (Open-Meteo, free, no key) ──────────────────────

        public WeatherDay GetCurrentWeather()
        {
            string url = "https://api.open-meteo.com/v1/forecast" +
                $"?latitude={LAT}&longitude={LON}" +
                "&current=temperature_2m,apparent_temperature,snowfall,snow_depth," +
                "precipitation,wind_speed_10m,wind_gusts_10m,weather_code" +
                "&daily=temperature_2m_max,temperature_2m_min" +
                "&forecast_days=1" +
                "&temperature_unit=fahrenheit&wind_speed_unit=mph&precipitation_unit=inch&timezone=America/New_York";

            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "WVU-WeatherApp-MIST352");
                string json = client.GetStringAsync(url).GetAwaiter().GetResult();
                return ParseOpenMeteo(json);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  Open-Meteo unavailable – using last known NOAA day as current.");
                Console.ResetColor();
                return new WeatherDay(DateTime.Today.ToString("yyyy-MM-dd"),
                    28, 34, 3, 5, 0.3, 14, 28, false, false, false, false, false);
            }
        }

        // ── Private helpers ─────────────────────────────────────────────────────

        private static string[] DownloadStationCSV(string stationId)
        {
            string url = "https://noaa-ghcn-pds.s3.amazonaws.com/csv/by_station/" + stationId + ".csv";
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(90);
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "WVU-WeatherApp-MIST352");
                string data = client.GetStringAsync(url).GetAwaiter().GetResult();
                return data.Split('\n');
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n  NOAA fetch error: {ex.Message}");
                Console.ResetColor();
                return Array.Empty<string>();
            }
        }

        private static Dictionary<string, WeatherDay> ParseCSV(string[] lines, int year)
        {
            string yearStr = year.ToString();
            var days = new Dictionary<string, WeatherDay>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] p = line.Split(',');
                if (p.Length < 4) continue;

                string rawDate = p[1].Trim();
                if (rawDate.Length < 8 || !rawDate.StartsWith(yearStr)) continue;

                string element  = p[2].Trim();
                string rawValue = p[3].Trim();
                if (!double.TryParse(rawValue, out double value)) continue;

                // Q-flag in column index 5 – skip flagged (erroneous) data
                if (p.Length > 5 && !string.IsNullOrWhiteSpace(p[5].Trim())) continue;

                string date = $"{rawDate[..4]}-{rawDate[4..6]}-{rawDate[6..8]}";
                if (!days.ContainsKey(date))
                    days[date] = new WeatherDay { Date = date };

                WeatherDay d = days[date];

                switch (element)
                {
                    case "TMIN": d.MinTemp       = CtoF(value / 10.0);         break;
                    case "TMAX": d.MaxTemp       = CtoF(value / 10.0);         break;
                    case "PRCP": d.Precipitation = value / 10.0 / 25.4;        break; // tenths-mm → in
                    case "SNOW": d.Snowfall      = value / 25.4;               break; // mm → in
                    case "SNWD": d.SnowDepth     = value / 25.4;               break; // mm → in
                    case "AWND": d.WindSpeed     = value / 10.0 * 2.23694;     break; // tenths-m/s → mph
                    case "WSF2": d.WindGust      = value / 10.0 * 2.23694;     break;
                    case "WT01": d.HasFog        = value == 1;                  break;
                    case "WT03": d.HasThunder    = value == 1;                  break;
                    case "WT04": d.HasIce        = value == 1;                  break;
                    case "WT06": d.HasFreeze     = value == 1;                  break;
                    case "WT09": d.HasBlowingSnow= value == 1;                  break;
                }
            }

            return days;
        }

        private static WeatherDay ParseOpenMeteo(string json)
        {
            var doc = JsonDocument.Parse(json);
            var cur = doc.RootElement.GetProperty("current");

            double minT = 32, maxT = 45;
            try
            {
                var daily = doc.RootElement.GetProperty("daily");
                minT = daily.GetProperty("temperature_2m_min")[0].GetDouble();
                maxT = daily.GetProperty("temperature_2m_max")[0].GetDouble();
            }
            catch { }

            double snow    = cur.GetProperty("snowfall").GetDouble();
            double depth   = cur.GetProperty("snow_depth").GetDouble() * 39.3701; // m → in
            double precip  = cur.GetProperty("precipitation").GetDouble();
            double wind    = cur.GetProperty("wind_speed_10m").GetDouble();
            double gust    = cur.GetProperty("wind_gusts_10m").GetDouble();
            int    wCode   = cur.GetProperty("weather_code").GetInt32();

            // Decode WMO weather codes into event flags
            bool fog     = wCode is 45 or 48;
            bool ice     = wCode is 66 or 67 or 77;
            bool freeze  = wCode is 56 or 57 or 66 or 67;
            bool thunder  = wCode >= 95;
            bool blowSn  = wCode is 38 or 39;

            string today = DateTime.Today.ToString("yyyy-MM-dd");
            return new WeatherDay(today, minT, maxT, snow, depth, precip,
                                  wind, gust, fog, ice, thunder, blowSn, freeze);
        }

        private static double CtoF(double c) => c * 9.0 / 5.0 + 32.0;

        private static WeatherDay[] FallbackData() => new WeatherDay[]
        {
            // January – winter storm conditions
            new WeatherDay("2025-01-06", 18, 26,  4.0, 7.0, 0.40, 20, 38, false, true,  false, true,  false),
            new WeatherDay("2025-01-15", 22, 30,  3.0, 5.0, 0.30, 18, 30, false, false, false, true,  false),
            new WeatherDay("2025-01-20", 15, 25,  5.0, 8.0, 0.50, 22, 40, false, true,  false, true,  false),
            new WeatherDay("2025-01-21", 12, 20,  0.5, 2.0, 0.05, 28, 48, false, false, false, false, false),
            // February – Winter Storm Blair
            new WeatherDay("2025-02-05", 28, 35,  1.5, 3.0, 0.15, 10, 18, true,  false, false, false, false),
            new WeatherDay("2025-02-12", 20, 27,  6.5,10.0, 0.65, 25, 42, false, true,  false, true,  false),
            new WeatherDay("2025-02-13", 18, 24,  2.0, 9.0, 0.20, 18, 32, false, false, false, true,  false),
            new WeatherDay("2025-02-18", 18, 24,  8.0,14.0, 0.80, 30, 50, false, true,  false, true,  false),
            // March – late-season snow
            new WeatherDay("2025-03-03", 30, 38,  2.0, 4.0, 0.20, 15, 25, false, false, false, false, false),
            new WeatherDay("2025-03-10", 38, 52,  0.0, 0.0, 0.10,  8, 14, false, false, true,  false, false),
            new WeatherDay("2025-03-25", 42, 58,  0.0, 0.0, 0.25, 10, 18, false, false, false, false, false),
            // April – spring, mild
            new WeatherDay("2025-04-08", 44, 62,  0.0, 0.0, 0.20,  8, 14, false, false, false, false, false),
            new WeatherDay("2025-04-22", 50, 68,  0.0, 0.0, 0.30,  7, 12, false, false, true,  false, false),
            // May – warm spring
            new WeatherDay("2025-05-05", 56, 74,  0.0, 0.0, 0.15,  6, 10, false, false, false, false, false),
            new WeatherDay("2025-05-20", 60, 78,  0.0, 0.0, 0.35,  5,  9, false, false, true,  false, false),
            // June – early summer
            new WeatherDay("2025-06-10", 65, 82,  0.0, 0.0, 0.40,  5,  8, false, false, true,  false, false),
            new WeatherDay("2025-06-25", 68, 86,  0.0, 0.0, 0.20,  4,  7, false, false, false, false, false),
            // July – peak summer
            new WeatherDay("2025-07-04", 70, 88,  0.0, 0.0, 0.10,  4,  6, false, false, false, false, false),
            new WeatherDay("2025-07-20", 72, 90,  0.0, 0.0, 0.50,  5,  9, false, false, true,  false, false),
            // August – late summer
            new WeatherDay("2025-08-10", 68, 87,  0.0, 0.0, 0.30,  5,  8, false, false, false, false, false),
            new WeatherDay("2025-08-25", 65, 83,  0.0, 0.0, 0.25,  6, 10, false, false, true,  false, false),
            // September – early fall
            new WeatherDay("2025-09-10", 58, 76,  0.0, 0.0, 0.20,  7, 12, false, false, false, false, false),
            new WeatherDay("2025-09-25", 50, 68,  0.0, 0.0, 0.30,  8, 14, false, false, false, false, false),
            // October – fall cooling
            new WeatherDay("2025-10-10", 45, 62,  0.0, 0.0, 0.25,  9, 16, false, false, false, false, false),
            new WeatherDay("2025-10-25", 36, 52,  0.0, 0.0, 0.15, 11, 20, true,  false, false, false, false),
            // November – first winter hints
            new WeatherDay("2025-11-05", 32, 45,  0.5, 1.0, 0.10, 12, 22, false, false, false, false, false),
            new WeatherDay("2025-11-20", 29, 36,  1.0, 2.0, 0.10, 12, 22, true,  false, false, false, false),
            // December – winter returns
            new WeatherDay("2025-12-06", 20, 28,  4.5, 7.0, 0.45, 20, 35, false, true,  false, true,  false),
            new WeatherDay("2025-12-20", 25, 34,  2.0, 4.0, 0.20, 16, 28, false, false, false, false, false),
            new WeatherDay("2025-12-25", 14, 22,  7.0,12.0, 0.70, 28, 45, false, true,  false, true,  false),
        };
    }
}

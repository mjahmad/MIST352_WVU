using System;
using System.Net.Http;
using System.Text.Json;

namespace Project_1
{
    /// <summary>
    /// Feature 4 – "7-Day WVU Cancellation Outlook"
    /// Fetches the real Open-Meteo 7-day forecast for Morgantown, WV,
    /// converts each forecast day to a WeatherDay, runs the trained predictor,
    /// and renders a color-coded cancellation risk card for every day.
    /// </summary>
    internal static class ForecastDisplay
    {
        private const string URL =
            "https://api.open-meteo.com/v1/forecast" +
            "?latitude=39.6295&longitude=-79.9559" +
            "&daily=temperature_2m_max,temperature_2m_min,snowfall_sum," +
            "precipitation_sum,wind_speed_10m_max,wind_gusts_10m_max,weather_code" +
            "&forecast_days=7" +
            "&temperature_unit=fahrenheit&wind_speed_unit=mph&precipitation_unit=inch" +
            "&timezone=America%2FNew_York";

        public static void Show(CancellationPredictor predictor)
        {
            Console.Clear();

            WeatherDay[] days = FetchForecast();
            if (days.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n  Could not reach Open-Meteo. Check internet connection.");
                Console.ResetColor();
                Console.Write("  Press any key...");
                Console.ReadKey(true);
                return;
            }

            DrawHeader();

            // Per-day cards
            foreach (var day in days)
                DrawDayCard(day, predictor);

            DrawWeekSummary(days, predictor);

            Console.WriteLine();
            Console.Write("  Press any key to return to menu...");
            Console.ReadKey(true);
        }

        // ── Fetch & parse ─────────────────────────────────────────────────────

        private static WeatherDay[] FetchForecast()
        {
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "WVU-WeatherApp-MIST352");
                string json = client.GetStringAsync(URL).GetAwaiter().GetResult();
                return ParseForecast(json);
            }
            catch
            {
                return Array.Empty<WeatherDay>();
            }
        }

        private static WeatherDay[] ParseForecast(string json)
        {
            var doc   = JsonDocument.Parse(json);
            var daily = doc.RootElement.GetProperty("daily");

            var times   = daily.GetProperty("time");
            var maxT    = daily.GetProperty("temperature_2m_max");
            var minT    = daily.GetProperty("temperature_2m_min");
            var snow    = daily.GetProperty("snowfall_sum");
            var precip  = daily.GetProperty("precipitation_sum");
            var wind    = daily.GetProperty("wind_speed_10m_max");
            var gust    = daily.GetProperty("wind_gusts_10m_max");
            var code    = daily.GetProperty("weather_code");

            int count = times.GetArrayLength();
            var result = new WeatherDay[count];

            for (int i = 0; i < count; i++)
            {
                int wc      = code[i].GetInt32();
                bool fog    = wc is 45 or 48;
                bool ice    = wc is 66 or 67 or 77;
                bool freeze = wc is 56 or 57 or 66 or 67;
                bool thunder = wc >= 95;
                bool blowSn = wc is 38 or 39;

                result[i] = new WeatherDay(
                    date:        times[i].GetString() ?? "",
                    minTemp:     minT[i].GetDouble(),
                    maxTemp:     maxT[i].GetDouble(),
                    snow:        snow[i].GetDouble(),
                    snowDepth:   0,
                    precip:      precip[i].GetDouble(),
                    windSpeed:   wind[i].GetDouble(),
                    windGust:    gust[i].GetDouble(),
                    fog:         fog,
                    ice:         ice,
                    thunder:     thunder,
                    blowingSnow: blowSn,
                    freeze:      freeze
                );
            }

            return result;
        }

        // ── Rendering ─────────────────────────────────────────────────────────

        private static void DrawHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                                                          ");
            Console.WriteLine("   7-DAY WVU CLASS CANCELLATION OUTLOOK  |  Morgantown, WV              ");
            Console.WriteLine("   Powered by Open-Meteo (real forecast) + WVU cancellation ML model     ");
            Console.WriteLine("                                                                          ");
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void DrawDayCard(WeatherDay w, CancellationPredictor predictor)
        {
            double prob  = predictor.Predict(w);
            int    pct   = (int)(prob * 100);
            string risk  = pct >= 70 ? "HIGH RISK" : pct >= 40 ? "MODERATE" : pct >= 15 ? "LOW" : "MINIMAL";
            string alert = pct >= 70 ? " ⚠ CANCEL LIKELY" : pct >= 40 ? " ⚠ WATCH ALERTS" : "";

            ConsoleColor riskColor = pct >= 70 ? ConsoleColor.Red
                                   : pct >= 40 ? ConsoleColor.Yellow
                                   : ConsoleColor.Green;

            // Day-of-week label
            string dayName = "";
            if (DateTime.TryParse(w.Date, out DateTime dt))
                dayName = dt.DayOfWeek.ToString().ToUpper();

            // Box top
            Console.ForegroundColor = riskColor;
            Console.Write($"  ┌── {dayName} {w.Date}");
            if (alert.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(alert);
            }
            Console.ForegroundColor = riskColor;
            string topPad = new string('─', Math.Max(0, 60 - dayName.Length - w.Date.Length - alert.Length - 7));
            Console.WriteLine(topPad + "┐");
            Console.ResetColor();

            // Row 1: symbol + temps + snow
            Console.Write("  │  ");
            string sym = WmoSymbol(w);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{sym,-18}");
            Console.ResetColor();
            Console.Write("  |  ");
            TempWrite(w.MinTemp);
            Console.Write(" – ");
            TempWrite(w.MaxTemp);
            Console.Write("   |  ");
            if (w.Snowfall > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Snow: {w.Snowfall:F1}\"");
                Console.ResetColor();
            }
            else
            {
                Console.Write("No snow");
            }
            Console.Write($"   Precip: {w.Precipitation:F2}\"");
            Console.WriteLine("  │");

            // Row 2: wind + events
            Console.Write("  │  ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Wind: {w.WindSpeed:F0} mph  Gust: {w.WindGust:F0} mph");
            Console.ResetColor();
            Console.Write("   |  ");
            PrintInlineFlags(w);
            Console.WriteLine("   │");

            // Row 3: probability bar
            Console.Write("  │  Cancel Risk:  ");
            Console.ForegroundColor = riskColor;
            int filled = pct * 38 / 100;
            Console.Write(new string('█', filled) + new string('░', 38 - filled));
            Console.Write($"  {pct,3}%  ");
            Console.Write($"{risk,-10}");
            Console.ResetColor();
            Console.WriteLine("│");

            // Box bottom
            Console.ForegroundColor = riskColor;
            Console.WriteLine("  └" + new string('─', 65) + "┘");
            Console.ResetColor();
        }

        private static void DrawWeekSummary(WeatherDay[] days, CancellationPredictor predictor)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n  ╔══ WEEK AT A GLANCE ════════════════════════════════════════════╗");
            Console.ResetColor();

            // Mini bar per day
            Console.Write("  ║  ");
            foreach (var d in days)
            {
                string abbr = "";
                if (DateTime.TryParse(d.Date, out DateTime dt))
                    abbr = dt.ToString("ddd")[..3].ToUpper();
                Console.Write($"{abbr,-8}");
            }
            Console.WriteLine("║");

            Console.Write("  ║  ");
            foreach (var d in days)
            {
                int pct = (int)(predictor.Predict(d) * 100);
                ConsoleColor c = pct >= 70 ? ConsoleColor.Red : pct >= 40 ? ConsoleColor.Yellow : ConsoleColor.Green;
                Console.ForegroundColor = c;
                Console.Write($"{pct,3}%    ");
                Console.ResetColor();
            }
            Console.WriteLine("║");

            Console.Write("  ║  ");
            foreach (var d in days)
            {
                int pct = (int)(predictor.Predict(d) * 100);
                int bars = pct / 10;
                ConsoleColor c = pct >= 70 ? ConsoleColor.Red : pct >= 40 ? ConsoleColor.Yellow : ConsoleColor.Green;
                Console.ForegroundColor = c;
                Console.Write((new string('█', bars) + new string('░', 10 - bars))[..7] + " ");
                Console.ResetColor();
            }
            Console.WriteLine("║");

            // Find highest-risk day
            int maxPct = 0; string maxDay = "";
            foreach (var d in days)
            {
                int p = (int)(predictor.Predict(d) * 100);
                if (p > maxPct) { maxPct = p; maxDay = d.Date; }
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  ╠══ HIGHEST RISK DAY: ");
            ConsoleColor mc = maxPct >= 70 ? ConsoleColor.Red : maxPct >= 40 ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.ForegroundColor = mc;
            Console.Write($"{maxDay}  ({maxPct}%)");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('═', Math.Max(0, 41 - maxDay.Length)) + "╣");
            Console.WriteLine("  ║  Tip: Add dates to WVU_canceled_history.txt to improve accuracy.  ║");
            Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private static string WmoSymbol(WeatherDay w)
        {
            if (w.HasThunder)                        return "⛈  THUNDERSTORM";
            if (w.Snowfall >= 4 || w.HasBlowingSnow) return "❄  HEAVY SNOW";
            if (w.Snowfall >= 1)                     return "🌨  LIGHT SNOW";
            if (w.HasIce || w.HasFreeze)             return "🧊  ICE/FREEZE";
            if (w.HasFog)                            return "🌫  FOG";
            if (w.Precipitation >= 0.3)             return "🌧  RAIN";
            if (w.Precipitation > 0)                return "🌦  LIGHT RAIN";
            if (w.MinTemp <= 30)                     return "🥶  CLEAR/COLD";
            return                                          "☀  CLEAR";
        }

        private static void TempWrite(double t)
        {
            ConsoleColor c = t <= 20 ? ConsoleColor.DarkCyan : t <= 32 ? ConsoleColor.Cyan : ConsoleColor.Yellow;
            Console.ForegroundColor = c;
            Console.Write($"{t:F1}°F");
            Console.ResetColor();
        }

        private static void PrintInlineFlags(WeatherDay w)
        {
            bool any = false;
            void Flag(string s, bool on, ConsoleColor c)
            {
                if (!on) return;
                Console.ForegroundColor = c; Console.Write($"[{s}] "); Console.ResetColor(); any = true;
            }
            Flag("FOG",     w.HasFog,         ConsoleColor.Gray);
            Flag("ICE",     w.HasIce,         ConsoleColor.Cyan);
            Flag("FREEZE",  w.HasFreeze,      ConsoleColor.DarkCyan);
            Flag("BLWSNOW", w.HasBlowingSnow, ConsoleColor.White);
            Flag("THUNDER", w.HasThunder,     ConsoleColor.Yellow);
            if (!any) { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("no alerts"); Console.ResetColor(); }
        }
    }
}

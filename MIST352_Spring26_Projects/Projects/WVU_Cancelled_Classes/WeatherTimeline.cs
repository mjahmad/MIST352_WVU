using System;
using System.Collections.Generic;
using System.IO;

namespace Project_1
{
    /// <summary>
    /// Feature 1b – Full-year weather timeline.
    /// Shows a GitHub-style contribution calendar heat-map of snowfall/severity,
    /// marks WVU cancellation days, and lets the user scroll through any month.
    /// </summary>
    internal static class WeatherTimeline
    {
        public static void Show(WeatherDay[] days, string historyFile)
        {
            var cancelledDates = LoadCancelledDates(historyFile);
            var map = BuildMap(days);

            bool running = true;
            int  month   = 1;  // start at January
            int  year    = days.Length > 0 ? int.Parse(days[0].Date[..4]) : 2025;

            while (running)
            {
                Console.Clear();
                PrintYearHeatmap(map, cancelledDates, year);
                Console.WriteLine();
                PrintMonthDetail(map, cancelledDates, year, month);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("  [← →] month   [1-9,0] jump month   [Q] back to menu");
                Console.ResetColor();

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)  month = month == 1  ? 12 : month - 1;
                if (key.Key == ConsoleKey.RightArrow) month = month == 12 ?  1 : month + 1;
                if (key.Key >= ConsoleKey.D1 && key.Key <= ConsoleKey.D9)
                    month = key.Key - ConsoleKey.D0;
                if (key.Key == ConsoleKey.D0) month = 10;
                if (key.KeyChar == 'q' || key.KeyChar == 'Q') running = false;
            }
        }

        // ── Year heat-map ─────────────────────────────────────────────────────

        private static void PrintYearHeatmap(Dictionary<string, WeatherDay> map,
                                              HashSet<string> cancelled, int year)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"  ╔══ {year} SNOWFALL / SEVERITY CALENDAR ═══════════════════════════════════╗");
            Console.ResetColor();

            string[] monthAbbr = { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec" };

            // Header row
            Console.Write("  ║ ");
            foreach (string m in monthAbbr)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{m,-6}");
                Console.ResetColor();
            }
            Console.WriteLine("║");

            // 5 rows of days (week-rows 1-5, day slots)
            for (int week = 0; week < 5; week++)
            {
                Console.Write("  ║ ");
                for (int m = 1; m <= 12; m++)
                {
                    int daysInMonth = DateTime.DaysInMonth(year, m);
                    // show up to 5 blocks per month (every ~6 days)
                    int day = (week * (daysInMonth / 5)) + 1;
                    day = Math.Min(day, daysInMonth);

                    string key = $"{year}-{m:D2}-{day:D2}";
                    map.TryGetValue(key, out WeatherDay? wd);

                    char block = wd == null ? '·'
                               : wd.SeverityScore() >= 60 ? '█'
                               : wd.SeverityScore() >= 35 ? '▓'
                               : wd.SeverityScore() >= 15 ? '▒'
                               : wd.Snowfall > 0          ? '░'
                               : '·';

                    bool isCancelled = cancelled.Contains(key);
                    if (isCancelled)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"❄{block}    ");
                    }
                    else
                    {
                        ConsoleColor c = wd == null ? ConsoleColor.DarkGray
                                       : wd.SeverityScore() >= 60 ? ConsoleColor.Red
                                       : wd.SeverityScore() >= 35 ? ConsoleColor.Yellow
                                       : wd.SeverityScore() >= 15 ? ConsoleColor.Cyan
                                       : wd.Snowfall > 0          ? ConsoleColor.White
                                       : ConsoleColor.DarkGray;
                        Console.ForegroundColor = c;
                        Console.Write($"{block}     ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine("║");
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("  Legend:  · no data   ░ trace snow   ▒ light   ▓ moderate   █ heavy   ❄ WVU CANCELLED");
        }

        // ── Month detail view ─────────────────────────────────────────────────

        private static void PrintMonthDetail(Dictionary<string, WeatherDay> map,
                                              HashSet<string> cancelled, int year, int month)
        {
            string[] monthNames = { "", "January","February","March","April","May","June",
                                       "July","August","September","October","November","December" };
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  ── {monthNames[month]} {year} ──────────────────────────────────────────────");
            Console.ResetColor();

            int days = DateTime.DaysInMonth(year, month);
            bool headerPrinted = false;

            for (int d = 1; d <= days; d++)
            {
                string key = $"{year}-{month:D2}-{d:D2}";
                map.TryGetValue(key, out WeatherDay? w);

                if (!headerPrinted)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("  Date          MinT  MaxT  Snow  Depth  Precip  Wind  Gust  Events");
                    Console.WriteLine("  ─────────────────────────────────────────────────────────────────");
                    Console.ResetColor();
                    headerPrinted = true;
                }

                bool isCancelled = cancelled.Contains(key);
                if (isCancelled)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("  ❄ ");
                }
                else
                {
                    Console.Write("    ");
                }

                Console.Write($"{key}  ");

                if (w == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("  --    --    --    --      --     --    --");
                }
                else
                {
                    ConsoleColor tc = w.MinTemp <= 20 ? ConsoleColor.DarkCyan
                                    : w.MinTemp <= 32 ? ConsoleColor.Cyan
                                    : ConsoleColor.Yellow;
                    Console.ForegroundColor = tc;
                    Console.Write($"{w.MinTemp,5:F1} {w.MaxTemp,5:F1}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" {w.Snowfall,5:F1} {w.SnowDepth,6:F1}");
                    Console.ResetColor();
                    Console.Write($"  {w.Precipitation,5:F2}");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"  {w.WindSpeed,4:F0}  {w.WindGust,4:F0}");
                    Console.ResetColor();

                    var flags = "";
                    if (w.HasFog)         flags += "FOG ";
                    if (w.HasIce)         flags += "ICE ";
                    if (w.HasFreeze)      flags += "FREEZE ";
                    if (w.HasBlowingSnow) flags += "BLWSNOW ";
                    if (w.HasThunder)     flags += "THUNDER ";
                    if (flags.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"  {flags}");
                        Console.ResetColor();
                    }

                    if (isCancelled)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  ← WVU CANCELLED");
                        Console.ResetColor();
                    }
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // ── Helpers ──────────────────────────────────────────────────────────

        private static Dictionary<string, WeatherDay> BuildMap(WeatherDay[] days)
        {
            var d = new Dictionary<string, WeatherDay>(StringComparer.Ordinal);
            foreach (var w in days)
                if (!string.IsNullOrEmpty(w.Date))
                    d[w.Date] = w;
            return d;
        }

        private static HashSet<string> LoadCancelledDates(string filePath)
        {
            var set = new HashSet<string>(StringComparer.Ordinal);
            if (!File.Exists(filePath)) return set;
            foreach (string line in File.ReadAllLines(filePath))
            {
                string t = line.Trim();
                if (t.StartsWith("#") || t.Length < 10) continue;
                string date = t[..10];
                if (date[4] == '-' && date[7] == '-') set.Add(date);
            }
            return set;
        }
    }
}

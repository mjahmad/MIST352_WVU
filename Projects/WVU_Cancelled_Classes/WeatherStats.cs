using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project_1
{
    /// <summary>
    /// Feature 5 – "Weather Statistics &amp; Correlation Engine"
    /// Produces: monthly snowfall bar chart, temperature range chart,
    /// extreme records table, and cancellation factor correlation analysis.
    /// </summary>
    internal static class WeatherStats
    {
        public static void Show(WeatherDay[] history, string historyFile)
        {
            var cancelledDates = LoadCancelledDates(historyFile);
            bool running = true;
            int  tab     = 0;

            while (running)
            {
                Console.Clear();
                DrawTabBar(tab);

                switch (tab)
                {
                    case 0: DrawSnowfallChart(history);                         break;
                    case 1: DrawTempRangeChart(history);                        break;
                    case 2: DrawRecordsTable(history);                          break;
                    case 3: DrawCorrelationAnalysis(history, cancelledDates);   break;
                    case 4: DrawDistributionHistogram(history);                 break;
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("  [← →] switch tab   [Q] back to menu");
                Console.ResetColor();

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)  tab = tab == 0 ? 4 : tab - 1;
                if (key.Key == ConsoleKey.RightArrow) tab = tab == 4 ? 0 : tab + 1;
                if (key.KeyChar == 'q' || key.KeyChar == 'Q') running = false;
            }
        }

        // ── Tab bar ───────────────────────────────────────────────────────────

        private static void DrawTabBar(int active)
        {
            string[] tabs = { "Snowfall", "Temp Range", "Records", "Correlations", "Distribution" };
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  ");
            for (int i = 0; i < tabs.Length; i++)
            {
                if (i == active)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" {tabs[i]} ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.Write($" [{tabs[i]}] ");
                }
            }
            Console.ResetColor();
            Console.WriteLine("\n  " + new string('─', 70));
        }

        // ── Tab 0: Monthly snowfall bar chart ─────────────────────────────────

        private static void DrawSnowfallChart(WeatherDay[] history)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ══ MONTHLY SNOWFALL TOTALS (2025) ══\n");
            Console.ResetColor();

            string[] abbr = { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec" };
            double[] totals = MonthlyTotals(history, d => d.Snowfall);
            double   maxVal = Math.Max(totals.Max(), 0.1);

            const int BAR_WIDTH = 40;

            for (int m = 0; m < 12; m++)
            {
                double val   = totals[m];
                int    bars  = (int)(val / maxVal * BAR_WIDTH);
                string bar   = new string('█', bars) + new string('░', BAR_WIDTH - bars);

                ConsoleColor c = val >= 10 ? ConsoleColor.White
                               : val >= 3  ? ConsoleColor.Cyan
                               : val >= 0.1? ConsoleColor.Blue
                               : ConsoleColor.DarkGray;

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"  {abbr[m]}  ");
                Console.ForegroundColor = c;
                Console.Write(bar);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"  {val,6:F1}\"");
                Console.ResetColor();

                // Mark peak snowfall day for month
                string peak = PeakDay(history, m + 1, d => d.Snowfall);
                if (!string.IsNullOrEmpty(peak))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"  (peak: {peak})");
                }
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"  Total 2025 snowfall: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{totals.Sum():F1}\"");
            Console.ResetColor();
            Console.Write("   |   Snowiest month: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            int sniestIdx = Array.IndexOf(totals, totals.Max());
            Console.Write($"{abbr[sniestIdx]} ({totals[sniestIdx]:F1}\")");
            Console.ResetColor();
        }

        // ── Tab 1: Temperature range chart ────────────────────────────────────

        private static void DrawTempRangeChart(WeatherDay[] history)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ══ MONTHLY TEMPERATURE RANGE (2025) ══\n");
            Console.ResetColor();

            string[] abbr = { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec" };
            double[] avgMin = MonthlyTotals(history, d => d.MinTemp, average: true);
            double[] avgMax = MonthlyTotals(history, d => d.MaxTemp, average: true);

            // Y-axis ticks: 0 to 90°F in 10° increments
            int rowCount = 10;   // 0–90
            int colWidth = 5;

            // Header with month names
            Console.Write("        ");
            foreach (string m in abbr)
                Console.Write(m.PadRight(colWidth));
            Console.WriteLine();
            Console.Write("        ");
            Console.WriteLine(new string('─', abbr.Length * colWidth));

            for (int row = rowCount; row >= 0; row--)
            {
                double tempThisRow = row * 9.0;   // row 10 = 90°F, row 0 = 0°F
                double tempNext    = tempThisRow - 9.0;

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"  {(int)tempThisRow,3}°F │");
                Console.ResetColor();

                for (int m = 0; m < 12; m++)
                {
                    double lo = avgMin[m];
                    double hi = avgMax[m];

                    bool inRange  = hi >= tempNext && lo <= tempThisRow;
                    bool isAvg    = Math.Abs(((lo + hi) / 2) - tempThisRow) < 5;
                    bool freezing = tempThisRow <= 32;

                    if (!inRange)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("·    ");
                    }
                    else if (isAvg)
                    {
                        Console.ForegroundColor = freezing ? ConsoleColor.Cyan : ConsoleColor.Yellow;
                        Console.Write("████ ");
                    }
                    else
                    {
                        Console.ForegroundColor = freezing ? ConsoleColor.DarkBlue : ConsoleColor.DarkYellow;
                        Console.Write("░░░░ ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            // Freeze line indicator
            Console.Write("   32°F │");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('─', abbr.Length * colWidth) + " ← FREEZE");
            Console.ResetColor();

            Console.Write("        ");
            foreach (string m in abbr)
                Console.Write(m.PadRight(colWidth));
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Legend:  ████ average temperature   ░░░░ min–max range   · no data");
            Console.ResetColor();
        }

        // ── Tab 2: Extreme records table ──────────────────────────────────────

        private static void DrawRecordsTable(WeatherDay[] history)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ══ 2025 EXTREME WEATHER RECORDS ══\n");
            Console.ResetColor();

            if (history.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  No historical data loaded.");
                Console.ResetColor();
                return;
            }

            Record(history, "Coldest day (min temp)",    d => d.MinTemp,       lowest: true,  fmt: "F1", unit: "°F");
            Record(history, "Warmest day (max temp)",    d => d.MaxTemp,       lowest: false, fmt: "F1", unit: "°F");
            Record(history, "Most snowfall in 1 day",    d => d.Snowfall,      lowest: false, fmt: "F1", unit: "\"");
            Record(history, "Deepest snow depth",        d => d.SnowDepth,     lowest: false, fmt: "F1", unit: "\"");
            Record(history, "Highest wind gust",         d => d.WindGust,      lowest: false, fmt: "F0", unit: " mph");
            Record(history, "Highest avg wind",          d => d.WindSpeed,     lowest: false, fmt: "F0", unit: " mph");
            Record(history, "Most precipitation",        d => d.Precipitation, lowest: false, fmt: "F2", unit: "\"");
            Record(history, "Highest severity score",    d => d.SeverityScore(), lowest: false, fmt: "F0", unit: "/100");

            Console.WriteLine();
            int fogDays   = history.Count(d => d.HasFog);
            int iceDays   = history.Count(d => d.HasIce);
            int thunderDays = history.Count(d => d.HasThunder);
            int blwsnowDays = history.Count(d => d.HasBlowingSnow);
            int freezeDays  = history.Count(d => d.HasFreeze);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ── Event Day Counts ──────────────────────────────────────────");
            Console.ResetColor();
            EventCount("Fog days",          fogDays,     history.Length);
            EventCount("Ice days",          iceDays,     history.Length);
            EventCount("Thunder days",      thunderDays, history.Length);
            EventCount("Blowing snow days", blwsnowDays, history.Length);
            EventCount("Freezing rain days",freezeDays,  history.Length);
        }

        private static void Record(WeatherDay[] h, string label, Func<WeatherDay, double> sel,
                                   bool lowest, string fmt, string unit)
        {
            WeatherDay? best = null;
            double bestVal = lowest ? double.MaxValue : double.MinValue;

            foreach (var d in h)
            {
                double v = sel(d);
                if (lowest ? v < bestVal : v > bestVal) { bestVal = v; best = d; }
            }

            Console.Write($"  {label,-35}");
            if (best == null) { Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("N/A"); Console.ResetColor(); return; }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{bestVal.ToString(fmt)}{unit}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"   ({best.Date})");
            Console.ResetColor();
        }

        private static void EventCount(string label, int count, int total)
        {
            Console.Write($"  {label,-28}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{count,4} days");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  ({(total > 0 ? 100.0 * count / total : 0):F1}% of year)");
            Console.ResetColor();
        }

        // ── Tab 3: Cancellation factor correlation ────────────────────────────

        private static void DrawCorrelationAnalysis(WeatherDay[] history, HashSet<string> cancelled)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ══ CANCELLATION FACTOR ANALYSIS ══\n");
            Console.ResetColor();

            if (cancelled.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  No cancellation dates loaded.");
                Console.WriteLine("  Fill in WVU_canceled_history.txt and restart to see correlations.");
                Console.ResetColor();
                return;
            }

            var cancelDays  = history.Where(d => cancelled.Contains(d.Date)).ToArray();
            var normalDays  = history.Where(d => !cancelled.Contains(d.Date)).ToArray();

            if (cancelDays.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  No matching NOAA data for the entered cancellation dates.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  Cancellation days analyzed: {cancelDays.Length}   |   Normal days: {normalDays.Length}");
            Console.WriteLine($"  Cancellation rate: {100.0 * cancelDays.Length / history.Length:F1}%\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"  {"Metric",-20}  {"CANCEL days":>12}  {"NORMAL days":>12}  Difference  Signal");
            Console.WriteLine("  " + new string('─', 72));
            Console.ResetColor();

            FactorRow("Min Temp (°F)",    cancelDays, normalDays, d => d.MinTemp,       "F1", lower: true);
            FactorRow("Max Temp (°F)",    cancelDays, normalDays, d => d.MaxTemp,       "F1", lower: true);
            FactorRow("Snowfall (in)",    cancelDays, normalDays, d => d.Snowfall,      "F2", lower: false);
            FactorRow("Snow Depth (in)",  cancelDays, normalDays, d => d.SnowDepth,     "F2", lower: false);
            FactorRow("Precipitation\"",  cancelDays, normalDays, d => d.Precipitation, "F3", lower: false);
            FactorRow("Wind Avg (mph)",   cancelDays, normalDays, d => d.WindSpeed,     "F1", lower: false);
            FactorRow("Wind Gust (mph)",  cancelDays, normalDays, d => d.WindGust,      "F1", lower: false);
            FactorRow("Severity Score",   cancelDays, normalDays, d => d.SeverityScore(),"F0", lower: false);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Signal strength:  ▌ weak   ██ moderate   ████ strong   ████████ decisive");
            Console.ResetColor();

            // Most common cancellation month
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ── Cancellation Days by Month ─────────────────────────────────────");
            Console.ResetColor();
            string[] abbr = { "","Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec" };
            int[] byMonth = new int[13];
            foreach (var d in cancelDays)
                if (d.Date.Length >= 7)
                    if (int.TryParse(d.Date[5..7], out int m))
                        byMonth[m]++;

            for (int m = 1; m <= 12; m++)
            {
                if (byMonth[m] == 0) continue;
                string bar = new string('█', byMonth[m] * 4);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"  {abbr[m]}  {bar}  ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{byMonth[m]} cancellation day{(byMonth[m] != 1 ? "s" : "")}");
                Console.ResetColor();
            }
        }

        private static void FactorRow(string label, WeatherDay[] cancel, WeatherDay[] normal,
                                      Func<WeatherDay, double> sel, string fmt, bool lower)
        {
            if (cancel.Length == 0 || normal.Length == 0) return;

            double ca  = cancel.Average(sel);
            double na  = normal.Average(sel);
            double diff = ca - na;
            bool strong = lower ? diff < -5 : diff > 2;

            // Signal: how much worse are cancel days than normal?
            double maxSignal = lower ? Math.Abs(Math.Min(diff, 0)) / 20.0
                                     : Math.Max(diff, 0) / 10.0;
            maxSignal = Math.Min(maxSignal, 1.0);
            int sigBars = (int)(maxSignal * 8);

            ConsoleColor c = sigBars >= 6 ? ConsoleColor.Red
                           : sigBars >= 3 ? ConsoleColor.Yellow
                           : ConsoleColor.Green;

            Console.Write($"  {label,-20}  {ca.ToString(fmt),12}  {na.ToString(fmt),12}  ");
            Console.ForegroundColor = c;
            string diffStr = (diff >= 0 ? "+" : "") + diff.ToString(fmt);
            Console.Write(diffStr.PadLeft(10));
            Console.ResetColor();
            Console.Write("  ");
            Console.ForegroundColor = c;
            Console.WriteLine(new string('█', Math.Max(0, sigBars)));
            Console.ResetColor();
        }

        // ── Tab 4: Severity distribution histogram ────────────────────────────

        private static void DrawDistributionHistogram(WeatherDay[] history)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ══ SEVERITY SCORE DISTRIBUTION (2025) ══\n");
            Console.ResetColor();

            // Bucket scores into bins of 10
            int[] bins = new int[11]; // 0-9, 10-19, ..., 90-100
            foreach (var d in history)
            {
                int bin = Math.Min(d.SeverityScore() / 10, 10);
                bins[bin]++;
            }

            int maxBin = Math.Max(bins.Max(), 1);
            const int BAR = 40;

            string[] labels = { "0-9   ","10-19 ","20-29 ","30-39 ","40-49 ",
                                 "50-59 ","60-69 ","70-79 ","80-89 ","90-99 ","100   " };
            string[] riskLabels = { "None","Low","Low","Moderate","Moderate","Elevated",
                                    "High","High","Extreme","Extreme","Max" };
            ConsoleColor[] colors = {
                ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.Gray,
                ConsoleColor.Green,    ConsoleColor.Green, ConsoleColor.Yellow,
                ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Red, ConsoleColor.Red, ConsoleColor.Red
            };

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Score Range   Days  Risk Level  Distribution");
            Console.WriteLine("  " + new string('─', 65));
            Console.ResetColor();

            for (int i = 0; i < 11; i++)
            {
                int filled = bins[i] * BAR / maxBin;
                Console.Write($"  {labels[i]} {bins[i],4}  ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"{riskLabels[i],-10}  ");
                Console.ForegroundColor = colors[i];
                Console.WriteLine(new string('█', filled));
                Console.ResetColor();
            }

            Console.WriteLine();

            // Summary
            int noneCount     = bins[0] + bins[1] + bins[2];
            int moderateCount = bins[3] + bins[4] + bins[5];
            int highCount     = bins.Skip(6).Sum();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"  Low-risk days:      ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{noneCount} ({Pct(noneCount, history.Length)}%)");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"  Moderate-risk days: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{moderateCount} ({Pct(moderateCount, history.Length)}%)");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"  High-risk days:     ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{highCount} ({Pct(highCount, history.Length)}%)");

            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  Average severity score: {(history.Length > 0 ? history.Average(d => d.SeverityScore()) : 0):F1} / 100");
            Console.ResetColor();
        }

        // ── Shared helpers ────────────────────────────────────────────────────

        private static double[] MonthlyTotals(WeatherDay[] history, Func<WeatherDay, double> sel,
                                              bool average = false)
        {
            double[] totals = new double[12];
            int[]    counts = new int[12];

            foreach (var d in history)
            {
                if (d.Date.Length < 7) continue;
                if (!int.TryParse(d.Date[5..7], out int m)) continue;
                if (m < 1 || m > 12) continue;
                totals[m - 1] += sel(d);
                counts[m - 1]++;
            }

            if (average)
                for (int i = 0; i < 12; i++)
                    if (counts[i] > 0) totals[i] /= counts[i];

            return totals;
        }

        private static string PeakDay(WeatherDay[] history, int month, Func<WeatherDay, double> sel)
        {
            WeatherDay? best = null;
            double bestVal = double.MinValue;

            foreach (var d in history)
            {
                if (d.Date.Length < 7) continue;
                if (!int.TryParse(d.Date[5..7], out int m) || m != month) continue;
                double v = sel(d);
                if (v > bestVal) { bestVal = v; best = d; }
            }

            if (best == null || bestVal <= 0) return "";
            return $"{best.Date} = {bestVal:F1}\"";
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

        private static int Pct(int part, int total)
            => total == 0 ? 0 : (int)Math.Round(100.0 * part / total);
    }
}

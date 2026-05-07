using System;
using System.IO;
using System.Threading;

namespace Project_1
{
    internal class Program
    {
        private const string HISTORY_FILE = "WVU_canceled_history.txt";
        private const int    HIST_YEAR    = 2025;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "WVU Weather Cancellation System";

            PrintBanner();

            // ── Load data (with spinner) ────────────────────────────────────
            WeatherDay[] history    = Array.Empty<WeatherDay>();
            WeatherDay   today      = new WeatherDay();
            double       probability = 0;

            Spinner("Fetching NOAA historical data (this may take 10-30 s)", () =>
            {
                var svc = new NOAAService("Morgantown");
                history = svc.GetHistoricalData(HIST_YEAR);
                today   = svc.GetCurrentWeather();
            });

            // ── Build predictor from history file ───────────────────────────
            CancellationRecord[] legacyRecords = new CancellationRecord[history.Length];
            for (int i = 0; i < history.Length; i++)
                legacyRecords[i] = new CancellationRecord(history[i].Date, false, history[i]);

            var predictor = new CancellationPredictor(legacyRecords);
            predictor.TrainFromHistory(history, HISTORY_FILE);
            probability = predictor.Predict(today);

            var engine = new DecisionEngine();

            // ── Main menu loop ──────────────────────────────────────────────
            bool running = true;
            while (running)
            {
                PrintMenu(today, probability);
                char key = char.ToUpper(Console.ReadKey(true).KeyChar);

                switch (key)
                {
                    case '1':
                        ShowTodayDetails(today, engine, predictor);
                        break;

                    case '2':
                        WeatherTimeline.Show(history, HISTORY_FILE);
                        break;

                    case '3':
                        MapDisplay.Show(today);
                        break;

                    case '4':
                        AnimatedDashboard.Run(today, history, probability);
                        break;

                    case '5':
                        ShowTopDays(history);
                        break;

                    case '6':
                        ForecastDisplay.Show(predictor);
                        break;

                    case '7':
                        WeatherStats.Show(history, HISTORY_FILE);
                        break;

                    case 'H':
                        ShowHelp();
                        break;

                    case 'Q':
                        running = false;
                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n  Goodbye – stay warm, Mountaineers!");
            Console.ResetColor();
        }

        // ── Menu UI ───────────────────────────────────────────────────────────

        private static void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                                                        ");
            Console.WriteLine("   WVU CLASS CANCELLATION PREDICTION SYSTEM  |  Morgantown, WV  v3.0  ");
            Console.WriteLine("                                                                        ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("   NOAA GHCN-Daily  +  Open-Meteo  +  WVU Cancellation History\n");
            Console.ResetColor();
        }

        private static void PrintMenu(WeatherDay today, double probability)
        {
            Console.Clear();
            PrintBanner();

            // Quick status strip
            int pct = (int)(probability * 100);
            ConsoleColor pc = pct >= 70 ? ConsoleColor.Red : pct >= 40 ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.Write("  Today: "); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{today.Date}"); Console.ResetColor();
            Console.Write($"  |  {today.MinTemp:F0}°–{today.MaxTemp:F0}°F");
            Console.Write($"  |  Snow {today.Snowfall:F1}\"");
            Console.Write("  |  Cancel probability: "); Console.ForegroundColor = pc;
            Console.Write($"{pct}%"); Console.ResetColor();
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║                     MAIN MENU                        ║");
            Console.WriteLine("  ╠══════════════════════════════════════════════════════╣");
            Console.ResetColor();
            MenuItem('1', "Today's full conditions + prediction");
            MenuItem('2', "Historical weather timeline  (2025 calendar)");
            MenuItem('3', "Morgantown weather map");
            MenuItem('4', "Weather Intelligence Center  [animated war room]");
            MenuItem('5', "Top 15 most severe days of 2025");
            MenuItem('6', "7-Day WVU Cancellation Forecast Outlook");
            MenuItem('7', "Weather Statistics & Correlation Engine");
            MenuItem('H', "Help / User Guide");
            MenuItem('Q', "Quit");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("\n  Choice: ");
        }

        private static void MenuItem(char key, string label)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  ║  [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(key);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("] ");
            Console.ResetColor();
            Console.Write($"{label,-48}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("║");
            Console.ResetColor();
        }

        // ── Option 1: Today ───────────────────────────────────────────────────

        private static void ShowTodayDetails(WeatherDay today, DecisionEngine engine, CancellationPredictor predictor)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  ══ TODAY'S CONDITIONS  {today.Date} ══\n");
            Console.ResetColor();
            today.DisplayInfo();
            Console.WriteLine();
            engine.PrintAssessment(today);
            predictor.PrintPrediction(today);
            Console.WriteLine();
            Console.Write("  Press any key...");
            Console.ReadKey(true);
        }

        // ── Option 5: Top severe days ─────────────────────────────────────────

        private static void ShowTopDays(WeatherDay[] history)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  ══ TOP 15 MOST SEVERE DAYS  ({HIST_YEAR}) ══\n");
            Console.ResetColor();

            var sorted = (WeatherDay[])history.Clone();
            Array.Sort(sorted, (a, b) => b.SeverityScore() - a.SeverityScore());

            int count = Math.Min(15, sorted.Length);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("       Date          MinT   MaxT   Snow  Depth  Precip  Wind  Gust");
            Console.WriteLine("  " + new string('─', 70));
            Console.ResetColor();

            for (int i = 0; i < count; i++)
            {
                var d = sorted[i];
                ConsoleColor sc = d.SeverityScore() >= 60 ? ConsoleColor.Red
                                : d.SeverityScore() >= 30 ? ConsoleColor.Yellow
                                : ConsoleColor.Green;
                Console.ForegroundColor = sc;
                Console.Write($"  {i+1,2}. ");
                Console.ResetColor();
                d.DisplayInfo();
                Console.ForegroundColor = sc;
                Console.Write($"       Severity: {d.SeverityScore(),3}/100");
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("  Press any key...");
            Console.ReadKey(true);
        }

        // ── Help screen ───────────────────────────────────────────────────────

        private static void ShowHelp()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  WVU WEATHER CANCELLATION SYSTEM  –  QUICK HELP GUIDE             ");
            Console.ResetColor();
            Console.WriteLine();

            Section("GETTING STARTED");
            Console.WriteLine("  The system automatically fetches NOAA weather data for Morgantown,");
            Console.WriteLine("  WV on startup. This requires an internet connection and may take");
            Console.WriteLine("  up to 30 seconds. If it fails, built-in sample data is used.");
            Console.WriteLine();

            Section("CANCELLATION HISTORY FILE");
            Console.WriteLine("  Open  WVU_canceled_history.txt  in any text editor.");
            Console.WriteLine("  Each cancellation day is one line:   YYYY-MM-DD | Reason");
            Console.WriteLine("  Lines starting with # are comments (ignored).");
            Console.WriteLine("  Example:   2025-01-21 | Winter storm - heavy snow");
            Console.WriteLine("  More data = better predictions. Add ALL days you know about.");
            Console.WriteLine();

            Section("MENU OPTIONS");
            HelpItem('1', "Today's Conditions",
                     "Shows live weather from Open-Meteo, runs the rule engine and ML predictor.");
            HelpItem('2', "Historical Timeline",
                     "GitHub-style calendar heatmap. Use ← → arrows to navigate months.");
            HelpItem('3', "Weather Map",
                     "ASCII map of Morgantown with live weather overlaid on landmarks.");
            HelpItem('4', "War Room [animated]",
                     "Full-screen animated radar, probability gauge, severity timeline bar.");
            HelpItem('5', "Top Severe Days",
                     "Ranks 2025 days by composite severity score (0-100 scale).");
            HelpItem('6', "7-Day Forecast",
                     "Real forecast from Open-Meteo. Each day gets a cancellation risk card.");
            HelpItem('7', "Statistics Engine",
                     "5 tabs: Snowfall chart, Temp chart, Records, Correlations, Distribution.");
            HelpItem('H', "Help", "This screen.");
            HelpItem('Q', "Quit", "Exit the application.");
            Console.WriteLine();

            Section("HOW THE PREDICTION WORKS");
            Console.WriteLine("  1. The system loads 2025 NOAA data (temp, snow, wind, ice flags).");
            Console.WriteLine("  2. Each date in WVU_canceled_history.txt is matched to that day's");
            Console.WriteLine("     weather to build a cancellation profile.");
            Console.WriteLine("  3. The predictor computes average conditions on cancelled vs.");
            Console.WriteLine("     normal days (snowfall, min temp, wind gust, severity score).");
            Console.WriteLine("  4. Today's weather is compared to both profiles using a weighted");
            Console.WriteLine("     similarity score, adjusted for dangerous event flags (ice,");
            Console.WriteLine("     freezing rain, blowing snow).");
            Console.WriteLine("  5. The result is a 0-100% probability displayed everywhere.");
            Console.WriteLine();

            Section("DATA SOURCES");
            Console.WriteLine("  NOAA GHCN-Daily  https://noaa-ghcn-pds.s3.amazonaws.com");
            Console.WriteLine("    Station: USC00555882 (Morgantown Lock 4, WV)");
            Console.WriteLine("    Elements: TMIN, TMAX, PRCP, SNOW, SNWD, AWND, WSF2,");
            Console.WriteLine("              WT01(fog), WT03(thunder), WT04(ice),");
            Console.WriteLine("              WT06(freeze), WT09(blowing snow)");
            Console.WriteLine();
            Console.WriteLine("  Open-Meteo       https://api.open-meteo.com  (free, no key)");
            Console.WriteLine("    Used for:  current conditions + 7-day forecast");
            Console.WriteLine();

            Section("TIPS");
            Console.WriteLine("  • The more dates you add to WVU_canceled_history.txt, the");
            Console.WriteLine("    more accurate the predictions become.");
            Console.WriteLine("  • In the War Room [4], press any key to stop the animation.");
            Console.WriteLine("  • Stats [7] has 5 sub-tabs – navigate with ← → arrow keys.");
            Console.WriteLine("  • Timeline [2] is also navigable by ← → or press 1-9 to jump.");
            Console.WriteLine("  • See USER_GUIDE.txt in the project folder for full documentation.");
            Console.WriteLine();

            Console.Write("  Press any key to return to menu...");
            Console.ReadKey(true);
        }

        private static void Section(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"  ── {title} ");
            Console.WriteLine(new string('─', Math.Max(0, 62 - title.Length)));
            Console.ResetColor();
        }

        private static void HelpItem(char key, string label, string desc)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"  [{key}]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {label,-22}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  {desc}");
            Console.ResetColor();
        }

        // ── Spinner helper ────────────────────────────────────────────────────

        private static void Spinner(string label, Action work)
        {
            bool done   = false;
            var  thread = new Thread(() =>
            {
                string[] frames = { "|", "/", "-", "\\" };
                int i = 0;
                Console.CursorVisible = false;
                Console.Write($"\n  {label}  ");
                while (!done)
                {
                    Console.Write(frames[i++ % 4]);
                    Console.Write('\b');
                    Thread.Sleep(100);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Done");
                Console.ResetColor();
                Console.CursorVisible = true;
            });

            thread.IsBackground = true;
            thread.Start();
            work();
            done = true;
            thread.Join();
        }
    }
}

using System;

namespace Project_1
{
    /// <summary>
    /// Entry point for Bonfire Planner v2.0.
    /// Menu-driven console application — all features accessible from here.
    /// </summary>
    internal class Program
    {
        // Shared data — loaded once at startup
        static NOAAService   _service;
        static WeatherDay[]  _forecast;
        static WeatherDay    _tonight;
        static bool          _dataLoaded = false;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Bonfire Planner v2.0";

            // Startup splash
            DrawSplash();

            // Get location from user
            string location = GetLocation();
            _service = new NOAAService(location);

            // Load weather data
            LoadWeatherData();

            // Main menu loop
            bool running = true;
            while (running)
            {
                DrawMenu(location);
                string choice = Console.ReadLine() ?? "";

                switch (choice.Trim())
                {
                    case "1": RunFireScore();           break;
                    case "2": RunBestTime();            break;
                    case "3": RunWindAdvisor();         break;
                    case "4": RunFirewoodDryness();     break;
                    case "5": RunComfortAdvisor();      break;
                    case "6": RunHistoricalComparison();break;
                    case "7": RunDashboard();           break;
                    case "8": RunSafetyAdvisor();       break;
                    case "9": RunSmoresMode();          break;
                    case "R":
                    case "r": RefreshData();             break;
                    case "0": running = false;           break;
                    default:
                        Console.WriteLine();
                        ConsoleUI.Warn("Invalid option. Please enter a number 0–9.");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }

            DrawGoodbye();
        }

        // ── startup helpers ───────────────────────────────────────────────

        static void DrawSplash()
{
    Console.Clear();

    int boxWidth = 56;

    string title = "🔥 BONFIRE PLANNER v2.0 🔥";
    string subtitle = "Powered by NOAA api.weather.gov";
    string footer = "MIST 352 – Spring 2026";

    // Top border in RED
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("╔════════════════════════════════════════════════════════╗");

    // White text inside
    PrintCenteredLine(title, boxWidth, ConsoleColor.White);
    PrintCenteredLine(subtitle, boxWidth, ConsoleColor.Gray);
    PrintCenteredLine(footer, boxWidth, ConsoleColor.White);

    // Bottom border in RED
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("╚════════════════════════════════════════════════════════╝");

    Console.ResetColor();
    Console.WriteLine();
}

static void PrintCenteredLine(string text, int width, ConsoleColor textColor)
{
    int leftPadding = (width - text.Length) / 2;

    if (leftPadding < 0)
        leftPadding = 0;

    text = text.PadLeft(text.Length + leftPadding).PadRight(width);

    // Red side borders
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("║");

    // White/Gray text
    Console.ForegroundColor = textColor;
    Console.Write(text);

    // Red closing border
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("║");

    Console.ResetColor();
}

static void PrintCenteredLine(string text, int width)
{
    int leftPadding = (width - text.Length) / 2;

    if (leftPadding < 0)
        leftPadding = 0;

    text = text.PadLeft(text.Length + leftPadding).PadRight(width);

    Console.WriteLine($"║{text}║");
}

        static string GetLocation()
        {
            ConsoleUI.SetCyan();
            Console.Write("  Enter your location (press ENTER for Morgantown, WV): ");
            ConsoleUI.Reset();
            string loc = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(loc)) loc = "Morgantown, WV";
            return loc;
        }

        static void LoadWeatherData()
        {
            Console.WriteLine();
            ConsoleUI.SetDim();
            Console.Write("  Loading NOAA weather data...");
            ConsoleUI.Reset();

            try
            {
                _forecast   = _service.Get7DayForecast();
                _tonight    = _service.GetTonight();
                _dataLoaded = true;

                ConsoleUI.SetGood();
                Console.WriteLine(" Done!");
                ConsoleUI.Reset();
            }
            catch (Exception ex)
            {
                ConsoleUI.SetWarn();
                Console.WriteLine(" Using offline fallback data.");
                Console.WriteLine("  (" + ex.Message + ")");
                ConsoleUI.Reset();
                _dataLoaded = true;
            }

            System.Threading.Thread.Sleep(800);
        }

        static void RefreshData()
        {
            Console.Clear();
            ConsoleUI.Header("REFRESHING NOAA DATA");
            _dataLoaded = false;
            LoadWeatherData();
            ConsoleUI.Good("Data refreshed successfully.");
            ConsoleUI.PressEnter();
        }

        // ── main menu ─────────────────────────────────────────────────────

        static void DrawMenu(string location)
        {
            Console.Clear();

            ConsoleUI.SetFire();
            Console.WriteLine();
            Console.WriteLine("  ╔══════════════════════════════════════════════════════╗");
            Console.Write("  ║");
            ConsoleUI.SetWhite();
            Console.Write("          🔥  BONFIRE PLANNER  v2.0  🔥                 ");
            ConsoleUI.SetFire();
            Console.WriteLine("║");
            Console.Write("  ║");
            ConsoleUI.SetDim();
            string loc = ("  " + location).PadRight(52);
            Console.Write(loc);
            ConsoleUI.SetFire();
            Console.WriteLine("║");
            Console.WriteLine("  ╚══════════════════════════════════════════════════════╝");
            ConsoleUI.Reset();

            Console.WriteLine();

            // Tonight's quick-stat strip
            if (_tonight != null)
            {
                ConsoleUI.SetDim();
                Console.Write("  Tonight: ");
                ConsoleUI.Reset();
                Console.Write($"{_tonight._temperature:F0}°F  │  ");
                Console.Write($"Wind {_tonight._windspeed:F0} mph {_tonight._winddirection}  │  ");
                Console.Write($"Rain {_tonight._rainchance:F0}%  │  ");
                Console.WriteLine($"{_tonight._shortforecast}");
            }

            Console.WriteLine();
            ConsoleUI.SetCyan();
            Console.WriteLine("  ┌─────────────────────────────────────────────────┐");
            Console.WriteLine("  │                    MAIN MENU                    │");
            Console.WriteLine("  └─────────────────────────────────────────────────┘");
            ConsoleUI.Reset();
            Console.WriteLine();

            PrintMenuItem("1", "Tonight's Fire Score");
            PrintMenuItem("2", "Best Bonfire Time + 7-Night Forecast");
            PrintMenuItem("3", "Wind Direction + Where to Sit");
            PrintMenuItem("4", "Firewood Dryness Check");
            PrintMenuItem("5", "Hoodie / Blanket Recommendation");
            PrintMenuItem("6", "Historical Bonfire Comparison  (WV)");
            PrintMenuItem("7", "Full Bonfire Dashboard  ★");
            PrintMenuItem("8", "Campfire Safety Advisor");
            PrintMenuItem("9", "S'mores Mode  🍫");
            Console.WriteLine();
            PrintMenuItem("R", "Refresh NOAA Data");
            PrintMenuItem("0", "Exit");

            Console.WriteLine();
            ConsoleUI.SetCyan();
            Console.Write("  Choose an option > ");
            ConsoleUI.Reset();
        }

        static void PrintMenuItem(string key, string label)
        {
            ConsoleUI.SetDim();
            Console.Write("  [");
            ConsoleUI.SetFire();
            Console.Write(key);
            ConsoleUI.SetDim();
            Console.Write("] ");
            ConsoleUI.Reset();
            Console.WriteLine(label);
        }

        // ── menu actions ──────────────────────────────────────────────────

        static void RunFireScore()
        {
            Console.Clear();
            ConsoleUI.Header("TONIGHT'S FIRE SCORE");

            FireScoreCalculator calc = new FireScoreCalculator();
            calc.Calculate(_tonight);
            calc.DisplayBreakdown();

            ConsoleUI.PressEnter();
        }

        static void RunBestTime()
        {
            Console.Clear();
            BonfirePlanner planner = new BonfirePlanner(_forecast);
            planner.DisplayBestTime();
            ConsoleUI.PressEnter();
        }

        static void RunWindAdvisor()
        {
            Console.Clear();
            WindAdvisor advisor = new WindAdvisor(_tonight);
            advisor.Display();
            ConsoleUI.PressEnter();
        }

        static void RunFirewoodDryness()
        {
            Console.Clear();
            FirewoodDrynessEstimator estimator =
                new FirewoodDrynessEstimator(_tonight, _forecast);
            estimator.Display();
            ConsoleUI.PressEnter();
        }

        static void RunComfortAdvisor()
        {
            Console.Clear();
            ComfortAdvisor advisor = new ComfortAdvisor(_tonight);
            advisor.Display();
            ConsoleUI.PressEnter();
        }

        static void RunHistoricalComparison()
        {
            Console.Clear();
            HistoricalComparison comparison =
                new HistoricalComparison(_tonight, _service);
            comparison.Display();
            ConsoleUI.PressEnter();
        }

        static void RunDashboard()
        {
            Console.Clear();
            BonfireDashboard dashboard = new BonfireDashboard(_tonight);
            dashboard.Display();
            ConsoleUI.PressEnter();
        }

        static void RunSafetyAdvisor()
        {
            Console.Clear();
            SafetyAdvisor advisor = new SafetyAdvisor(_tonight);
            advisor.Display();
            ConsoleUI.PressEnter();
        }

        static void RunSmoresMode()
        {
            Console.Clear();
            FireScoreCalculator calc = new FireScoreCalculator();
            calc.Calculate(_tonight);
            SmoresMode smores = new SmoresMode(_tonight, calc);
            smores.Display();
            ConsoleUI.PressEnter();
        }

        // ── goodbye ───────────────────────────────────────────────────────

        static void DrawGoodbye()
        {
            Console.Clear();
            ConsoleUI.SetFire();
            Console.WriteLine();
            Console.WriteLine("  ╔══════════════════════════════════════════╗");
            Console.WriteLine("  ║                                          ║");
            Console.Write("  ║");
            ConsoleUI.SetWhite();
            Console.Write("   Stay warm, stay safe, and enjoy the fire! ");
            ConsoleUI.SetFire();
            Console.WriteLine("║");
            Console.Write("  ║");
            ConsoleUI.SetDim();
            Console.Write("         Bonfire Planner v2.0  — goodbye        ");
            ConsoleUI.SetFire();
            Console.WriteLine("║");
            Console.WriteLine("  ║                                          ║");
            Console.WriteLine("  ╚══════════════════════════════════════════╝");
            ConsoleUI.Reset();
            Console.WriteLine();
        }
    }
}

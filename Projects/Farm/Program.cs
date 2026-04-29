namespace Project_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Farm & Garden Planner v2.0";

            // ── Location Setup ────────────────────────────────────────
            Console.Clear();
            ConsoleUI.Header("FARM & GARDEN PLANNER  v2.0");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Powered by NOAA Weather Data & Real-Time Forecasts");
            Console.ResetColor();

            ConsoleUI.Prompt("Enter your location (e.g. Morgantown, WV) [ENTER for default]");
            string input = Console.ReadLine()?.Trim() ?? "";
            string location = string.IsNullOrEmpty(input) ? "Morgantown, WV" : input;

            // ── Data Loading ──────────────────────────────────────────
            Console.Clear();
            ConsoleUI.Header("LOADING DATA — PLEASE WAIT");

            var service = new NOAAService(location);
            WeatherDay[] forecast = [];
            HistoricalStats[] history = [];

            ConsoleUI.Loading("Fetching 7-day forecast from api.weather.gov...");
            try { forecast = service.Get7DayForecast(); ConsoleUI.Done(); }
            catch { Console.WriteLine(" using fallback data."); }

            ConsoleUI.Loading("Fetching historical NOAA data (last year)...");
            try { history = service.GetHistoricalMonthlyStats(DateTime.Now.Year - 1); ConsoleUI.Done(); }
            catch { Console.WriteLine(" using demo data."); history = NOAAService.GetFallbackHistoricalStats(); }

            var garden  = new GardenManager();
            var advisor = new PlantAdvisor(history, forecast);
            var journal = new GardenJournal();

            // ── Main Menu Loop ────────────────────────────────────────
            while (true)
            {
                Console.Clear();
                DrawMainMenu(location, forecast);

                ConsoleUI.Prompt("Choose an option");
                string choice = Console.ReadLine()?.Trim() ?? "";

                Console.Clear();
                switch (choice)
                {
                    case "1":
                        WeatherDashboard.Display(forecast, location);
                        break;
                    case "2":
                        advisor.DisplayRecommendations();
                        break;
                    case "3":
                        ConsoleUI.Header("GARDEN VIEWS");
                        GardenVisualizer.DrawGardenScene(garden.Entries);
                        ConsoleUI.WaitForKey("Press any key to open grid manager...");
                        Console.Clear();
                        garden.DisplayGardenManage(forecast.Length > 0 ? forecast[0] : null);
                        break;
                    case "4":
                        ShowCareAdvisor(forecast, garden, history);
                        break;
                    case "5":
                        FrostCalculator.Display(history, forecast);
                        break;
                    case "6":
                        CompanionPlanting.Display(garden);
                        ConsoleUI.WaitForKey();
                        break;
                    case "7":
                        MoonPhaseCalculator.DisplayLunarGuide();
                        break;
                    case "8":
                        new WeatherComparison(forecast, history).Display();
                        break;
                    case "9":
                        journal.Display(garden);
                        break;
                    case "10":
                        BrowsePlantProfiles(advisor);
                        break;
                    case "0":
                        Console.Clear();
                        ConsoleUI.Header("GOODBYE!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n  Happy growing!");
                        Console.ResetColor();
                        Console.WriteLine();
                        return;
                    default:
                        ConsoleUI.Warning("Invalid option. Press any key to continue.");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        // ── Menu Rendering ────────────────────────────────────────────

        static void DrawMainMenu(string location, WeatherDay[] forecast)
        {
            int width = 60;
            string border = new string('═', width);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║{"  FARM & GARDEN PLANNER  v2.0",-60}║");
            Console.WriteLine($"║{"  Powered by NOAA | api.weather.gov",-60}║");
            Console.WriteLine($"╠{border}╣");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"║{"  Location: " + location + "   " + DateTime.Now.ToString("ddd MM/dd  HH:mm"),-60}║");
            if (forecast.Length > 0)
            {
                WeatherDay today = forecast[0];
                string wx = $"  Today: {today.HighTemp:F0}°F / {today.LowTemp:F0}°F  {today.WindSpeed:F0}mph {today.WindDirection}  {today.Description}";
                Console.WriteLine($"║{wx.PadRight(60)}║");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"╠{border}╣");
            Console.ResetColor();

            var items = new (string key, string label, string? tag)[]
            {
                (" 1", "Weather Dashboard & 7-Day Forecast",      null),
                (" 2", "Plant Recommendations for Your Area",     null),
                (" 3", "View & Manage My Garden",                 null),
                (" 4", "Garden Care Advisor (Water / Plant?)",    null),
                (" 5", "Frost Date Calculator",                   null),
                (" 6", "Companion Planting Guide",                null),
                (" 7", "Moon Phase Planting Guide",               " [WOW]"),
                (" 8", "Weather vs. Historical Comparison",       " [WOW]"),
                (" 9", "Garden Journal & Harvest Tracker",        " [WOW]"),
                ("10", "Browse All Plant Profiles (ASCII Art)",   null),
                (" 0", "Exit",                                    null),
            };

            foreach (var (key, label, tag) in items)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"║  [{key}]  ");
                Console.ResetColor();
                Console.Write($"{label,-40}");
                if (tag != null)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(tag);
                    Console.ResetColor();
                    Console.Write(new string(' ', Math.Max(0, 7 - tag.Length)));
                }
                else
                    Console.Write("       ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("║");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"╚{border}╝");
            Console.ResetColor();
        }

        // ── Garden Care Advisor ───────────────────────────────────────

        static void ShowCareAdvisor(WeatherDay[] forecast, GardenManager garden, HistoricalStats[] history)
        {
            ConsoleUI.Header("GARDEN CARE ADVISOR");

            if (forecast.Length == 0)
            {
                ConsoleUI.Warning("No forecast data available.");
                ConsoleUI.WaitForKey();
                return;
            }

            WeatherDay today = forecast[0];

            ConsoleUI.Section("Should I Water Today?");
            bool willRain = today.PrecipChance >= 50;
            bool rainSoon = forecast.Take(2).Any(d => d.PrecipChance >= 60);

            if (willRain)
                ConsoleUI.Warning($"SKIP watering — {today.PrecipChance:F0}% rain chance today. Let nature do it!");
            else if (rainSoon)
                ConsoleUI.Warning("HOLD OFF — rain likely soon. Check soil moisture before watering.");
            else
            {
                ConsoleUI.Success("YES — water your garden! No rain expected. Water deeply at the base.");
                Console.WriteLine("  Best time: Early morning (before 9am) to reduce evaporation.");
            }

            ConsoleUI.Section("Should I Plant Today?");
            bool goodTemp = today.HighTemp >= 55 && today.LowTemp >= 40;
            bool notWindy = today.WindSpeed <= 15;
            bool notRainy = today.PrecipChance <= 40;

            if (goodTemp && notWindy && notRainy)
            {
                ConsoleUI.Success("Great day to plant! Temps and conditions are favorable.");
                var plantNow = PlantDatabase.All
                    .Where(p => p.PlantingMonths.Contains(DateTime.Now.Month)
                        && today.HighTemp >= p.MinTempF
                        && today.LowTemp >= p.MinTempF - 10)
                    .Take(5).ToArray();

                if (plantNow.Length > 0)
                {
                    Console.WriteLine("\n  Best plants for today's conditions:");
                    foreach (var p in plantNow)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"    {p.Emoji} {p.Name,-20} {p.Category}");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                if (!goodTemp) ConsoleUI.Warning($"Temps too cold — Low of {today.LowTemp:F0}°F. Wait for warmer nights.");
                if (!notWindy) ConsoleUI.Warning($"Too windy ({today.WindSpeed:F0} mph). Wind dries seedlings out quickly.");
                if (!notRainy) ConsoleUI.Warning($"Rain expected ({today.PrecipChance:F0}%). Hold off — waterlogged soil harms roots.");
            }

            ConsoleUI.Section("Pest & Disease Risk Today");
            if (today.Humidity > 75)
                ConsoleUI.Warning($"High humidity ({today.Humidity}%). Watch for fungal diseases — improve air circulation.");
            else
                ConsoleUI.Success($"Humidity {today.Humidity}% — low fungal risk today.");
            if (today.HighTemp > 85)
                ConsoleUI.Warning("Extreme heat! Spider mites thrive. Check undersides of leaves.");

            ConsoleUI.Section("This Week's Care Tasks");
            for (int i = 0; i < Math.Min(7, forecast.Length); i++)
            {
                WeatherDay day = forecast[i];
                var tasks = new List<string>();
                if (day.PrecipChance < 30 && day.HighTemp > 60) tasks.Add("Water");
                if (day.LowTemp <= 36) tasks.Add("FROST COVER");
                if (day.HighTemp > 85) tasks.Add("Mulch/Shade");
                if (day.WindSpeed > 20) tasks.Add("Stake plants");
                if (tasks.Count == 0) tasks.Add("Observe & enjoy");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"  {day.DayName,-11}");
                Console.ResetColor();

                foreach (string task in tasks)
                {
                    ConsoleColor c = task.Contains("FROST") ? ConsoleColor.Red :
                                    task == "Water" ? ConsoleColor.Cyan : ConsoleColor.Yellow;
                    Console.ForegroundColor = c;
                    Console.Write($"[{task}] ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            ConsoleUI.WaitForKey();
        }

        // ── Browse Plant Profiles ─────────────────────────────────────

        static void BrowsePlantProfiles(PlantAdvisor advisor)
        {
            ConsoleUI.Header("PLANT PROFILE BROWSER");

            var allPlants = PlantDatabase.All;
            Console.WriteLine($"\n  {allPlants.Length} plants in database\n");

            foreach (string cat in allPlants.Select(p => p.Category).Distinct())
            {
                ConsoleUI.Section(cat + "s");
                foreach (Plant p in allPlants.Where(x => x.Category == cat))
                {
                    Console.Write($"  {p.Emoji} {p.Name,-22}");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"  Zone {p.MinZone}+  {p.DaysToHarvest}d  {p.WaterNeeds} water  {p.SunNeeds}");
                    Console.ResetColor();
                }
            }

            ConsoleUI.Prompt("\n  Enter plant name for full profile (or ENTER to go back)");
            string input = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrEmpty(input))
            {
                Plant? p = PlantDatabase.Find(input);
                if (p != null) { Console.Clear(); advisor.DisplayPlantDetails(p); ConsoleUI.WaitForKey(); }
                else ConsoleUI.Warning($"Plant '{input}' not found.");
            }

            ConsoleUI.WaitForKey();
        }
    }
}

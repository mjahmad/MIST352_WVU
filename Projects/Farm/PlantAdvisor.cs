namespace Project_2
{
    internal class PlantAdvisor
    {
        private readonly HistoricalStats[] _history;
        private readonly WeatherDay[] _forecast;

        public PlantAdvisor(HistoricalStats[] history, WeatherDay[] forecast)
        {
            _history = history;
            _forecast = forecast;
        }

        public int GetHardinessZone()
        {
            double minTemp = _history.Length > 0 && _history.Any(h => h.MinTemp < 999)
                ? _history.Min(h => h.MinTemp < 999 ? h.MinTemp : 999)
                : 20;

            return minTemp switch
            {
                <= -40 => 3,
                <= -30 => 3,
                <= -20 => 4,
                <= -10 => 5,
                <= 0   => 6,
                <= 10  => 7,
                <= 20  => 8,
                <= 30  => 9,
                _      => 10,
            };
        }

        public Plant[] GetRecommendedPlants()
        {
            int zone = GetHardinessZone();
            int month = DateTime.Now.Month;

            return PlantDatabase.All
                .Where(p => p.MinZone <= zone + 1
                    && p.PlantingMonths.Contains(month)
                    && WeatherSuitsPlant(p))
                .OrderBy(p => p.Category)
                .ToArray();
        }

        public Plant[] GetAllSuitablePlants()
        {
            int zone = GetHardinessZone();
            return PlantDatabase.All.Where(p => p.MinZone <= zone + 1).ToArray();
        }

        private bool WeatherSuitsPlant(Plant p)
        {
            double avgHigh = _forecast.Length > 0 ? _forecast.Average(d => d.HighTemp) : 65;
            double avgLow  = _forecast.Length > 0 ? _forecast.Average(d => d.LowTemp)  : 50;
            return avgHigh <= p.MaxTempF && avgLow >= p.MinTempF - 10;
        }

        public void DisplayRecommendations()
        {
            ConsoleUI.Header("PLANT RECOMMENDATIONS FOR YOUR AREA");

            int zone = GetHardinessZone();
            ConsoleUI.Info("USDA Hardiness Zone:", $"Zone {zone}");
            ConsoleUI.Info("Current Month:", DateTime.Now.ToString("MMMM yyyy"));

            if (_history.Length > 0)
            {
                var thisMonth = _history.FirstOrDefault(h => h.Month == DateTime.Now.Month);
                if (thisMonth != null && thisMonth.CountHighTemp > 0)
                {
                    ConsoleUI.Info("Avg High (last year):", $"{thisMonth.AvgHighTemp:F1}°F");
                    ConsoleUI.Info("Avg Low (last year):",  $"{thisMonth.AvgLowTemp:F1}°F");
                    ConsoleUI.Info("Avg Precip:",           $"{thisMonth.TotalPrecip:F2}\" / month");
                }
            }

            ConsoleUI.Section("Plants to Start NOW This Month");
            Plant[] nowPlants = GetRecommendedPlants();

            if (nowPlants.Length == 0)
            {
                ConsoleUI.Warning("No ideal planting candidates for this exact month.");
                Console.WriteLine("  Try the full calendar below for nearby windows.");
            }
            else
            {
                foreach (Plant p in nowPlants)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\n  {p.Emoji} {p.Name,-20}");
                    Console.ResetColor();
                    Console.WriteLine($"[{p.Category}]  {p.DaysToHarvest} days to harvest");
                    Console.WriteLine($"     {p.Description}");
                    Console.WriteLine($"     Water: {p.WaterNeeds,-6}  Sun: {p.SunNeeds}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"     TIP: {p.PlantingTip}");
                    Console.ResetColor();
                }
            }

            ConsoleUI.Section("Full Season Calendar (All Suitable Plants)");
            string[] months = ["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"];
            Console.Write($"  {"Plant",-20} {"Zone",-5} ");
            foreach (string m in months) Console.Write($" {m}");
            Console.WriteLine();
            ConsoleUI.Divider();

            foreach (Plant p in GetAllSuitablePlants())
            {
                Console.Write($"  {p.Name,-20} Zn {p.MinZone,-2} ");
                for (int m = 1; m <= 12; m++)
                {
                    if (p.PlantingMonths.Contains(m))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" P  ");
                    }
                    else if (p.HarvestMonths.Contains(m))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" H  ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" .  ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  Legend:  P = Plant   H = Harvest   . = Off season");
            Console.ResetColor();

            ConsoleUI.WaitForKey();
        }

        public void DisplayPlantDetails(Plant p)
        {
            ConsoleUI.Header($"PLANT PROFILE: {p.Name.ToUpper()}");
            ConsoleUI.Section("ASCII Art");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string line in p.AsciiArt)
                Console.WriteLine($"  {line}");
            Console.ResetColor();

            ConsoleUI.Section("Details");
            ConsoleUI.Info("Category:", p.Category);
            ConsoleUI.Info("Hardiness Zone:", $"Zone {p.MinZone}+");
            ConsoleUI.Info("Temperature Range:", $"{p.MinTempF}°F – {p.MaxTempF}°F");
            ConsoleUI.Info("Water Needs:", p.WaterNeeds);
            ConsoleUI.Info("Sun Needs:", p.SunNeeds);
            ConsoleUI.Info("Days to Harvest:", $"{p.DaysToHarvest} days");

            string plantingStr = string.Join(", ",
                p.PlantingMonths.Select(m => new DateTime(2000, m, 1).ToString("MMM")));
            ConsoleUI.Info("Plant In:", plantingStr);

            string harvestStr = string.Join(", ",
                p.HarvestMonths.Select(m => new DateTime(2000, m, 1).ToString("MMM")));
            ConsoleUI.Info("Harvest In:", harvestStr);

            ConsoleUI.Section("Growing Tips");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"  {p.PlantingTip}");
            Console.ResetColor();
            Console.WriteLine($"\n  {p.Description}");

            if (p.CompanionPlants.Length > 0)
            {
                ConsoleUI.Section("Companion Plants (grow these together!)");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  " + string.Join("  |  ", p.CompanionPlants));
                Console.ResetColor();
            }

            if (p.AvoidPlants.Length > 0)
            {
                ConsoleUI.Section("Avoid Planting Near");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  " + string.Join("  |  ", p.AvoidPlants));
                Console.ResetColor();
            }
        }
    }
}

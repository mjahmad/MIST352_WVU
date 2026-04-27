namespace Project_2
{
    internal static class FrostCalculator
    {
        public static void Display(HistoricalStats[] history, WeatherDay[] forecast)
        {
            ConsoleUI.Header("FROST DATE CALCULATOR");

            if (history.Length == 0 || history.All(h => h.CountLowTemp == 0))
            {
                ConsoleUI.Warning("Historical data not loaded. Frost dates cannot be calculated.");
                ConsoleUI.WaitForKey();
                return;
            }

            // Find last spring frost and first fall frost from historical data
            DateTime? lastSpringFrost = null;
            DateTime? firstFallFrost  = null;

            foreach (var h in history)
            {
                if (h.LastSpringFrost.HasValue &&
                    (lastSpringFrost == null || h.LastSpringFrost > lastSpringFrost))
                    lastSpringFrost = h.LastSpringFrost;

                if (h.FirstFallFrost.HasValue &&
                    (firstFallFrost == null || h.FirstFallFrost < firstFallFrost))
                    firstFallFrost = h.FirstFallFrost;
            }

            ConsoleUI.Section("Frost Dates (Based on Last Year's NOAA Data)");

            if (lastSpringFrost.HasValue)
            {
                Console.Write("  Last Spring Frost:   ");
                ConsoleUI.Colored($"{lastSpringFrost:MMMM dd}", ConsoleColor.Cyan);
                Console.WriteLine();
                Console.WriteLine("  (Do not plant frost-sensitive crops before this date!)");
            }
            else
            {
                ConsoleUI.Info("Last Spring Frost:", "Not enough data");
            }

            Console.WriteLine();

            if (firstFallFrost.HasValue)
            {
                Console.Write("  First Fall Frost:    ");
                ConsoleUI.Colored($"{firstFallFrost:MMMM dd}", ConsoleColor.DarkCyan);
                Console.WriteLine();
                Console.WriteLine("  (Harvest or protect crops before this date!)");
            }
            else
            {
                ConsoleUI.Info("First Fall Frost:", "Not enough data");
            }

            if (lastSpringFrost.HasValue && firstFallFrost.HasValue)
            {
                int season = (int)(firstFallFrost.Value - lastSpringFrost.Value).TotalDays;
                Console.WriteLine();
                Console.Write("  Growing Season:      ");
                ConsoleUI.Colored($"{season} days", ConsoleColor.Green);
                Console.WriteLine($"  ({lastSpringFrost:MMM dd} – {firstFallFrost:MMM dd})");

                DateTime today = DateTime.Now;
                if (today > lastSpringFrost.Value && today < firstFallFrost.Value)
                {
                    int daysIn = (int)(today - lastSpringFrost.Value).TotalDays;
                    int daysLeft = (int)(firstFallFrost.Value - today).TotalDays;
                    Console.WriteLine();
                    ConsoleUI.Success($"You are IN the growing season! Day {daysIn} of {season}.");
                    ConsoleUI.Info("Days until first fall frost:", $"{daysLeft} days — plan harvests accordingly.");
                }
                else if (today <= lastSpringFrost.Value)
                {
                    int daysUntil = (int)(lastSpringFrost.Value - today).TotalDays;
                    ConsoleUI.Warning($"Growing season starts in ~{daysUntil} days. Hold off on tender plants.");
                }
                else
                {
                    ConsoleUI.Warning("Growing season has ended. Time for cool-season crops and planning.");
                }
            }

            ConsoleUI.Section("Monthly Frost Risk");
            Console.WriteLine($"  {"Month",-12} {"Frost Days",-12} {"Min Temp",-12} Risk Level");
            ConsoleUI.Divider();

            foreach (var h in history)
            {
                if (h.CountLowTemp == 0) continue;

                string risk = h.FrostDays switch
                {
                    0  => "None",
                    <= 3 => "Low",
                    <= 10 => "Moderate",
                    <= 20 => "High",
                    _ => "Very High",
                };

                ConsoleColor riskColor = risk switch
                {
                    "None"      => ConsoleColor.Green,
                    "Low"       => ConsoleColor.Yellow,
                    "Moderate"  => ConsoleColor.DarkYellow,
                    "High"      => ConsoleColor.Red,
                    _           => ConsoleColor.DarkRed,
                };

                bool isCurrent = h.Month == DateTime.Now.Month;
                Console.ForegroundColor = isCurrent ? ConsoleColor.Cyan : ConsoleColor.Gray;
                Console.Write($"  {(isCurrent ? ">>" : "  ")}{h.MonthName,-10}  {h.FrostDays,6} days    ");
                string minTempStr = h.MinTemp < 999 ? $"{h.MinTemp:F1}°F" : " N/A";
                Console.Write($"{minTempStr,-12}");
                Console.ResetColor();
                Console.ForegroundColor = riskColor;
                Console.WriteLine(risk);
                Console.ResetColor();
            }

            ConsoleUI.Section("Frost Protection Tips");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  * Frost cloth / row covers protect to 28°F (-2°C)");
            Console.WriteLine("  * Water plants before expected frost — wet soil holds heat");
            Console.WriteLine("  * Move potted plants indoors overnight when temps drop below 40°F");
            Console.WriteLine("  * Mulch heavily around root crops to insulate from cold");
            Console.WriteLine("  * Cold frames extend the season by 4-6 weeks each end");
            Console.ResetColor();

            // Check upcoming forecast for frost risk
            var frostNights = forecast.Where(d => d.LowTemp <= 36).ToList();
            if (frostNights.Count > 0)
            {
                ConsoleUI.Section("ALERT: Frost Risk in Current Forecast");
                foreach (var n in frostNights)
                {
                    ConsoleUI.Warning($"{n.DayName} night: Low of {n.LowTemp:F0}°F — protect tender plants!");
                }
            }
            else
            {
                ConsoleUI.Success("No frost risk in the current 7-day forecast.");
            }

            ConsoleUI.WaitForKey();
        }
    }
}

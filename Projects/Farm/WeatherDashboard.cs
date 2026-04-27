namespace Project_2
{
    internal static class WeatherDashboard
    {
        public static void Display(WeatherDay[] forecast, string location)
        {
            ConsoleUI.Header("WEATHER DASHBOARD");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  Location: {location}   Updated: {DateTime.Now:MM/dd/yyyy HH:mm}");
            Console.ResetColor();

            if (forecast.Length == 0)
            {
                ConsoleUI.Warning("No forecast data available.");
                ConsoleUI.WaitForKey();
                return;
            }

            // Today's detailed card
            WeatherDay today = forecast[0];
            ConsoleUI.Section("Today");
            DrawWeatherCard(today, large: true);

            // Mini temperature bar chart
            ConsoleUI.Section("7-Day Temperature Overview");
            double maxTemp = forecast.Max(d => d.HighTemp);
            double minTemp = forecast.Min(d => d.LowTemp);

            foreach (WeatherDay day in forecast)
            {
                Console.Write($"  {day.DayName[..3],-5}");

                // Low
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {day.LowTemp,3:F0}°  ");

                // Bar scaled to range
                int barLen = (int)Math.Round((day.HighTemp - minTemp) / (maxTemp - minTemp + 1) * 24);
                int lowLen = (int)Math.Round((day.LowTemp - minTemp) / (maxTemp - minTemp + 1) * 24);

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(new string('░', lowLen));
                Console.ForegroundColor = GetTempColor(day.HighTemp);
                Console.Write(new string('█', Math.Max(0, barLen - lowLen)));
                Console.ResetColor();
                Console.Write(new string(' ', Math.Max(0, 24 - barLen)));

                Console.ForegroundColor = GetTempColor(day.HighTemp);
                Console.Write($" {day.HighTemp,3:F0}°F  ");
                Console.ResetColor();

                // Rain indicator
                if (day.PrecipChance >= 60)
                    ConsoleUI.Colored("[RAIN] ", ConsoleColor.Blue);
                else if (day.PrecipChance >= 30)
                    ConsoleUI.Colored("[SHWR] ", ConsoleColor.DarkCyan);
                else
                    ConsoleUI.Colored("[SUN]  ", ConsoleColor.Yellow);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(day.Description);
                Console.ResetColor();
            }

            // 7-day grid
            ConsoleUI.Section("Full 7-Day Forecast");
            Console.WriteLine($"  {"Day",-12} {"Hi":>4} {"Lo":>4} {"Wind",-12} {"Rain%":>6} {"Humidity":>9}  Conditions");
            ConsoleUI.Divider();

            foreach (WeatherDay day in forecast)
            {
                bool isToday = day.Date == forecast[0].Date;
                Console.ForegroundColor = isToday ? ConsoleColor.Cyan : ConsoleColor.Gray;

                Console.Write($"  {(isToday ? ">>" : "  ")}{day.DayName,-10}");
                Console.ForegroundColor = GetTempColor(day.HighTemp);
                Console.Write($"{day.HighTemp,4:F0}°");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{day.LowTemp,4:F0}°");
                Console.ResetColor();
                Console.Write($"  {day.WindSpeed,4:F0}mph {day.WindDirection,-5}");

                Console.ForegroundColor = day.PrecipChance >= 50 ? ConsoleColor.Blue : ConsoleColor.Gray;
                Console.Write($"{day.PrecipChance,6:F0}%");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"  {day.Humidity,7}%  ");
                Console.ResetColor();

                Console.WriteLine(day.Description);
            }

            // Gardening summary row
            ConsoleUI.Section("Garden-at-a-Glance (This Week)");
            double avgHigh = forecast.Average(d => d.HighTemp);
            double avgLow  = forecast.Average(d => d.LowTemp);
            double totalRain = forecast.Average(d => d.PrecipChance);
            int frostRisk  = forecast.Count(d => d.LowTemp <= 36);

            ConsoleUI.Info("Avg High:", $"{avgHigh:F1}°F");
            ConsoleUI.Info("Avg Low:", $"{avgLow:F1}°F");
            ConsoleUI.Info("Rain Chance:", $"{totalRain:F0}% avg this week");
            ConsoleUI.Info("Frost Risk Nights:", frostRisk == 0 ? "None" : $"{frostRisk} night(s) — COVER PLANTS!");

            if (frostRisk > 0)
                ConsoleUI.Warning("Frost-risk nights detected! Protect tender plants with fabric or move indoors.");

            if (avgHigh > 85)
                ConsoleUI.Warning("Very warm week ahead. Water deeply and mulch to retain moisture.");
            else if (avgHigh > 70)
                ConsoleUI.Success("Warm growing conditions! Great week for tomatoes, peppers, and cucumbers.");
            else if (avgHigh > 55)
                ConsoleUI.Success("Cool-mild week. Ideal for lettuce, spinach, kale, and broccoli.");
            else
                ConsoleUI.Warning("Cool week ahead. Hold off on planting warm-season crops.");

            ConsoleUI.WaitForKey();
        }

        private static void DrawWeatherCard(WeatherDay day, bool large)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  ┌────────────────────────────────────────┐");
            Console.WriteLine($"  │  {day.DayName,-12} {day.Date,-26}│");
            Console.WriteLine($"  │                                        │");

            Console.Write("  │  ");
            Console.ForegroundColor = GetTempColor(day.HighTemp);
            Console.Write($"High: {day.HighTemp:F0}°F");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"   Low: {day.LowTemp:F0}°F");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("              │");

            Console.Write("  │  ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Wind: {day.WindSpeed:F0} mph {day.WindDirection,-5}");
            Console.Write($"  Humidity: {day.Humidity}%");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    │");

            Console.Write("  │  ");
            Console.ForegroundColor = day.PrecipChance >= 50 ? ConsoleColor.Blue : ConsoleColor.DarkGray;
            Console.Write($"Rain Chance: {day.PrecipChance:F0}%");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                     │");

            Console.Write("  │  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{day.Description,-38}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("│");

            Console.WriteLine($"  └────────────────────────────────────────┘");
            Console.ResetColor();

            if (large && !string.IsNullOrEmpty(day.DetailedForecast))
            {
                // Word-wrap at 54 chars
                string detail = day.DetailedForecast;
                int w = 54;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                for (int i = 0; i < detail.Length; i += w)
                    Console.WriteLine("  " + detail.Substring(i, Math.Min(w, detail.Length - i)));
                Console.ResetColor();
            }
        }

        private static ConsoleColor GetTempColor(double temp) => temp switch
        {
            >= 90 => ConsoleColor.Red,
            >= 80 => ConsoleColor.DarkRed,
            >= 70 => ConsoleColor.Yellow,
            >= 60 => ConsoleColor.Green,
            >= 50 => ConsoleColor.Cyan,
            >= 40 => ConsoleColor.Blue,
            _     => ConsoleColor.DarkBlue,
        };
    }
}

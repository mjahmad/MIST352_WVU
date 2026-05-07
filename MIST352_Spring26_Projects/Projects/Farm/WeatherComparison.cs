namespace Project_2
{
    // WOW FEATURE 2: Historical Weather vs. Current Forecast
    // Compares this week's forecast against historical NOAA averages from last year.
    // Shows whether it's hotter, colder, wetter, or drier than usual.
    internal class WeatherComparison
    {
        private readonly WeatherDay[] _forecast;
        private readonly HistoricalStats[] _history;

        public WeatherComparison(WeatherDay[] forecast, HistoricalStats[] history)
        {
            _forecast = forecast;
            _history = history;
        }

        public void Display()
        {
            ConsoleUI.Header("WEATHER vs. HISTORICAL COMPARISON");

            int month = DateTime.Now.Month;
            HistoricalStats? hist = _history.FirstOrDefault(h => h.Month == month);

            if (hist == null || hist.CountHighTemp == 0)
            {
                ConsoleUI.Warning("Historical data not yet loaded. Run from main menu to fetch it.");
                ConsoleUI.WaitForKey();
                return;
            }

            double forecastAvgHigh = _forecast.Length > 0 ? _forecast.Average(d => d.HighTemp) : 0;
            double forecastAvgLow  = _forecast.Length > 0 ? _forecast.Average(d => d.LowTemp)  : 0;
            double forecastAvgPrecip = _forecast.Length > 0 ? _forecast.Average(d => d.PrecipChance) : 0;

            double histAvgHigh = hist.AvgHighTemp;
            double histAvgLow  = hist.AvgLowTemp;

            ConsoleUI.Section($"This Week vs. Historical {hist.MonthName} Averages");

            PrintComparison("Avg High Temp",
                $"{forecastAvgHigh:F1}°F", $"{histAvgHigh:F1}°F",
                forecastAvgHigh - histAvgHigh, "°F", true);

            PrintComparison("Avg Low Temp",
                $"{forecastAvgLow:F1}°F", $"{histAvgLow:F1}°F",
                forecastAvgLow - histAvgLow, "°F", true);

            PrintComparison("Avg Rain Chance",
                $"{forecastAvgPrecip:F0}%", $"{(hist.PrecipDays > 0 ? (double)hist.PrecipDays / 30 * 100 : 30):F0}%",
                forecastAvgPrecip - (hist.PrecipDays > 0 ? (double)hist.PrecipDays / 30 * 100 : 30),
                "%", false);

            ConsoleUI.Section("7-Day Temperature Bar Chart vs. Historical Average");
            Console.WriteLine($"  Historical avg high for {hist.MonthName}: {histAvgHigh:F1}°F");
            Console.WriteLine($"  Historical avg low  for {hist.MonthName}: {histAvgLow:F1}°F\n");

            foreach (WeatherDay day in _forecast)
            {
                double diffHigh = day.HighTemp - histAvgHigh;
                double diffLow  = day.LowTemp - histAvgLow;

                ConsoleColor hColor = diffHigh >= 0 ? ConsoleColor.Red : ConsoleColor.Cyan;
                ConsoleColor lColor = diffLow  >= 0 ? ConsoleColor.DarkRed : ConsoleColor.Blue;

                Console.Write($"  {day.DayName,-10}  Hi:{day.HighTemp,3:F0}°F ");
                Console.ForegroundColor = hColor;
                Console.Write($"({(diffHigh >= 0 ? "+" : "")}{diffHigh:F1}°F)");
                Console.ResetColor();
                Console.Write($"  Lo:{day.LowTemp,3:F0}°F ");
                Console.ForegroundColor = lColor;
                Console.WriteLine($"({(diffLow >= 0 ? "+" : "")}{diffLow:F1}°F)");
                Console.ResetColor();
            }

            ConsoleUI.Section("Monthly Historical Summary");
            Console.WriteLine($"  {"Month",-12} {"Avg High",-12} {"Avg Low",-12} {"Precip\"",8} {"Snow\"",7} {"Frost Days",10}");
            ConsoleUI.Divider();

            foreach (var h in _history)
            {
                if (h.CountHighTemp == 0) continue;
                bool isCurrentMonth = h.Month == month;
                Console.ForegroundColor = isCurrentMonth ? ConsoleColor.Cyan : ConsoleColor.Gray;
                Console.Write($"  {(isCurrentMonth ? ">>" : "  ")}{h.MonthName,-10}  ");
                Console.Write($"{h.AvgHighTemp,7:F1}°F   {h.AvgLowTemp,7:F1}°F   ");
                Console.Write($"{h.TotalPrecip,7:F2}\"  {h.TotalSnow,6:F2}\"  {h.FrostDays,9}");
                Console.ResetColor();
                Console.WriteLine();
            }

            ConsoleUI.Section("Climate Insights");
            GenerateInsights(hist, forecastAvgHigh, forecastAvgLow);

            ConsoleUI.WaitForKey();
        }

        private static void PrintComparison(string label, string current, string historical,
            double diff, string unit, bool higherIsBetter)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"  {label,-20}");
            Console.ResetColor();
            Console.Write($"  Now: {current,-12}  Hist: {historical,-12}  Change: ");

            if (Math.Abs(diff) < 1)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Normal range");
            }
            else
            {
                bool isGood = higherIsBetter ? diff > 0 : diff < 0;
                Console.ForegroundColor = isGood ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"{(diff > 0 ? "+" : "")}{diff:F1}{unit} {(diff > 0 ? "ABOVE" : "BELOW")} normal");
            }
            Console.ResetColor();
        }

        private static void GenerateInsights(HistoricalStats hist, double forecastHigh, double forecastLow)
        {
            double highDiff = forecastHigh - hist.AvgHighTemp;
            double lowDiff  = forecastLow  - hist.AvgLowTemp;

            if (highDiff > 5)
            {
                ConsoleUI.Warning($"It's running {highDiff:F0}°F HOTTER than normal this {hist.MonthName}.");
                Console.WriteLine("  Consider shade cloth for sensitive plants and extra watering.");
            }
            else if (highDiff < -5)
            {
                ConsoleUI.Warning($"It's running {Math.Abs(highDiff):F0}°F COOLER than normal this {hist.MonthName}.");
                Console.WriteLine("  Heat-loving plants like tomatoes and peppers may be slow.");
            }
            else
            {
                ConsoleUI.Success("Temperatures are near historical normal — great growing conditions!");
            }

            if (hist.FrostDays > 0 && lowDiff < -3)
                ConsoleUI.Warning("Colder-than-usual nights increase frost risk. Monitor forecasts closely.");

            if (hist.TotalPrecip > 4)
                Console.WriteLine($"  {hist.MonthName} is historically a WET month ({hist.TotalPrecip:F1}\" avg). Monitor for root rot.");
            else if (hist.TotalPrecip < 2)
                Console.WriteLine($"  {hist.MonthName} is historically DRY ({hist.TotalPrecip:F1}\" avg). Plan to irrigate.");
        }
    }
}

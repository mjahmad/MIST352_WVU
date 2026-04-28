using System;

namespace Project_1
{
    /// <summary>
    /// Selects the best bonfire night from a 7-day forecast.
    /// Also provides time window suggestions.
    /// </summary>
    internal class BonfirePlanner
    {
        private WeatherDay[] _forecast;

        public BonfirePlanner(WeatherDay[] forecast)
        {
            _forecast = forecast;
        }

        /// <summary>Returns the best night from the forecast, or null if none qualify.</summary>
        public WeatherDay FindBestNight()
        {
            FireSafety          safety     = new FireSafety();
            FireScoreCalculator calculator = new FireScoreCalculator();

            WeatherDay bestDay   = null;
            int        bestScore = -1;

            foreach (WeatherDay day in _forecast)
            {
                if (day == null) continue;

                int score = calculator.Calculate(day);

                if (day.IsGoodForFire() && safety.IsSafe(day) && score > bestScore)
                {
                    bestScore = score;
                    bestDay   = day;
                }
            }
            return bestDay;
        }

        /// <summary>Returns seating suggestion (delegates to SeatingAdvisor).</summary>
        public string SuggestSeating(string windDirection)
        {
            SeatingAdvisor advisor = new SeatingAdvisor();
            return advisor.GetBestDirection(windDirection);
        }

        /// <summary>Displays the best bonfire time window panel.</summary>
        public void DisplayBestTime()
        {
            ConsoleUI.Header("BEST BONFIRE TIME FINDER");

            WeatherDay best = FindBestNight();

            if (best == null)
            {
                ConsoleUI.Section("Forecast Summary");
                ConsoleUI.Warn("No ideal bonfire nights found in the 7-day forecast.");
                ConsoleUI.Info("Consider waiting for clearer, less windy conditions.");
                ConsoleUI.SectionEnd();
                return;
            }

            FireScoreCalculator calc = new FireScoreCalculator();
            calc.Calculate(best);

            ConsoleUI.Section("Best Night Found");
            ConsoleUI.Row("Night",        best._name);
            ConsoleUI.Row("Date",         best._date);
            ConsoleUI.Row("Temperature",  $"{best._temperature:F0}°F");
            ConsoleUI.Row("Wind",         $"{best._windspeed:F1} mph from {best._winddirection}");
            ConsoleUI.Row("Rain Chance",  $"{best._rainchance:F0}%");
            ConsoleUI.Row("Fire Score",   $"{calc.TotalScore}/100");
            ConsoleUI.SectionEnd();

            ConsoleUI.Section("Recommended Bonfire Window");
            DetermineTimeWindow(best, calc.TotalScore);
            ConsoleUI.SectionEnd();

            ConsoleUI.Section("All 7-Night Forecast");
            DisplayForecastTable();
            ConsoleUI.SectionEnd();
        }

        /// <summary>Displays a compact 7-night forecast table.</summary>
        public void DisplayForecastTable()
        {
            FireScoreCalculator calc   = new FireScoreCalculator();
            FireSafety          safety = new FireSafety();

            ConsoleUI.SetDim();
            Console.WriteLine("  Night              Temp    Wind    Rain%  Score  Safe?");
            Console.WriteLine("  " + new string('─', 54));
            ConsoleUI.Reset();

            foreach (WeatherDay day in _forecast)
            {
                if (day == null) continue;

                int  score = calc.Calculate(day);
                bool safe  = safety.IsSafe(day);

                ConsoleColor lineColor = score >= 70  ? ConsoleColor.Green
                                       : score >= 45  ? ConsoleColor.Yellow
                                       :                ConsoleColor.Red;

                Console.ForegroundColor = lineColor;
                string name = (day._name ?? "Night").PadRight(18);
                Console.Write($"  {name}");
                Console.Write($"{day._temperature,5:F0}°F  ");
                Console.Write($"{day._windspeed,4:F0}mph  ");
                Console.Write($"{day._rainchance,4:F0}%   ");
                Console.Write($"{score,4}/100  ");
                Console.WriteLine(safe ? "  YES" : "  NO ");
                ConsoleUI.Reset();
            }
        }

        // ── private helpers ───────────────────────────────────────────────

        private void DetermineTimeWindow(WeatherDay day, int score)
        {
            string sunset = string.IsNullOrEmpty(day._sunsettime) ? "8:00 PM" : day._sunsettime;

            ConsoleUI.Info($"Sunset: {sunset}");
            Console.WriteLine();

            if (score >= 80)
            {
                ConsoleUI.Good("Prime window:    7:30 PM – 11:00 PM");
                ConsoleUI.Good("Lighting time:   30 min after sunset");
                ConsoleUI.Info("The whole evening looks great. Fire up early!");
            }
            else if (score >= 60)
            {
                ConsoleUI.Good("Good window:     7:30 PM –  9:30 PM");
                ConsoleUI.Info("Conditions are solid for a couple of hours.");
            }
            else if (score >= 40)
            {
                ConsoleUI.Warn("Shorter window:  7:30 PM –  8:30 PM");
                ConsoleUI.Info("Conditions are marginal. Keep it brief.");
            }
            else
            {
                ConsoleUI.Warn("Conditions are not great — keep any fire small.");
                ConsoleUI.Warn("Best to wait for a better night if possible.");
            }
        }
    }
}

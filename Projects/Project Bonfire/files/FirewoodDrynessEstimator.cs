using System;

namespace Project_1
{
    /// <summary>
    /// Estimates firewood dryness based on humidity, recent rainfall,
    /// and forecast conditions.
    /// </summary>
    internal class FirewoodDrynessEstimator
    {
        private WeatherDay _tonight;
        private WeatherDay[] _forecast;

        public FirewoodDrynessEstimator(WeatherDay tonight, WeatherDay[] forecast)
        {
            _tonight  = tonight;
            _forecast = forecast ?? new WeatherDay[0];
        }

        // Returns dryness category: "Excellent", "Good", "Fair", "Poor", "Very Poor"
        public string GetDrynessRating()
        {
            int score = ComputeDrynessScore();

            if (score >= 85) return "Excellent";
            if (score >= 70) return "Good";
            if (score >= 50) return "Fair";
            if (score >= 30) return "Poor";
            return "Very Poor";
        }

        // Returns a recommendation string
        public string GetRecommendation()
        {
            string rating = GetDrynessRating();

            switch (rating)
            {
                case "Excellent":
                    return "Dry wood will light fast and burn clean tonight.";
                case "Good":
                    return "Wood should burn well. Use seasoned hardwood for best results.";
                case "Fair":
                    return "Use seasoned wood tonight — avoid freshly cut wood.";
                case "Poor":
                    return "Wood may be damp. Use dry kindling and fire starters.";
                default: // Very Poor
                    return "Wood is likely too wet to burn well. Store wood indoors overnight.";
            }
        }

        // Returns a wood type tip
        public string GetWoodTypeTip()
        {
            double humidity = _tonight._humidity;

            if (humidity < 40)
                return "Any dry hardwood works great (oak, hickory, maple).";
            if (humidity < 60)
                return "Use hardwoods stored off the ground (oak, ash, cherry).";
            if (humidity < 75)
                return "Stick to kiln-dried or store-bought firewood tonight.";
            return "Use fire starters + dry pine kindling to overcome moisture.";
        }

        /// <summary>Prints the full firewood dryness panel.</summary>
        public void Display()
        {
            ConsoleUI.Header("FIREWOOD DRYNESS CHECK");

            int    score  = ComputeDrynessScore();
            string rating = GetDrynessRating();

            ConsoleUI.Section("Dryness Assessment");
            ConsoleUI.ScoreBar("Dryness Score", score);

            Console.Write("  Rating        : ");
            ConsoleColor ratingColor = GetRatingColor(rating);
            Console.ForegroundColor = ratingColor;
            Console.WriteLine(rating);
            ConsoleUI.Reset();

            ConsoleUI.SectionEnd();

            ConsoleUI.Section("Contributing Factors");
            ConsoleUI.Row("Tonight Humidity",  $"{_tonight._humidity:F0}%");
            ConsoleUI.Row("Rain Chance",        $"{_tonight._rainchance:F0}%");
            ConsoleUI.Row("Recent Rainfall",    _tonight._rainfall > 0 ? "Yes — wood may be wet" : "None — good sign");

            // Check last few forecast days for prior rain
            int recentRainDays = CountRecentRainDays();
            if (recentRainDays > 0)
                ConsoleUI.Row("Forecast Rain Days", $"{recentRainDays} of next 5 nights");
            else
                ConsoleUI.Row("Upcoming Rain", "None in forecast — great!");

            ConsoleUI.SectionEnd();

            ConsoleUI.Section("Recommendation");
            ConsoleUI.Info(GetRecommendation());
            ConsoleUI.Info(GetWoodTypeTip());
            ConsoleUI.SectionEnd();

            ConsoleUI.Section("Pro Storage Tips");
            ConsoleUI.Good("Store wood under a tarp or in a shed.");
            ConsoleUI.Good("Stack wood off the ground on pallets or rails.");
            ConsoleUI.Good("Split wood dries faster than whole logs.");
            ConsoleUI.Good("Seasoned wood = 6+ months drying time.");
            ConsoleUI.SectionEnd();
        }

        // ── private helpers ───────────────────────────────────────────────

        private int ComputeDrynessScore()
        {
            int score = 100;

            // Humidity penalty
            if (_tonight._humidity > 80)      score -= 30;
            else if (_tonight._humidity > 70) score -= 20;
            else if (_tonight._humidity > 60) score -= 10;
            else if (_tonight._humidity > 50) score -= 5;

            // Rainfall penalty
            if (_tonight._rainfall > 0) score -= 25;

            // Rain chance penalty
            if (_tonight._rainchance > 60)      score -= 15;
            else if (_tonight._rainchance > 40) score -= 8;
            else if (_tonight._rainchance > 25) score -= 4;

            // Recent rain days
            int recentRainDays = CountRecentRainDays();
            score -= recentRainDays * 5;

            if (score < 0)   score = 0;
            if (score > 100) score = 100;

            return score;
        }

        private int CountRecentRainDays()
        {
            int count = 0;
            foreach (WeatherDay d in _forecast)
            {
                if (d != null && (d._rainfall > 0 || d._rainchance > 50))
                    count++;
            }
            return count;
        }

        private ConsoleColor GetRatingColor(string rating)
        {
            switch (rating)
            {
                case "Excellent": return ConsoleColor.Green;
                case "Good":      return ConsoleColor.Green;
                case "Fair":      return ConsoleColor.Yellow;
                case "Poor":      return ConsoleColor.Red;
                default:          return ConsoleColor.DarkRed;
            }
        }
    }
}

using System;

namespace Project_1
{
    /// <summary>
    /// Displays wind direction information, seating advice,
    /// and a terminal compass visualization.
    /// Wraps SeatingAdvisor with a full display panel.
    /// </summary>
    internal class WindAdvisor
    {
        private WeatherDay     _tonight;
        private SeatingAdvisor _seating;

        public WindAdvisor(WeatherDay tonight)
        {
            _tonight = tonight;
            _seating = new SeatingAdvisor();
        }

        /// <summary>Displays the full wind advisor panel.</summary>
        public void Display()
        {
            ConsoleUI.Header("WIND ADVISOR");

            DisplayWindStats();
            _seating.DrawCompass(_tonight._winddirection);
            DisplayWindTips();
            DisplaySmokePath();
        }

        // ── private sections ──────────────────────────────────────────────

        private void DisplayWindStats()
        {
            ConsoleUI.Section("Wind Conditions Tonight");
            ConsoleUI.Row("Speed",     $"{_tonight._windspeed:F1} mph", GetWindSpeedColor());
            ConsoleUI.Row("Direction", $"From the {ExpandDirection(_tonight._winddirection)}");
            ConsoleUI.Row("Rating",    GetWindRating(),  GetWindSpeedColor());
            ConsoleUI.SectionEnd();
        }

        private void DisplayWindTips()
        {
            ConsoleUI.Section("Seating Recommendation");

            string bestSide = _seating.GetBestDirection(_tonight._winddirection);
            ConsoleUI.Good($"Sit on the {bestSide} side of the fire.");

            Console.WriteLine();

            if (_tonight._windspeed <= 5)
            {
                ConsoleUI.Info("Light breeze — smoke will be easy to avoid tonight.");
                ConsoleUI.Info("Any seat around the fire should be comfortable.");
            }
            else if (_tonight._windspeed <= 10)
            {
                ConsoleUI.Info("Gentle wind — stay on the downwind side.");
                ConsoleUI.Info("Wind may shift occasionally — watch the smoke.");
            }
            else if (_tonight._windspeed <= 15)
            {
                ConsoleUI.Warn("Moderate wind — keep fire smaller to control smoke.");
                ConsoleUI.Warn("Stay firmly on the recommended side of the fire.");
            }
            else
            {
                ConsoleUI.Warn("Strong wind — bonfire safety is a concern tonight.");
                ConsoleUI.Warn("Keep fire small, never leave it unattended.");
                ConsoleUI.Warn("Have a water source ready at all times.");
            }

            ConsoleUI.SectionEnd();
        }

        private void DisplaySmokePath()
        {
            ConsoleUI.Section("Smoke Path Tonight");

            string dir      = _tonight._winddirection ?? "N";
            string smokeDir = _seating.GetBestDirection(dir); // opposite of sitting side

            ConsoleUI.Info($"Wind is from the {ExpandDirection(dir)}.");
            ConsoleUI.Info($"Smoke drifts toward the {GetOppositeExpanded(dir)}.");
            Console.WriteLine();

            // Show which spots are smoky vs comfortable
            ConsoleUI.SetGood();
            Console.WriteLine($"  ✓  Comfortable : {_seating.GetBestDirection(dir)} side");
            ConsoleUI.SetFire();
            Console.WriteLine($"  ✗  Smoky       : {GetOppositeExpanded(dir)} side");
            ConsoleUI.Reset();

            ConsoleUI.SectionEnd();
        }

        // ── helpers ───────────────────────────────────────────────────────

        private ConsoleColor GetWindSpeedColor()
        {
            if (_tonight._windspeed <= 7)  return ConsoleColor.Green;
            if (_tonight._windspeed <= 14) return ConsoleColor.Yellow;
            return ConsoleColor.Red;
        }

        private string GetWindRating()
        {
            double s = _tonight._windspeed;
            if (s <= 3)  return "Calm — ideal";
            if (s <= 7)  return "Light — great for a bonfire";
            if (s <= 12) return "Gentle — manageable";
            if (s <= 17) return "Moderate — be careful";
            if (s <= 22) return "Fresh — not recommended";
            return "Strong — unsafe for bonfire";
        }

        private string ExpandDirection(string dir)
        {
            if (dir == null) return "unknown direction";
            switch (dir.ToUpper().Trim())
            {
                case "N":  return "North";
                case "NE": return "Northeast";
                case "E":  return "East";
                case "SE": return "Southeast";
                case "S":  return "South";
                case "SW": return "Southwest";
                case "W":  return "West";
                case "NW": return "Northwest";
                default:   return dir;
            }
        }

        private string GetOppositeExpanded(string dir)
        {
            if (dir == null) return "opposite side";
            switch (dir.ToUpper().Trim())
            {
                case "N":  return "South";
                case "NE": return "Southwest";
                case "E":  return "West";
                case "SE": return "Northwest";
                case "S":  return "North";
                case "SW": return "Northeast";
                case "W":  return "East";
                case "NW": return "Southeast";
                default:   return "opposite";
            }
        }
    }
}

using System;

namespace Project_1
{
    /// <summary>
    /// Main summary dashboard — shows all key stats at a glance.
    /// Designed to be the first thing users see.
    /// </summary>
    internal class BonfireDashboard
    {
        private WeatherDay          _tonight;
        private FireScoreCalculator _calculator;
        private ComfortAdvisor      _comfort;
        private FireSafety          _safety;
        private SmoresMode          _smores;

        public BonfireDashboard(WeatherDay tonight)
        {
            _tonight    = tonight;
            _calculator = new FireScoreCalculator();
            _calculator.Calculate(tonight);
            _comfort  = new ComfortAdvisor(tonight);
            _safety   = new FireSafety();
            _smores   = new SmoresMode(tonight, _calculator);
        }

        /// <summary>Displays the full dashboard to the console.</summary>
        public void Display()
        {
            DrawTitleBanner();
            DrawFireArt();
            DrawCurrentConditions();
            DrawFireScore();
            DrawQuickSummary();
        }

        // ── private sections ──────────────────────────────────────────────

        private void DrawTitleBanner()
        {
            Console.Clear();

            ConsoleUI.SetFire();
            Console.WriteLine();
            Console.WriteLine("  ╔══════════════════════════════════════════════════════╗");
            Console.Write("  ║");
            ConsoleUI.SetWhite();
            Console.Write("          🔥  BONFIRE PLANNER v2.0  🔥                  ");
            ConsoleUI.SetFire();
            Console.WriteLine("║");
            Console.Write("  ║");
            ConsoleUI.SetDim();
            string dateStr = DateTime.Now.ToString("dddd, MMMM d, yyyy  h:mm tt");
            string padded  = dateStr.PadLeft((52 + dateStr.Length) / 2).PadRight(52);
            Console.Write(padded);
            ConsoleUI.SetFire();
            Console.WriteLine("║");
            Console.Write("  ║");
            ConsoleUI.SetDim();
            string loc = "Morgantown, WV  |  NOAA Live Data".PadLeft(43).PadRight(52);
            Console.Write(loc);
            ConsoleUI.SetFire();
            Console.WriteLine("║");
            Console.WriteLine("  ╚══════════════════════════════════════════════════════╝");
            ConsoleUI.Reset();
        }

        private void DrawFireArt()
        {
            ConsoleUI.SetFire();
            Console.WriteLine();
            Console.WriteLine("          (  )   (   )  )       ");
            Console.WriteLine("           ) (   )  (  (        ");
            Console.WriteLine("           ( )  (    ) )        ");
            Console.WriteLine("           _____________         ");
            Console.WriteLine("          <             >        Tonight's");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("           |           |         Conditions");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("           |___________|         ─────────");
            ConsoleUI.Reset();
        }

        private void DrawCurrentConditions()
        {
            ConsoleUI.Section("TONIGHT'S WEATHER  —  " + _tonight._name);

            // Temperature with colour
            string tempStr = $"{_tonight._temperature:F0}°F";
            ConsoleColor tempColor = GetTempColor(_tonight._temperature);
            ConsoleUI.Row("Temperature",  tempStr,               tempColor);

            ConsoleUI.Row("Wind Speed",   $"{_tonight._windspeed:F1} mph",
                          _tonight._windspeed > 15 ? ConsoleColor.Red : ConsoleColor.Green);

            ConsoleUI.Row("Wind From",    _tonight._winddirection);

            ConsoleUI.Row("Humidity",     $"{_tonight._humidity:F0}%",
                          _tonight._humidity > 70 ? ConsoleColor.Yellow : ConsoleColor.Green);

            ConsoleUI.Row("Rain Chance",  $"{_tonight._rainchance:F0}%",
                          _tonight._rainchance > 40 ? ConsoleColor.Red : ConsoleColor.Green);

            ConsoleUI.Row("Forecast",     _tonight._shortforecast);
            ConsoleUI.Row("Sunset",       _tonight._sunsettime);

            ConsoleUI.SectionEnd();
        }

        private void DrawFireScore()
        {
            ConsoleUI.Section("BONFIRE READINESS SCORE");

            // Big score number
            int    score = _calculator.TotalScore;
            ConsoleColor sc = _calculator.GetScoreColor();

            Console.Write("  ");
            Console.ForegroundColor = sc;

            // Make the score stand out with a big visual
            string scoreDisplay = $"  {score}/100  ";
            string border       = new string('─', scoreDisplay.Length);
            Console.WriteLine("  ┌" + border + "┐");
            Console.Write("  │");
            Console.Write(scoreDisplay);
            Console.WriteLine("│");
            Console.WriteLine("  └" + border + "┘");
            ConsoleUI.Reset();

            Console.WriteLine();
            ConsoleUI.ScoreBar("Fire Score", score);
            Console.WriteLine();

            Console.Write("  Assessment:  ");
            Console.ForegroundColor = sc;
            Console.WriteLine(_calculator.GetScoreLabel());
            ConsoleUI.Reset();

            ConsoleUI.SectionEnd();
        }

        private void DrawQuickSummary()
        {
            ConsoleUI.Section("QUICK SUMMARY");

            // Safety level
            string safetyLevel = _safety.GetSafetyLevel(_tonight);
            ConsoleColor safetyColor = safetyLevel == "SAFE"         ? ConsoleColor.Green
                                     : safetyLevel == "ACCEPTABLE"   ? ConsoleColor.Green
                                     : safetyLevel == "USE CAUTION"  ? ConsoleColor.Yellow
                                     :                                  ConsoleColor.Red;
            ConsoleUI.Row("Safety Level",   safetyLevel, safetyColor);

            // Comfort level
            ConsoleUI.Row("Comfort Level",  _comfort.GetComfortLevel());

            // S'mores rating
            string smoresRating = _smores.GetSmoresRating();
            ConsoleColor smoresColor = smoresRating == "ELITE" || smoresRating == "PRIME"
                                       ? ConsoleColor.Green
                                       : smoresRating == "SOLID" || smoresRating == "MID"
                                         ? ConsoleColor.Yellow
                                         : ConsoleColor.Red;
            ConsoleUI.Row("S'mores Rating",  smoresRating + "  " + _smores.GetSmoresEmoji(),
                          smoresColor);

            // Best bonfire window
            ConsoleUI.Row("Best Fire Window", GetBestWindow());

            Console.WriteLine();

            // Any quick warnings
            var warnings = _safety.GetWarnings(_tonight);
            if (warnings.Count > 0)
            {
                foreach (string w in warnings)
                    ConsoleUI.Warn(w);
            }
            else
            {
                ConsoleUI.Good("No major safety concerns tonight.");
            }

            ConsoleUI.SectionEnd();
        }

        // ── helpers ───────────────────────────────────────────────────────

        private ConsoleColor GetTempColor(double temp)
        {
            if (temp >= 58 && temp <= 72) return ConsoleColor.Green;
            if (temp >= 45 && temp <= 80) return ConsoleColor.Yellow;
            return ConsoleColor.Red;
        }

        private string GetBestWindow()
        {
            // Estimate based on sunset and score
            // Sunset is typically 7:30–8:30 PM in WV spring/summer
            // Best fire: 1 hour after sunset through ~11 PM
            int score = _calculator.TotalScore;

            if (score >= 70) return "7:30 PM – 11:00 PM";
            if (score >= 50) return "7:30 PM –  9:30 PM";
            if (score >= 30) return "7:30 PM –  8:30 PM";
            return "Not recommended tonight";
        }
    }
}

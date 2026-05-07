using System;

namespace Project_1
{
    /// <summary>
    /// Calculates a Bonfire Readiness Score from 0 to 100
    /// based on temperature, wind, rain chance, humidity, and sky conditions.
    /// Higher is better.
    /// </summary>
    internal class FireScoreCalculator
    {
        // Individual component scores (each 0–25 or 0–20 range)
        public int TemperatureScore;
        public int WindScore;
        public int RainScore;
        public int HumidityScore;
        public int SkyScore;
        public int TotalScore;

        /// <summary>
        /// Runs the full calculation and stores results.
        /// Returns total score 0–100.
        /// </summary>
        public int Calculate(WeatherDay weather)
        {
            TemperatureScore = ScoreTemperature(weather._temperature);
            WindScore        = ScoreWind(weather._windspeed);
            RainScore        = ScoreRain(weather._rainchance, weather._rainfall);
            HumidityScore    = ScoreHumidity(weather._humidity);
            SkyScore         = ScoreSky(weather._shortforecast);

            TotalScore = TemperatureScore + WindScore + RainScore +
                         HumidityScore    + SkyScore;

            // Cap at 100
            if (TotalScore > 100) TotalScore = 100;
            if (TotalScore < 0)   TotalScore = 0;

            return TotalScore;
        }

        // ── scoring logic ─────────────────────────────────────────────────

        // Temperature (0–25 pts)  — sweet spot 55–72°F
        private int ScoreTemperature(double temp)
        {
            if (temp >= 58 && temp <= 72) return 25;
            if (temp >= 50 && temp <  58) return 20;
            if (temp >  72 && temp <= 80) return 20;
            if (temp >= 45 && temp <  50) return 12;
            if (temp >  80 && temp <= 88) return 12;
            if (temp >= 35 && temp <  45) return 5;
            return 0;
        }

        // Wind (0–25 pts) — lower is better
        private int ScoreWind(double wind)
        {
            if (wind <= 3)  return 25;
            if (wind <= 7)  return 22;
            if (wind <= 10) return 17;
            if (wind <= 14) return 10;
            if (wind <= 18) return 4;
            return 0;
        }

        // Rain (0–25 pts)
        private int ScoreRain(double rainChance, double rainfall)
        {
            if (rainfall > 0) return 0;
            if (rainChance <= 5)  return 25;
            if (rainChance <= 15) return 22;
            if (rainChance <= 25) return 18;
            if (rainChance <= 40) return 10;
            if (rainChance <= 55) return 4;
            return 0;
        }

        // Humidity (0–15 pts) — ideal 35–60%
        private int ScoreHumidity(double humidity)
        {
            if (humidity >= 35 && humidity <= 60) return 15;
            if (humidity >  60 && humidity <= 75) return 10;
            if (humidity >  75)                   return 5;
            if (humidity >= 20 && humidity <  35) return 10;
            if (humidity < 20)                    return 5; // very dry = fire hazard
            return 8;
        }

        // Sky / forecast conditions (0–10 pts)
        private int ScoreSky(string forecast)
        {
            if (string.IsNullOrEmpty(forecast)) return 5;
            string f = forecast.ToLower();

            if (f.Contains("thunder") || f.Contains("storm")) return 0;
            if (f.Contains("rain")    || f.Contains("shower")) return 2;
            if (f.Contains("fog")     || f.Contains("mist"))   return 4;
            if (f.Contains("overcast"))                         return 5;
            if (f.Contains("cloudy"))                           return 6;
            if (f.Contains("partly"))                           return 8;
            if (f.Contains("mostly clear") ||
                f.Contains("mostly sunny"))                     return 9;
            if (f.Contains("clear") || f.Contains("sunny"))    return 10;
            return 6;
        }

        // ── labels ────────────────────────────────────────────────────────

        public string GetScoreLabel()
        {
            if (TotalScore >= 90) return "PERFECT — Dream bonfire night!";
            if (TotalScore >= 75) return "Excellent conditions for a bonfire.";
            if (TotalScore >= 60) return "Good — grab some firewood and go.";
            if (TotalScore >= 45) return "Fair — manageable with some prep.";
            if (TotalScore >= 30) return "Poor — consider rescheduling.";
            return "Not Tonight — unsafe or unpleasant conditions.";
        }

        public ConsoleColor GetScoreColor()
        {
            if (TotalScore >= 75) return ConsoleColor.Green;
            if (TotalScore >= 45) return ConsoleColor.Yellow;
            return ConsoleColor.Red;
        }

        /// <summary>Prints the full score breakdown to the console.</summary>
        public void DisplayBreakdown()
        {
            ConsoleUI.Section("Score Breakdown");
            ConsoleUI.ScoreBar("Temperature", TemperatureScore, 25);
            ConsoleUI.ScoreBar("Wind       ", WindScore,        25);
            ConsoleUI.ScoreBar("Rain Chance", RainScore,        25);
            ConsoleUI.ScoreBar("Humidity   ", HumidityScore,    15);
            ConsoleUI.ScoreBar("Sky / Cond ", SkyScore,         10);
            ConsoleUI.Divider();

            Console.Write("  TOTAL FIRE SCORE:  ");
            Console.ForegroundColor = GetScoreColor();
            Console.WriteLine($"{TotalScore}/100");
            ConsoleUI.Reset();

            Console.Write("  Assessment:        ");
            Console.ForegroundColor = GetScoreColor();
            Console.WriteLine(GetScoreLabel());
            ConsoleUI.Reset();

            ConsoleUI.SectionEnd();
        }
    }
}

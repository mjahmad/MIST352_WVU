using System;

namespace Project_1
{
    internal class DecisionEngine
    {
        public double _tempThreshold  = 32;
        public double _snowThreshold  = 2;
        public double _gustThreshold  = 35;
        public int    _scoreThreshold = 45;   // SeverityScore cutoff

        // Legacy rule-based check (kept for backward compat)
        public bool ShouldCancel(WeatherDay weather)
        {
            return weather._temperature <= _tempThreshold ||
                   weather._snowfall    >= _snowThreshold;
        }

        // Enhanced multi-factor recommendation with reason text
        public (bool cancel, string reason) Evaluate(WeatherDay w)
        {
            if (w.Snowfall >= 6)
                return (true,  $"Heavy snowfall ({w.Snowfall:F1}\")");
            if (w.HasIce || w.HasFreeze)
                return (true,  "Ice / freezing rain event");
            if (w.MinTemp <= 10)
                return (true,  $"Extreme cold ({w.MinTemp:F1}°F)");
            if (w.Snowfall >= 4 && w.MinTemp <= 28)
                return (true,  $"Snow + cold combo ({w.Snowfall:F1}\" / {w.MinTemp:F1}°F)");
            if (w.WindGust >= _gustThreshold && w.Snowfall >= 2)
                return (true,  $"Blizzard conditions (gust {w.WindGust:F0} mph + snow)");
            if (w.SeverityScore() >= _scoreThreshold)
                return (true,  $"High composite severity score ({w.SeverityScore()}/100)");
            if (w.Snowfall >= 2)
                return (false, $"Moderate snow ({w.Snowfall:F1}\") – classes likely delayed");
            return (false, "Conditions insufficient for cancellation");
        }

        public void PrintAssessment(WeatherDay w)
        {
            var (cancel, reason) = Evaluate(w);
            Console.ForegroundColor = cancel ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine(cancel
                ? $"  RECOMMENDATION: CANCEL  ({reason})"
                : $"  RECOMMENDATION: HOLD    ({reason})");
            Console.ResetColor();
        }
    }
}

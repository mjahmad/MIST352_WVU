using System;
using System.Collections.Generic;
using System.IO;

namespace Project_1
{
    /// <summary>
    /// Trains on NOAA historical days matched to WVU cancellation dates,
    /// then predicts cancellation probability for a given WeatherDay.
    /// </summary>
    internal class CancellationPredictor
    {
        // Legacy records field (original code compatibility)
        public CancellationRecord[] _records;

        // Derived weights from training
        private double _avgCancelSnow;
        private double _avgCancelTemp;
        private double _avgCancelWind;
        private double _avgCancelScore;
        private int    _cancelCount;
        private int    _totalCount;
        private bool   _trained;

        public CancellationPredictor(CancellationRecord[] records)
        {
            _records = records;
        }

        // ── Legacy training (keeps original code path alive) ─────────────────

        public void TrainModel()
        {
            if (_records == null || _records.Length == 0) return;
            Console.WriteLine("  Training cancellation model...");

            double sumSnow = 0, sumTemp = 0, sumWind = 0, sumScore = 0;
            int cancelled = 0, total = 0;

            foreach (var r in _records)
            {
                if (r == null) continue;
                total++;
                if (r._wasCancelled)
                {
                    cancelled++;
                    sumSnow  += r._weather.Snowfall;
                    sumTemp  += r._weather.MinTemp;
                    sumWind  += r._weather.WindGust;
                    sumScore += r._weather.SeverityScore();
                }
            }

            _cancelCount = cancelled;
            _totalCount  = total;

            if (cancelled > 0)
            {
                _avgCancelSnow  = sumSnow  / cancelled;
                _avgCancelTemp  = sumTemp  / cancelled;
                _avgCancelWind  = sumWind  / cancelled;
                _avgCancelScore = sumScore / cancelled;
            }
            _trained = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Model ready – {cancelled}/{total} training days were cancellations.");
            Console.ResetColor();
        }

        // ── Enhanced training from full NOAA year + history file ─────────────

        public void TrainFromHistory(WeatherDay[] historicalDays, string historyFilePath)
        {
            var cancelledDates = LoadCancelledDates(historyFilePath);

            var recordList = new List<CancellationRecord>();
            foreach (var day in historicalDays)
            {
                bool wasCancelled = cancelledDates.Contains(day.Date);
                recordList.Add(new CancellationRecord(day.Date, wasCancelled, day));
            }

            _records = recordList.ToArray();
            TrainModel();
        }

        // ── Prediction ────────────────────────────────────────────────────────

        public double Predict(WeatherDay weather)
        {
            if (!_trained || _cancelCount == 0)
            {
                // Fallback: base-rate + simple threshold boost
                double baseProbability = _totalCount > 0 ? (double)_cancelCount / _totalCount : 0.1;
                return Math.Min(baseProbability + (weather.SeverityScore() / 200.0), 1.0);
            }

            // Similarity to average cancellation-day conditions
            double snowSim  = _avgCancelSnow  > 0 ? Math.Min(weather.Snowfall  / _avgCancelSnow,  1.5) : 0;
            double tempSim  = _avgCancelTemp  > 0 ? Math.Min(_avgCancelTemp    / Math.Max(weather.MinTemp, 1), 1.5) : 0;
            double windSim  = _avgCancelWind  > 0 ? Math.Min(weather.WindGust  / _avgCancelWind,  1.5) : 0;
            double scoreSim = _avgCancelScore > 0 ? Math.Min(weather.SeverityScore() / _avgCancelScore, 1.5) : 0;

            // Weighted average of similarities (snow + score weighted most)
            double similarity = (snowSim * 0.35 + tempSim * 0.20 + windSim * 0.15 + scoreSim * 0.30);

            // Scale by historical cancellation rate
            double baseRate = (double)_cancelCount / _totalCount;
            double prob = baseRate * similarity;

            // Bonus for dangerous event flags
            if (weather.HasIce || weather.HasFreeze) prob += 0.15;
            if (weather.HasBlowingSnow)              prob += 0.08;

            return Math.Min(prob, 1.0);
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private static HashSet<string> LoadCancelledDates(string filePath)
        {
            var dates = new HashSet<string>(StringComparer.Ordinal);

            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  History file not found: {filePath}");
                Console.ResetColor();
                return dates;
            }

            foreach (string line in File.ReadAllLines(filePath))
            {
                string trimmed = line.Trim();
                if (trimmed.StartsWith("#") || trimmed.Length < 10) continue;

                string datePart = trimmed[..10];
                if (datePart.Length == 10 && datePart[4] == '-' && datePart[7] == '-')
                    dates.Add(datePart);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Loaded {dates.Count} WVU cancellation dates from history file.");
            Console.ResetColor();
            return dates;
        }

        public void PrintPrediction(WeatherDay today)
        {
            double prob = Predict(today);
            int pct     = (int)(prob * 100);

            Console.WriteLine();
            Console.WriteLine("  ┌─── CANCELLATION PREDICTION ────────────────────────────┐");
            Console.Write("  │  Probability: ");

            ConsoleColor barColor = pct >= 70 ? ConsoleColor.Red
                                  : pct >= 40 ? ConsoleColor.Yellow
                                  : ConsoleColor.Green;
            Console.ForegroundColor = barColor;

            int filled = pct * 40 / 100;
            string bar = new string('█', filled) + new string('░', 40 - filled);
            Console.Write($"{bar}  {pct,3}%");
            Console.ResetColor();
            Console.WriteLine("  │");

            string label = pct >= 70 ? "HIGH – cancellation very likely"
                         : pct >= 40 ? "MODERATE – monitor WVU alerts"
                         : "LOW – classes expected to run";
            Console.ForegroundColor = barColor;
            Console.WriteLine($"  │  Assessment: {label,-44}│");
            Console.ResetColor();
            Console.WriteLine("  └────────────────────────────────────────────────────────┘");
        }
    }
}

using System;

namespace Project_1
{
    /// <summary>
    /// Predicts cancellation probability based on historical data.
    /// </summary>
    internal class CancellationPredictor
    {
        public CancellationRecord[] _records;

        public CancellationPredictor(CancellationRecord[] records)
        {
            _records = records;
        }

        public void TrainModel()
        {
            Console.WriteLine("Training model...");
        }

        public double Predict(WeatherDay weather)
        {
            int total = 0;
            int cancelled = 0;

            foreach (var record in _records)
            {
                if (record != null)
                {
                    total++;
                    if (record._wasCancelled)
                        cancelled++;
                }
            }

            if (total == 0) return 0;

            return (double)cancelled / total;
        }
    }
}
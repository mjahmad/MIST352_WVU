using System;

namespace Project_1
{
    /// <summary>
    /// Entry point connecting all components.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            NOAAService service = new NOAAService("Morgantown");
            WeatherDay[] weatherData = service.GetHistoricalData();

            CancellationRecord[] records = new CancellationRecord[5];

            for (int i = 0; i < weatherData.Length; i++)
            {
                bool cancelled = weatherData[i]._snowfall > 2;
                records[i] = new CancellationRecord("Day " + i, cancelled, weatherData[i]);
            }

            CancellationPredictor predictor = new CancellationPredictor(records);
            predictor.TrainModel();

            WeatherDay today = new WeatherDay(29, 3, 4);

            double probability = predictor.Predict(today);

            DecisionEngine engine = new DecisionEngine();

            Console.WriteLine("Probability: " + probability);
            Console.WriteLine("Should Cancel: " + engine.ShouldCancel(today));
        }
    }
}
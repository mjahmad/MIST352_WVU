using System;

namespace Project_1
{
    /// <summary>
    /// Provides historical weather data (hardcoded).
    /// </summary>
    internal class NOAAService
    {
        public string _location;

        public NOAAService(string location)
        {
            _location = location;
        }

        public WeatherDay[] GetHistoricalData()
        {
            WeatherDay[] data = new WeatherDay[5];

            data[0] = new WeatherDay(30, 3, 5);
            data[1] = new WeatherDay(40, 0, 0);
            data[2] = new WeatherDay(28, 4, 6);
            data[3] = new WeatherDay(35, 1, 2);
            data[4] = new WeatherDay(25, 5, 8);

            return data;
        }
    }
}
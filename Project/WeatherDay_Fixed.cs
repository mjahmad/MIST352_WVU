using System;

namespace Project_1
{
    /// <summary>
    /// Represents daily weather conditions used for prediction.
    /// </summary>
    internal class WeatherDay
    {
        public double _temperature;
        public double _snowfall;
        public double _snowDepth;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public WeatherDay()
        {
            _temperature = 0;
            _snowfall = 0;
            _snowDepth = 0;
        }

        /// <summary>
        /// Initializes weather values.
        /// </summary>
        public WeatherDay(double temp, double snow, double depth)
        {
            _temperature = temp;
            _snowfall = snow;
            _snowDepth = depth;
        }

        /// <summary>
        /// Displays weather data.
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"Temp: {_temperature}, Snow: {_snowfall}, Depth: {_snowDepth}");
        }
    }
}
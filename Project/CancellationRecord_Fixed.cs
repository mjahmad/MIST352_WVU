using System;

namespace Project_1
{
    /// <summary>
    /// Stores historical labeled weather data.
    /// </summary>
    internal class CancellationRecord
    {
        public string _date;
        public bool _wasCancelled;
        public WeatherDay _weather;

        /// <summary>
        /// Initializes record.
        /// </summary>
        public CancellationRecord(string date, bool cancelled, WeatherDay weather)
        {
            _date = date;
            _wasCancelled = cancelled;
            _weather = weather;
        }
    }
}
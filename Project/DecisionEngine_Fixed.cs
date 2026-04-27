using System;

namespace Project_1
{
    /// <summary>
    /// Rule-based decision system.
    /// </summary>
    internal class DecisionEngine
    {
        public double _tempThreshold;
        public double _snowThreshold;

        public DecisionEngine()
        {
            _tempThreshold = 32;
            _snowThreshold = 2;
        }

        /// <summary>
        /// Determines if classes should be cancelled.
        /// </summary>
        public bool ShouldCancel(WeatherDay weather)
        {
            return (weather._temperature <= _tempThreshold ||
                    weather._snowfall >= _snowThreshold);
        }
    }
}
using System;
using System.Collections.Generic;

namespace Project_1
{
    /// <summary>
    /// Evaluates safety conditions for a bonfire.
    /// Generates specific warnings based on weather data.
    /// </summary>
    internal class FireSafety
    {
        public double _maxwind;
        public double _maxrain;

        public FireSafety()
        {
            _maxwind = 20.0;
            _maxrain = 2.0;
        }

        /// <summary>Basic safety check (used by BonfirePlanner).</summary>
        public bool IsSafe(WeatherDay weather)
        {
            return weather._windspeed <= _maxwind &&
                   weather._rainfall  <= _maxrain &&
                   weather._rainchance < 60;
        }

        /// <summary>Returns a list of human-readable warning strings.</summary>
        public List<string> GetWarnings(WeatherDay weather)
        {
            List<string> warnings = new List<string>();

            if (weather._windspeed > 20)
                warnings.Add("Wind is dangerously high — fire spreading risk.");
            else if (weather._windspeed > 15)
                warnings.Add("Wind too strong for a safe bonfire tonight.");
            else if (weather._windspeed > 10)
                warnings.Add("Moderate wind — keep fire small and controlled.");

            if (weather._rainchance > 70)
                warnings.Add("High chance of rain — bonfire not recommended.");
            else if (weather._rainchance > 40)
                warnings.Add("Rain possible tonight — watch the sky closely.");

            if (weather._rainfall > 0)
                warnings.Add("Precipitation in the forecast — reschedule if possible.");

            if (weather._temperature > 90)
                warnings.Add("Very hot evening — fire adds significant heat risk.");
            else if (weather._temperature < 30)
                warnings.Add("Freezing temps — use extra care handling fire materials.");

            if (weather._humidity < 20)
                warnings.Add("Very low humidity — fire can spread rapidly. Use caution.");

            if (weather._shortforecast != null &&
                (weather._shortforecast.ToLower().Contains("thunder") ||
                 weather._shortforecast.ToLower().Contains("storm")))
                warnings.Add("Thunderstorms in forecast — DO NOT light a bonfire.");

            return warnings;
        }

        /// <summary>Returns a list of safe-condition tips.</summary>
        public List<string> GetSafeTips()
        {
            List<string> tips = new List<string>();
            tips.Add("Keep a bucket of water or hose nearby.");
            tips.Add("Clear a 10-foot radius around the fire pit.");
            tips.Add("Never leave the fire unattended.");
            tips.Add("Fully extinguish fire before going inside.");
            tips.Add("Check local fire restrictions before lighting.");
            return tips;
        }

        /// <summary>Returns overall safety label.</summary>
        public string GetSafetyLevel(WeatherDay weather)
        {
            if (weather._windspeed > 20 || weather._rainchance > 70 ||
                (weather._shortforecast != null &&
                 weather._shortforecast.ToLower().Contains("thunder")))
                return "UNSAFE";

            if (weather._windspeed > 15 || weather._rainchance > 40)
                return "USE CAUTION";

            if (weather._windspeed <= 10 && weather._rainchance <= 20)
                return "SAFE";

            return "ACCEPTABLE";
        }
    }
}

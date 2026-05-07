using System;

namespace Project_1
{
    /// <summary>
    /// Represents weather conditions for a single day/period.
    /// Stores all data needed for bonfire planning decisions.
    /// </summary>
    internal class WeatherDay
    {
        public double _temperature;
        public double _windspeed;
        public string _winddirection;
        public double _rainfall;
        public string _sunsettime;
        public double _humidity;
        public double _rainchance;
        public string _shortforecast;
        public string _detailedforecast;
        public string _date;
        public string _name; // e.g. "Tonight", "Monday Night"

        public WeatherDay()
        {
            _temperature   = 0;
            _windspeed     = 0;
            _winddirection = "N";
            _rainfall      = 0;
            _sunsettime    = "8:00 PM";
            _humidity      = 50;
            _rainchance    = 0;
            _shortforecast = "Clear";
            _detailedforecast = "";
            _date          = DateTime.Today.ToString("MM/dd/yyyy");
            _name          = "Tonight";
        }

        /// <summary>
        /// Core check: is this night good enough for a bonfire?
        /// </summary>
        public bool IsGoodForFire()
        {
            return (_windspeed < 15 &&
                    _rainfall  == 0 &&
                    _rainchance < 30 &&
                    _temperature >= 45 &&
                    _temperature <= 85);
        }

        /// <summary>
        /// Display a quick summary line for this day.
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"  Date      : {_date}  ({_name})");
            Console.WriteLine($"  Temp      : {_temperature:F0}°F");
            Console.WriteLine($"  Wind      : {_windspeed:F1} mph from {_winddirection}");
            Console.WriteLine($"  Humidity  : {_humidity:F0}%");
            Console.WriteLine($"  Rain %    : {_rainchance:F0}%");
            Console.WriteLine($"  Forecast  : {_shortforecast}");
            Console.WriteLine($"  Sunset    : {_sunsettime}");
        }
    }
}

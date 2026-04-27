namespace Project_2
{
    internal class WeatherDay
    {
        public string Date { get; set; } = "";
        public string DayName { get; set; } = "";
        public double HighTemp { get; set; }
        public double LowTemp { get; set; }
        public double WindSpeed { get; set; }
        public string WindDirection { get; set; } = "N";
        public double PrecipChance { get; set; }
        public double Rainfall { get; set; }
        public int Humidity { get; set; }
        public string Description { get; set; } = "";
        public string DetailedForecast { get; set; } = "";
        public string SunsetTime { get; set; } = "20:00";
        public string SunriseTime { get; set; } = "06:00";

        // Legacy compatibility
        public double _temperature => HighTemp;
        public double _windspeed => WindSpeed;
        public string _winddirection => WindDirection;
        public double _rainfall => Rainfall;
        public string _sunsettime => SunsetTime;

        public bool IsGoodForFire()
        {
            return WindSpeed < 15 && PrecipChance < 30 && HighTemp >= 45 && HighTemp <= 85;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"  {DayName,-12} {Date}");
            Console.WriteLine($"  High: {HighTemp:F0}°F  Low: {LowTemp:F0}°F  Humidity: {Humidity}%");
            Console.WriteLine($"  Wind: {WindSpeed:F0} mph {WindDirection}  Rain Chance: {PrecipChance:F0}%");
            Console.WriteLine($"  Conditions: {Description}");
        }
    }
}

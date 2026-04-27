using System;
using System.Text;

namespace Project_1
{
    internal class WeatherDay
    {
        // 13 NOAA-sourced fields (6 new beyond original 3)
        public string Date = "";
        public double MinTemp;        // °F  TMIN
        public double MaxTemp;        // °F  TMAX
        public double Snowfall;       // in  SNOW
        public double SnowDepth;      // in  SNWD
        public double Precipitation;  // in  PRCP
        public double WindSpeed;      // mph AWND (average)
        public double WindGust;       // mph WSF2 (peak 2-min)
        public bool HasFog;           // WT01
        public bool HasIce;           // WT04 ice pellets/sleet
        public bool HasThunder;       // WT03
        public bool HasBlowingSnow;   // WT09
        public bool HasFreeze;        // WT06 freezing rain/glaze

        // Legacy field names so original Program.cs logic still compiles
        public double _temperature => MinTemp;
        public double _snowfall    => Snowfall;
        public double _snowDepth   => SnowDepth;

        public WeatherDay() { }

        // Original 3-arg constructor kept for backward compatibility
        public WeatherDay(double temp, double snow, double depth)
        {
            MinTemp  = temp;
            MaxTemp  = temp + 10;
            Snowfall = snow;
            SnowDepth = depth;
        }

        // Full constructor used by new services
        public WeatherDay(string date, double minTemp, double maxTemp,
                          double snow, double snowDepth, double precip,
                          double windSpeed, double windGust,
                          bool fog, bool ice, bool thunder, bool blowingSnow, bool freeze)
        {
            Date         = date;
            MinTemp      = minTemp;
            MaxTemp      = maxTemp;
            Snowfall     = snow;
            SnowDepth    = snowDepth;
            Precipitation = precip;
            WindSpeed    = windSpeed;
            WindGust     = windGust;
            HasFog       = fog;
            HasIce       = ice;
            HasThunder   = thunder;
            HasBlowingSnow = blowingSnow;
            HasFreeze    = freeze;
        }

        // 0-100 composite severity used by predictor and decision engine
        public int SeverityScore()
        {
            int s = 0;
            if      (MinTemp <= 20) s += 30;
            else if (MinTemp <= 28) s += 20;
            else if (MinTemp <= 32) s += 10;
            if      (Snowfall >= 6) s += 40;
            else if (Snowfall >= 4) s += 30;
            else if (Snowfall >= 2) s += 15;
            else if (Snowfall >= 1) s +=  5;
            if      (WindGust >= 45) s += 20;
            else if (WindGust >= 30) s += 10;
            if (HasIce || HasFreeze)  s += 25;
            if (HasBlowingSnow)       s += 10;
            if (SnowDepth >= 8)       s += 10;
            return Math.Min(s, 100);
        }

        public void DisplayInfo()
        {
            Console.Write($"  {Date,-12}");

            ConsoleColor tc = MinTemp <= 20 ? ConsoleColor.DarkCyan
                            : MinTemp <= 32 ? ConsoleColor.Cyan
                            : ConsoleColor.Yellow;
            Console.ForegroundColor = tc;
            Console.Write($"  {MinTemp,5:F1}° – {MaxTemp:F1}°F");
            Console.ResetColor();

            if (Snowfall > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"  Snow:{Snowfall,4:F1}\"");
                Console.ResetColor();
            }
            if (Precipitation > 0)  Console.Write($"  Precip:{Precipitation:F2}\"");
            if (WindSpeed > 0)      Console.Write($"  Wind:{WindSpeed:F0}mph");
            if (WindGust > 25)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"  Gust:{WindGust:F0}mph");
                Console.ResetColor();
            }

            var flags = new StringBuilder();
            if (HasFog)         flags.Append(" FOG");
            if (HasIce)         flags.Append(" ICE");
            if (HasThunder)     flags.Append(" THUNDER");
            if (HasBlowingSnow) flags.Append(" BLWSNOW");
            if (HasFreeze)      flags.Append(" FREEZE");
            if (flags.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(flags);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}

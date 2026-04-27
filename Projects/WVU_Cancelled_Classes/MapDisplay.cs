using System;
using System.Collections.Generic;

namespace Project_1
{
    /// <summary>
    /// Feature 2 – ASCII map of Morgantown, WV with live weather overlay.
    /// </summary>
    internal static class MapDisplay
    {
        // 60-wide × 28-tall grid.  Each cell is one character.
        // '~' = river  '.' = land  ' ' = edge padding
        // Named landmark slots are filled at render time.
        private static readonly string[] BASE_MAP = new[]
        {
            "                                                            ",
            "  ┌──────────────── MORGANTOWN, WV ──────────────────────┐ ",
            "  │         N                                             │ ",
            "  │         ↑                                             │ ",
            "  │  . . . . . . [Cheat Lake] . . . . . . . . . . . . .  │ ",
            "  │  . . . . . . . . . . . . . . . . . . . . . . . . . .  │ ",
            "  │  . . [Evansdale]. . . . . . . . . . . . . . . . . . . │ ",
            "  │  . . . . [PRT Station]. . . . . . . . . . . . . . . . │ ",
            "  │  . . [WVU Milan Puskar]. . . . . . . . . . . . . . .  │ ",
            "  │  . . . [WVU Main Campus]. . . . . . . . . . . . . .   │ ",
            "  │  . . . . . . . . . . . . . . . . . . . . . . . . . .  │ ",
            "  │  . . . . . [WVU Coliseum] . . . . . . . . . . . . .   │ ",
            "  │~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~[Mon]~│ ",
            "  │~~~~~~~~~~~~~~~~~~~ Monongahela River ~~~~~~~~~~~~~~~~~~│ ",
            "  │~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~[River]│",
            "  │  . . . [Star City] . . . . . . . . . . . . . . . . .  │ ",
            "  │  . . . . . . . . . . . . . . . . . . . . . . . . . .  │ ",
            "  │  . . . . . [Downtown Morgantown]. . . . . . . . . . .  │ ",
            "  │  . . . . . . . . . . . . . . . . . . . . . . . . . .  │ ",
            "  │  . . . . [WVU Health Hosp.] . . . . . . . . . . . .   │ ",
            "  │  . . . . . . . . . . . . . . . . . . . . . . . . . .  │ ",
            "  │  W ←─────────────────────────────────────────→ E      │ ",
            "  │         ↓                                             │  ",
            "  │         S     39.63°N  79.96°W   Elev: 980 ft        │  ",
            "  └────────────────────────────────────────────────────────┘ ",
            "                                                            ",
            "                                                            ",
            "                                                            ",
        };

        public static void Show(WeatherDay today)
        {
            Console.Clear();
            PrintWeatherHeader(today);
            PrintMap(today);
            PrintLegend(today);
            Console.WriteLine();
            Console.Write("  Press any key to return to menu...");
            Console.ReadKey(true);
        }

        private static void PrintWeatherHeader(WeatherDay w)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ╔══════════════════════════════════════════════════════════╗");
            Console.Write("  ║   MORGANTOWN, WV  –  CURRENT CONDITIONS  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{w.Date,-14}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("   ║");
            Console.ResetColor();

            // Temperature line
            Console.Write("  ║   Temp:  ");
            ConsoleColor tc = w.MinTemp <= 20 ? ConsoleColor.DarkCyan : w.MinTemp <= 32 ? ConsoleColor.Cyan : ConsoleColor.Yellow;
            Console.ForegroundColor = tc;
            Console.Write($"{w.MinTemp:F1}°F – {w.MaxTemp:F1}°F");
            Console.ResetColor();

            // Snow line
            Console.Write("  │  Snow:  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{w.Snowfall:F1}\"  Depth: {w.SnowDepth:F1}\"");
            Console.ResetColor();

            Console.WriteLine();
            Console.Write("  ║   Wind:  ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"Avg {w.WindSpeed:F0} mph  Gust {w.WindGust:F0} mph");
            Console.ResetColor();
            Console.Write("  │  Precip: ");
            Console.Write($"{w.Precipitation:F2}\"");
            Console.WriteLine();

            // Event flags
            Console.Write("  ║   Events: ");
            PrintEventFlags(w);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ╚══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        private static void PrintMap(WeatherDay w)
        {
            // Pick a weather symbol for the overlay
            string sym   = WeatherSymbol(w);
            string wind  = WindArrow(w.WindSpeed);
            int    sev   = w.SeverityScore();

            for (int row = 0; row < BASE_MAP.Length; row++)
            {
                string line = BASE_MAP[row];

                // Color the river rows blue
                if (line.Contains('~'))
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                else
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.Write(line);

                // Overlay weather data on the right margin
                Console.ResetColor();
                if (row == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"  WEATHER:  {sym}");
                }
                else if (row == 4)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"  SNOW:     {SnowBar(w.Snowfall)}");
                }
                else if (row == 6)
                {
                    ConsoleColor tc = w.MinTemp <= 32 ? ConsoleColor.Cyan : ConsoleColor.Yellow;
                    Console.ForegroundColor = tc;
                    Console.Write($"  TEMP:     {TempBar(w.MinTemp)}");
                }
                else if (row == 8)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"  WIND:     {wind} {w.WindSpeed:F0} mph");
                }
                else if (row == 10)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"  PRECIP:   {w.Precipitation:F2}\"");
                }
                else if (row == 12)
                {
                    ConsoleColor sc = sev >= 60 ? ConsoleColor.Red : sev >= 30 ? ConsoleColor.Yellow : ConsoleColor.Green;
                    Console.ForegroundColor = sc;
                    Console.Write($"  SEVERITY: {sev}/100");
                }
                else if (row == 14)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"  DEPTH:    {w.SnowDepth:F1}\"");
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }

        private static void PrintLegend(WeatherDay w)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ┌─── MAP KEY ──────────────────────────────────────┐");
            Console.ResetColor();
            Console.WriteLine("  │  ~~  Monongahela River                           │");
            Console.WriteLine("  │  [ ] Landmark / Campus Building                  │");
            Console.WriteLine("  │   .  Open terrain                                │");

            Console.Write("  │  Weather Symbol: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(WeatherSymbol(w));
            Console.ResetColor();
            Console.WriteLine("                                    │");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  └──────────────────────────────────────────────────┘");
            Console.ResetColor();
        }

        private static string WeatherSymbol(WeatherDay w)
        {
            if (w.Snowfall >= 4 || w.HasBlowingSnow) return "❄  HEAVY SNOW / BLIZZARD";
            if (w.Snowfall >= 1)                      return "🌨  LIGHT SNOW";
            if (w.HasIce || w.HasFreeze)              return "🧊  ICE / FREEZING RAIN";
            if (w.HasThunder)                         return "⛈  THUNDERSTORM";
            if (w.HasFog)                             return "🌫  FOG";
            if (w.Precipitation > 0.1)                return "🌧  RAIN";
            if (w.MinTemp <= 28)                      return "🥶  CLEAR & COLD";
            return                                           "☀  CLEAR";
        }

        private static string WindArrow(double speed)
        {
            if (speed >= 30) return "⟹ STRONG";
            if (speed >= 15) return "→ MODERATE";
            return                  "→ LIGHT";
        }

        private static string SnowBar(double inches)
        {
            int blocks = (int)Math.Min(inches / 0.5, 20);
            return new string('█', blocks) + new string('░', 20 - blocks) + $" {inches:F1}\"";
        }

        private static string TempBar(double temp)
        {
            // Map temp 0-80°F onto 20 blocks
            int blocks = (int)Math.Max(0, Math.Min(temp / 4.0, 20));
            return new string('█', blocks) + new string('░', 20 - blocks) + $" {temp:F1}°F";
        }

        private static void PrintEventFlags(WeatherDay w)
        {
            bool any = false;
            Action<string, ConsoleColor> flag = (s, c) =>
            {
                Console.ForegroundColor = c;
                Console.Write(s + "  ");
                Console.ResetColor();
                any = true;
            };

            if (w.HasFog)         flag("FOG",       ConsoleColor.Gray);
            if (w.HasIce)         flag("ICE",        ConsoleColor.Cyan);
            if (w.HasFreeze)      flag("FREEZE",     ConsoleColor.DarkCyan);
            if (w.HasBlowingSnow) flag("BLWSNOW",    ConsoleColor.White);
            if (w.HasThunder)     flag("THUNDER",    ConsoleColor.Yellow);
            if (!any)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("none");
                Console.ResetColor();
            }
        }
    }
}

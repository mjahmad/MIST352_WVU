using System;
using System.Threading;

namespace Project_1
{
    /// <summary>
    /// Feature 3 – "WVU Weather Intelligence Center"
    /// A full-screen animated console dashboard: rotating ASCII radar,
    /// animated probability gauge, scrolling year bar, and cancellation alert.
    /// </summary>
    internal static class AnimatedDashboard
    {
        // Radar dimensions
        private const int RADAR_CX   = 12;   // column of radar centre
        private const int RADAR_CY   = 14;   // row of radar centre
        private const int RADAR_R    = 9;    // radius in columns (halved for rows)
        private const int INFO_COL   = 32;   // column where info panel starts

        public static void Run(WeatherDay today, WeatherDay[] history, double probability)
        {
            Console.CursorVisible = false;
            Console.Clear();

            try
            {
                DrawStaticChrome(today);
                AnimateGaugeFill(probability);

                // Radar loop – 2 full sweeps then exit or keypress
                double angle = 0;
                for (int frame = 0; frame < 120; frame++)
                {
                    if (Console.KeyAvailable) { Console.ReadKey(true); break; }

                    DrawRadarSweep(angle, today);
                    DrawScrollingBar(history, frame);

                    if (probability >= 0.70 && frame % 10 < 5)
                        FlashAlert("  *** ELEVATED CANCELLATION RISK – CHECK WVU ALERTS ***  ");

                    angle = (angle + 3.0) % 360.0;
                    Thread.Sleep(50);
                }
            }
            finally
            {
                Console.CursorVisible = true;
                // Move cursor below the dashboard before returning
                Console.SetCursorPosition(0, 28);
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("  Press any key to return to menu...");
                Console.ReadKey(true);
            }
        }

        // ── Static chrome (drawn once) ────────────────────────────────────────

        private static void DrawStaticChrome(WeatherDay today)
        {
            // Title banner
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                "  ╔══════════════════ WVU WEATHER INTELLIGENCE CENTER ══════════════════╗  ");
            Console.WriteLine(
                "  ║   MORGANTOWN, WV  |  39.63°N 79.96°W  |  NOAA GHCN + Open-Meteo  ║  ");
            Console.WriteLine(
                "  ╚═════════════════════════════════════════════════════════════════════╝  ");
            Console.ResetColor();

            // Radar frame
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  ┌─── RADAR ─────────────────┐");
            for (int r = 0; r < 21; r++)
                Console.WriteLine("  │                           │");
            Console.WriteLine("  └───────────────────────────┘");
            Console.ResetColor();

            // Radar crosshairs and range rings
            DrawRadarFrame();

            // Right panel: conditions
            DrawConditionsPanel(today);

            // Probability label
            Console.SetCursorPosition(INFO_COL, 16);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  ┌─── CANCELLATION PROBABILITY ────────┐");
            Console.SetCursorPosition(INFO_COL, 17);
            Console.Write("  │                                      │");
            Console.SetCursorPosition(INFO_COL, 18);
            Console.Write("  └──────────────────────────────────────┘");
            Console.ResetColor();

            // Scrolling year bar label
            Console.SetCursorPosition(0, 25);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  ┌─── 2025 SEVERITY TIMELINE ────────────────────────────────────────┐");
            Console.SetCursorPosition(0, 26);
            Console.Write("  │                                                                    │");
            Console.SetCursorPosition(0, 27);
            Console.Write("  └────────────────────────────────────────────────────────────────────┘");
            Console.ResetColor();
        }

        private static void DrawRadarFrame()
        {
            // Compass labels
            WriteAt(RADAR_CX,     4, "N",  ConsoleColor.DarkGreen);
            WriteAt(RADAR_CX,    24, "S",  ConsoleColor.DarkGreen);
            WriteAt(RADAR_CX - 9, 14, "W", ConsoleColor.DarkGreen);
            WriteAt(RADAR_CX + 9, 14, "E", ConsoleColor.DarkGreen);

            // Range rings (approximate circles with dots)
            DrawRing(RADAR_CX + 2, RADAR_CY, 3, '·', ConsoleColor.DarkGreen);
            DrawRing(RADAR_CX + 2, RADAR_CY, 6, '·', ConsoleColor.DarkGreen);
            DrawRing(RADAR_CX + 2, RADAR_CY, 9, '·', ConsoleColor.DarkGreen);

            // Center dot
            WriteAt(RADAR_CX + 2, RADAR_CY, "✦", ConsoleColor.Green);
        }

        private static void DrawConditionsPanel(WeatherDay w)
        {
            void Row(int row, string label, string val, double frac, ConsoleColor barColor)
            {
                Console.SetCursorPosition(INFO_COL, row);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"  {label,-12}");
                Console.ForegroundColor = barColor;
                int filled = (int)(frac * 18);
                filled = Math.Max(0, Math.Min(18, filled));
                Console.Write(new string('█', filled) + new string('░', 18 - filled));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($" {val}");
                Console.ResetColor();
            }

            Console.SetCursorPosition(INFO_COL, 3);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  ┌─── CONDITIONS ──────────────────────────┐");

            Row(4,  "Min Temp",    $"{w.MinTemp:F1}°F",  NormTemp(w.MinTemp),         TempColor(w.MinTemp));
            Row(5,  "Max Temp",    $"{w.MaxTemp:F1}°F",  NormTemp(w.MaxTemp),         TempColor(w.MaxTemp));
            Row(6,  "Snowfall",    $"{w.Snowfall:F1}\"", Math.Min(w.Snowfall / 12,1), ConsoleColor.White);
            Row(7,  "Snow Depth",  $"{w.SnowDepth:F1}\"",Math.Min(w.SnowDepth/18,1),  ConsoleColor.Cyan);
            Row(8,  "Precip",      $"{w.Precipitation:F2}\"",Math.Min(w.Precipitation/2,1), ConsoleColor.Blue);
            Row(9,  "Wind Avg",    $"{w.WindSpeed:F0} mph", Math.Min(w.WindSpeed/60,1), ConsoleColor.Magenta);
            Row(10, "Wind Gust",   $"{w.WindGust:F0} mph",  Math.Min(w.WindGust/60,1),  ConsoleColor.DarkMagenta);
            Row(11, "Severity",    $"{w.SeverityScore()}/100", w.SeverityScore()/100.0, SevColor(w.SeverityScore()));

            Console.SetCursorPosition(INFO_COL, 12);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  ├─── EVENTS ──────────────────────────────┤");

            Console.SetCursorPosition(INFO_COL, 13);
            Console.Write("  │  ");
            PrintFlag("FOG",     w.HasFog,         ConsoleColor.Gray);
            PrintFlag("ICE",     w.HasIce,         ConsoleColor.Cyan);
            PrintFlag("FREEZE",  w.HasFreeze,      ConsoleColor.DarkCyan);
            PrintFlag("BLWSNOW", w.HasBlowingSnow, ConsoleColor.White);

            Console.SetCursorPosition(INFO_COL, 14);
            Console.Write("  │  ");
            PrintFlag("THUNDER", w.HasThunder, ConsoleColor.Yellow);

            Console.SetCursorPosition(INFO_COL, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  └─────────────────────────────────────────┘");
            Console.ResetColor();
        }

        // ── Animated gauge fill ───────────────────────────────────────────────

        private static void AnimateGaugeFill(double probability)
        {
            int target  = (int)(probability * 100);
            int barWidth = 36;

            for (int pct = 0; pct <= target; pct += 2)
            {
                int filled = pct * barWidth / 100;
                filled = Math.Max(0, Math.Min(barWidth, filled));

                ConsoleColor col = pct >= 70 ? ConsoleColor.Red
                                 : pct >= 40 ? ConsoleColor.Yellow
                                 : ConsoleColor.Green;

                Console.SetCursorPosition(INFO_COL, 17);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  │  ");
                Console.ForegroundColor = col;
                Console.Write(new string('█', filled) + new string('░', barWidth - filled));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"  {pct,3}%  │");
                Console.ResetColor();

                Thread.Sleep(20);
            }

            // Write final label
            string label = target >= 70 ? "HIGH – LIKELY CANCELLED"
                         : target >= 40 ? "MODERATE – WATCH ALERTS"
                         : "LOW – CLASSES EXPECTED";
            ConsoleColor lc = target >= 70 ? ConsoleColor.Red
                            : target >= 40 ? ConsoleColor.Yellow
                            : ConsoleColor.Green;

            Console.SetCursorPosition(INFO_COL, 18);
            Console.ForegroundColor = lc;
            Console.Write($"  └── {label,-37}┘");
            Console.ResetColor();
        }

        // ── Rotating radar sweep ──────────────────────────────────────────────

        private static void DrawRadarSweep(double angle, WeatherDay w)
        {
            int cx = RADAR_CX + 2;
            int cy = RADAR_CY;

            // Erase previous sweep and trail
            for (int r = 1; r <= RADAR_R; r++)
            {
                for (int a = 0; a < 360; a += 6)
                {
                    double rad = a * Math.PI / 180.0;
                    int x = cx + (int)(r * Math.Cos(rad));
                    int y = cy + (int)(r * Math.Sin(rad) * 0.45);
                    if (x >= 4 && x <= 25 && y >= 4 && y <= 24)
                        WriteAt(x, y, " ", ConsoleColor.DarkGreen);
                }
            }

            // Redraw rings
            DrawRing(cx, cy, 3, '·', ConsoleColor.DarkGreen);
            DrawRing(cx, cy, 6, '·', ConsoleColor.DarkGreen);
            DrawRing(cx, cy, 9, '·', ConsoleColor.DarkGreen);

            // Intensity blips based on snowfall / precipitation
            int blips = (int)(w.Snowfall * 2 + w.Precipitation * 3);
            var rng   = new Random(42);
            for (int i = 0; i < blips; i++)
            {
                double br  = rng.NextDouble() * RADAR_R;
                double ba  = rng.NextDouble() * 360;
                double brd = ba * Math.PI / 180.0;
                int bx = cx + (int)(br * Math.Cos(brd));
                int by = cy + (int)(br * Math.Sin(brd) * 0.45);
                if (bx >= 4 && bx <= 25 && by >= 4 && by <= 24)
                {
                    ConsoleColor bc = w.Snowfall >= 4 ? ConsoleColor.White
                                    : w.Snowfall >= 1 ? ConsoleColor.Cyan
                                    : ConsoleColor.Blue;
                    WriteAt(bx, by, "◦", bc);
                }
            }

            // Sweep line
            double sweepRad  = angle * Math.PI / 180.0;
            double trailRad  = ((angle - 40 + 360) % 360) * Math.PI / 180.0;

            for (int r = 1; r <= RADAR_R; r++)
            {
                int sx = cx + (int)(r * Math.Cos(sweepRad));
                int sy = cy + (int)(r * Math.Sin(sweepRad) * 0.45);
                if (sx >= 4 && sx <= 25 && sy >= 4 && sy <= 24)
                    WriteAt(sx, sy, "▓", ConsoleColor.Green);

                int tx = cx + (int)(r * Math.Cos(trailRad));
                int ty = cy + (int)(r * Math.Sin(trailRad) * 0.45);
                if (tx >= 4 && tx <= 25 && ty >= 4 && ty <= 24)
                    WriteAt(tx, ty, "░", ConsoleColor.DarkGreen);
            }

            // Angle readout
            Console.SetCursorPosition(4, 23);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"  HDG {angle,5:F1}°  ");
            Console.ResetColor();
        }

        // ── Scrolling year bar ────────────────────────────────────────────────

        private static void DrawScrollingBar(WeatherDay[] history, int frame)
        {
            int width  = 66;
            int offset = (frame * 2) % Math.Max(history.Length, 1);
            Console.SetCursorPosition(2, 26);

            ConsoleColor lastColor = ConsoleColor.Gray;
            for (int col = 0; col < width; col++)
            {
                int idx = (offset + col) % history.Length;
                var day = history[idx];
                char ch;
                ConsoleColor c;

                if (day.SeverityScore() >= 60)      { ch = '█'; c = ConsoleColor.Red; }
                else if (day.SeverityScore() >= 35)  { ch = '▓'; c = ConsoleColor.Yellow; }
                else if (day.SeverityScore() >= 15)  { ch = '▒'; c = ConsoleColor.Cyan; }
                else if (day.Snowfall > 0)            { ch = '░'; c = ConsoleColor.White; }
                else                                  { ch = '·'; c = ConsoleColor.DarkGray; }

                if (c != lastColor) { Console.ForegroundColor = c; lastColor = c; }
                Console.Write(ch);
            }
            Console.ResetColor();
        }

        // ── Alert flash ───────────────────────────────────────────────────────

        private static void FlashAlert(string message)
        {
            Console.SetCursorPosition(0, 24);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message.PadRight(75));
            Console.ResetColor();
        }

        // ── Utilities ─────────────────────────────────────────────────────────

        private static void WriteAt(int col, int row, string text, ConsoleColor color)
        {
            try
            {
                Console.SetCursorPosition(col, row);
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
            catch { /* ignore out-of-bounds on small terminals */ }
        }

        private static void DrawRing(int cx, int cy, int r, char sym, ConsoleColor color)
        {
            for (int deg = 0; deg < 360; deg += 8)
            {
                double rad = deg * Math.PI / 180.0;
                int x = cx + (int)(r * Math.Cos(rad));
                int y = cy + (int)(r * Math.Sin(rad) * 0.45);
                if (x >= 4 && x <= 25 && y >= 4 && y <= 24)
                    WriteAt(x, y, sym.ToString(), color);
            }
        }

        private static void PrintFlag(string label, bool active, ConsoleColor c)
        {
            if (active) { Console.ForegroundColor = c; Console.Write($"[{label}] "); }
            else        { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write($" {label}  "); }
            Console.ResetColor();
        }

        private static double NormTemp(double f) => Math.Max(0, Math.Min((f + 20) / 120.0, 1));
        private static ConsoleColor TempColor(double f)
            => f <= 20 ? ConsoleColor.DarkCyan : f <= 32 ? ConsoleColor.Cyan : ConsoleColor.Yellow;
        private static ConsoleColor SevColor(int s)
            => s >= 60 ? ConsoleColor.Red : s >= 30 ? ConsoleColor.Yellow : ConsoleColor.Green;
    }
}

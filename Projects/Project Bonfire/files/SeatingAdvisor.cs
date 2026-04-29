using System;

namespace Project_1
{
    /// <summary>
    /// Recommends seating position based on wind direction.
    /// Draws a terminal compass to visualize wind flow.
    /// </summary>
    internal class SeatingAdvisor
    {
        /// <summary>
        /// Returns the safest adjacent (perpendicular) seating positions.
        /// Wind from North pushes smoke South — so sitting South puts you
        /// in the smoke path. The safe seats are East or West (perpendicular),
        /// where smoke does not drift.
        /// </summary>
        public string GetBestDirection(string windDirection)
{
    if (windDirection == null) windDirection = "N";
    windDirection = windDirection.Trim().ToUpper();

    switch (windDirection)
    {
        case "N":   return "East or West";
        case "S":   return "East or West";
        case "E":   return "North or South";
        case "W":   return "North or South";

        case "NE":  return "Northwest or Southeast";
        case "NW":  return "Northeast or Southwest";
        case "SE":  return "Northeast or Southwest";
        case "SW":  return "Northwest or Southeast";

        default:    return "either side perpendicular to the wind";
    }
}

        /// <summary>Prints an ASCII compass showing wind origin and safe seating side.</summary>
        public void DrawCompass(string windDirection)
        {
            if (windDirection == null) windDirection = "N";
            windDirection = windDirection.Trim().ToUpper();

            string seatSide = GetBestDirection(windDirection);

            ConsoleUI.Section("Wind Compass");

            Console.WriteLine();
            ConsoleUI.SetCyan();
            Console.WriteLine("             N");
            Console.WriteLine("             |");

            // Build the middle row with FIRE in center
            string midRow = "    W  ———  FIRE  ———  E";
            Console.WriteLine(midRow);

            Console.WriteLine("             |");
            Console.WriteLine("             S");
            ConsoleUI.Reset();

            Console.WriteLine();

            // Annotate which direction wind is FROM
            ConsoleUI.SetWarn();
            Console.WriteLine($"  Wind coming FROM : {windDirection}");
            ConsoleUI.Reset();

            // Arrow showing smoke direction
            string arrowDir = GetOpposite(windDirection);
            ConsoleUI.SetFire();
            Console.WriteLine($"  Smoke drifts TO  : {arrowDir}");
            ConsoleUI.Reset();

            Console.WriteLine();
            ConsoleUI.SetGood();
            Console.WriteLine($"  ✓ Best place to sit: {seatSide} side of the fire");
            ConsoleUI.Reset();

            // Simple visual marker
            Console.WriteLine();
            DrawDirectionArrow(windDirection);
        }

        // Shows a simple directional arrow ASCII art
        private void DrawDirectionArrow(string dir)
        {
            ConsoleUI.SetDim();
            Console.WriteLine("  Smoke flow diagram:");
            ConsoleUI.Reset();

            ConsoleUI.SetFire();
            switch (dir)
            {
                case "N":
                    Console.WriteLine("       ↓ (smoke)");
                    Console.WriteLine("    [ FIRE ]");
                    Console.WriteLine("       ↑ (wind in)");
                    break;
                case "S":
                    Console.WriteLine("       ↑ (smoke)");
                    Console.WriteLine("    [ FIRE ]");
                    Console.WriteLine("       ↓ (wind in)");
                    break;
                case "E":
                    Console.WriteLine("    ← smoke  [ FIRE ]  wind in →");
                    break;
                case "W":
                    Console.WriteLine("    ← wind in  [ FIRE ]  smoke →");
                    break;
                case "NW":
                    Console.WriteLine("    ↘ (smoke going SE)");
                    Console.WriteLine("    [ FIRE ]  ↖ wind from NW");
                    break;
                case "NE":
                    Console.WriteLine("    ↙ (smoke going SW)");
                    Console.WriteLine("    [ FIRE ]  ↗ wind from NE");
                    break;
                case "SW":
                    Console.WriteLine("    ↗ (smoke going NE)");
                    Console.WriteLine("    [ FIRE ]  ↙ wind from SW");
                    break;
                case "SE":
                    Console.WriteLine("    ↖ (smoke going NW)");
                    Console.WriteLine("    [ FIRE ]  ↘ wind from SE");
                    break;
                default:
                    Console.WriteLine("    [ FIRE ]");
                    break;
            }
            ConsoleUI.Reset();
        }

        private string GetOpposite(string dir)
        {
            switch (dir)
            {
                case "N":  return "South";
                case "NE": return "Southwest";
                case "E":  return "West";
                case "SE": return "Northwest";
                case "S":  return "North";
                case "SW": return "Northeast";
                case "W":  return "East";
                case "NW": return "Southeast";
                default:   return "away from wind source";
            }
        }
    }
}
namespace Project_2
{
    internal static class GardenVisualizer
    {
        public static void Draw(IReadOnlyList<GardenEntry> entries, int rows, int cols)
        {
            ConsoleUI.Section("Garden Layout  (P=Plant  .=Empty)");

            // Column header
            Console.Write("     ");
            for (int c = 0; c < cols; c++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"  {c} ");
                Console.ResetColor();
            }
            Console.WriteLine();

            // Top border
            Console.Write("     ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+" + string.Concat(Enumerable.Repeat("---+", cols)));
            Console.ResetColor();

            for (int r = 0; r < rows; r++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"  {r}  |");
                Console.ResetColor();

                for (int c = 0; c < cols; c++)
                {
                    GardenEntry? entry = entries.FirstOrDefault(e => e.Row == r && e.Col == c);
                    if (entry != null)
                    {
                        string symbol = GetPlantSymbol(entry.PlantName);
                        ConsoleColor color = GetPlantColor(entry.PlantName);
                        Console.ForegroundColor = color;
                        Console.Write(symbol);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" . ");
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("|");
                    Console.ResetColor();
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("     +" + string.Concat(Enumerable.Repeat("---+", cols)));
                Console.ResetColor();
                Console.WriteLine();
            }

            // Legend
            Console.WriteLine();
            var planted = entries.Select(e => e.PlantName).Distinct().ToList();
            if (planted.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("  Legend: ");
                foreach (string name in planted)
                {
                    Console.ForegroundColor = GetPlantColor(name);
                    Console.Write($" {GetPlantSymbol(name).Trim()}={name}  ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine($"\n  Plots used: {entries.Count}/{rows * cols}");
        }

        public static void DrawPlantAscii(Plant p)
        {
            Console.ForegroundColor = GetPlantColor(p.Name);
            Console.WriteLine($"\n  ┌─────────────────┐");
            Console.WriteLine($"  │  {p.Emoji,-15}│");
            Console.WriteLine($"  │  {p.Name,-15}│");
            foreach (string line in p.AsciiArt)
                Console.WriteLine($"  │{line,-17}│");
            Console.WriteLine($"  └─────────────────┘");
            Console.ResetColor();
        }

        public static void DrawGardenScene(IReadOnlyList<GardenEntry> entries)
        {
            ConsoleUI.Header("MY GARDEN — SCENIC VIEW");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  ═══════════════════════════════════════════════════════");
            Console.WriteLine("  ☁           Beautiful garden in " + DateTime.Now.ToString("MMMM") + "             ☁");
            Console.WriteLine("  ═══════════════════════════════════════════════════════");
            Console.ResetColor();

            if (entries.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n  Your garden is empty. Go add some plants!");
                Console.ResetColor();
                return;
            }

            // Show ASCII art for each planted plant type
            var distinct = entries.Select(e => e.PlantName).Distinct().ToList();
            foreach (string name in distinct)
            {
                Plant? p = PlantDatabase.Find(name);
                if (p == null) continue;

                Console.ForegroundColor = GetPlantColor(name);
                Console.WriteLine($"\n  {p.Emoji} {p.Name} ({entries.Count(e => e.PlantName == name)} plots)");
                Console.ResetColor();

                foreach (string line in p.AsciiArt)
                    Console.WriteLine("    " + line);

                var entry = entries.First(e => e.PlantName == name);
                int grown = entry.DaysGrown();
                Plant? found = PlantDatabase.Find(name);
                if (found != null)
                {
                    int dth = found.DaysToHarvest;
                    int remaining = Math.Max(0, dth - grown);
                    Console.Write($"    Progress: {ConsoleUI.ProgressBar(grown, dth, 20)} ");
                    if (remaining == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("READY!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{remaining} days left");
                    }
                    Console.ResetColor();
                }
            }
        }

        private static string GetPlantSymbol(string name) => name.Length >= 3
            ? $" {name[..3].ToUpper()} "
            : $" {name.ToUpper(),-3} ";

        private static ConsoleColor GetPlantColor(string name) => name.ToLower() switch
        {
            var n when n.Contains("tomato")    => ConsoleColor.Red,
            var n when n.Contains("sunflower") => ConsoleColor.Yellow,
            var n when n.Contains("pepper")    => ConsoleColor.DarkRed,
            var n when n.Contains("carrot")    => ConsoleColor.DarkYellow,
            var n when n.Contains("basil")     => ConsoleColor.Green,
            var n when n.Contains("mint")      => ConsoleColor.Green,
            var n when n.Contains("lavender")  => ConsoleColor.Magenta,
            var n when n.Contains("marigold")  => ConsoleColor.Yellow,
            var n when n.Contains("lettuce")   => ConsoleColor.Green,
            var n when n.Contains("spinach")   => ConsoleColor.DarkGreen,
            var n when n.Contains("kale")      => ConsoleColor.DarkGreen,
            var n when n.Contains("zucchini")  => ConsoleColor.Green,
            var n when n.Contains("cucumber")  => ConsoleColor.DarkGreen,
            var n when n.Contains("bean")      => ConsoleColor.Green,
            var n when n.Contains("broccoli")  => ConsoleColor.DarkGreen,
            var n when n.Contains("chive")     => ConsoleColor.Green,
            var n when n.Contains("rosemary")  => ConsoleColor.DarkGreen,
            var n when n.Contains("zinnia")    => ConsoleColor.Magenta,
            _ => ConsoleColor.Cyan,
        };
    }
}

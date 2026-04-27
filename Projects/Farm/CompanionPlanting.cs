namespace Project_2
{
    internal static class CompanionPlanting
    {
        public static void Display(GardenManager garden)
        {
            ConsoleUI.Header("COMPANION PLANTING GUIDE");

            ConsoleUI.Section("What is Companion Planting?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Growing certain plants together can repel pests,");
            Console.WriteLine("  improve flavor, fix nitrogen, and maximize space.");
            Console.ResetColor();

            // If garden has plants, show specific advice
            if (garden.Entries.Count > 0)
            {
                ConsoleUI.Section("Companion Analysis for YOUR Garden");
                AnalyzeGarden(garden);
            }

            ConsoleUI.Section("Top Companion Pairings");
            DisplayPairings();

            ConsoleUI.Section("Three Sisters Garden (Classic Native American Method)");
            DisplayThreeSisters();

            ConsoleUI.Section("Browse Plant Companions");
            BrowsePlants();
        }

        private static void AnalyzeGarden(GardenManager garden)
        {
            var plantedNames = garden.Entries.Select(e => e.PlantName).Distinct().ToList();

            foreach (string name in plantedNames)
            {
                Plant? p = PlantDatabase.Find(name);
                if (p == null) continue;

                // Find which of their companions are also planted
                var goodNeighbors = p.CompanionPlants
                    .Where(c => plantedNames.Any(n => n.Equals(c, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
                var badNeighbors = p.AvoidPlants
                    .Where(c => plantedNames.Any(n => n.Equals(c, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                Console.Write($"\n  {p.Emoji} {p.Name}: ");
                if (goodNeighbors.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"Good neighbors: {string.Join(", ", goodNeighbors)}  ");
                    Console.ResetColor();
                }
                if (badNeighbors.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Conflicts: {string.Join(", ", badNeighbors)}");
                    Console.ResetColor();
                }
                if (goodNeighbors.Count == 0 && badNeighbors.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("No conflicts with current garden.");
                    Console.ResetColor();
                }

                // Suggest missing companions
                var suggestions = p.CompanionPlants
                    .Where(c => !plantedNames.Any(n => n.Equals(c, StringComparison.OrdinalIgnoreCase)))
                    .Take(2).ToList();
                if (suggestions.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"\n     Consider adding: {string.Join(", ", suggestions)}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        private static void DisplayPairings()
        {
            var pairings = new (string a, string b, string benefit)[]
            {
                ("Tomato",   "Basil",     "Basil repels aphids & improves tomato flavor"),
                ("Tomato",   "Marigold",  "Marigolds repel nematodes and whiteflies"),
                ("Carrot",   "Chives",    "Chives repel carrot fly — plant in rows"),
                ("Cucumber", "Sunflower", "Sunflower provides shade & trellis support"),
                ("Kale",     "Mint",      "Mint repels aphids, cabbage moths, flea beetles"),
                ("Pepper",   "Basil",     "Basil deters aphids and spider mites"),
                ("Beans",    "Corn",      "Beans fix nitrogen that corn needs"),
                ("Lettuce",  "Carrot",    "Carrots loosen soil for lettuce roots"),
                ("Spinach",  "Strawberry","Strawberries shade spinach, spinach suppresses weeds"),
                ("Zucchini", "Marigold",  "Marigolds deter squash bugs and beetles"),
            };

            Console.WriteLine($"  {"Plant A",-15} + {"Plant B",-15}  Benefit");
            ConsoleUI.Divider();

            foreach (var (a, b, benefit) in pairings)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"  {a,-15}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" + ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{b,-15}");
                Console.ResetColor();
                Console.WriteLine($"  {benefit}");
            }
        }

        private static void DisplayThreeSisters()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
                  *Corn*
                  /||||
                 / ||||
               Bean ||||
              /    ||||
             /   SQUASH
            vines cover
             the ground
");
            Console.ResetColor();

            Console.WriteLine("  Corn   — grows tall, provides structure for beans to climb");
            Console.WriteLine("  Beans  — fix nitrogen from air into soil (feeds corn)");
            Console.WriteLine("  Squash — broad leaves shade soil, retain moisture, block weeds");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  This method has been used for 1,000+ years by Native Americans.");
            Console.WriteLine("  Plant in a mound: corn center, beans around it, squash outer ring.");
            Console.ResetColor();
        }

        private static void BrowsePlants()
        {
            ConsoleUI.Prompt("Enter plant name to see companions (or ENTER to skip)");
            string input = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(input)) { ConsoleUI.WaitForKey(); return; }

            Plant? p = PlantDatabase.Find(input);
            if (p == null)
            {
                ConsoleUI.Warning($"'{input}' not found in database.");
                ConsoleUI.WaitForKey();
                return;
            }

            Console.WriteLine($"\n  {p.Emoji} {p.Name}");

            if (p.CompanionPlants.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  Good neighbors ({p.CompanionPlants.Length}): {string.Join(", ", p.CompanionPlants)}");
                Console.ResetColor();
            }
            if (p.AvoidPlants.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  Avoid planting near ({p.AvoidPlants.Length}): {string.Join(", ", p.AvoidPlants)}");
                Console.ResetColor();
            }

            ConsoleUI.WaitForKey();
        }
    }
}

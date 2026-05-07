namespace Project_2
{
    // WOW FEATURE 3: Garden Journal + Harvest Tracker
    // Users log entries (observations, harvests, issues) and track harvest countdowns
    // for everything in the garden. Full ASCII timeline visualization.
    internal class GardenJournal
    {
        private static readonly string JournalPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "garden_journal.txt");

        public void Display(GardenManager garden)
        {
            while (true)
            {
                Console.Clear();
                ConsoleUI.Header("GARDEN JOURNAL & HARVEST TRACKER");

                ConsoleUI.Section("Harvest Countdown");
                DisplayHarvestCountdown(garden);

                ConsoleUI.Section("Options");
                ConsoleUI.MenuItem("L", "View journal log");
                ConsoleUI.MenuItem("A", "Add journal entry");
                ConsoleUI.MenuItem("X", "Back to main menu");

                ConsoleUI.Prompt("Choice");
                string input = Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

                if (input == "X") break;
                if (input == "L") { Console.Clear(); ViewLog(); ConsoleUI.WaitForKey(); }
                if (input == "A") AddEntry(garden);
            }
        }

        private static void DisplayHarvestCountdown(GardenManager garden)
        {
            if (garden.Entries.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("  No plants in garden yet. Add plants in the Garden Manager.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine($"\n  {"Plant",-18} {"Planted",-12} {"Days Grown",-12} {"Progress",-24} {"Status"}");
            ConsoleUI.Divider();

            foreach (GardenEntry entry in garden.Entries)
            {
                Plant? p = PlantDatabase.Find(entry.PlantName);
                int grown = entry.DaysGrown();

                Console.Write($"  {entry.PlantName,-18} {entry.DatePlanted,-12} {grown,5} days   ");

                if (p != null)
                {
                    int dth = p.DaysToHarvest;
                    int remaining = Math.Max(0, dth - grown);
                    double pct = Math.Min(1.0, (double)grown / dth);

                    ConsoleColor barColor = pct >= 1.0 ? ConsoleColor.Green :
                                           pct >= 0.7 ? ConsoleColor.Yellow : ConsoleColor.DarkCyan;
                    Console.ForegroundColor = barColor;
                    Console.Write(ConsoleUI.ProgressBar(grown, dth, 16));
                    Console.ResetColor();

                    if (remaining == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  *** HARVEST NOW! ***");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"  {remaining} days left");
                    }
                }
                else
                {
                    Console.WriteLine("  (unknown plant)");
                }
                Console.ResetColor();
            }

            // Urgency alerts
            var readyNow = garden.Entries.Where(e =>
            {
                Plant? p = PlantDatabase.Find(e.PlantName);
                return p != null && e.DaysGrown() >= p.DaysToHarvest;
            }).ToList();

            if (readyNow.Count > 0)
            {
                Console.WriteLine();
                ConsoleUI.Success($"{readyNow.Count} plant(s) ready to harvest: " +
                    string.Join(", ", readyNow.Select(e => e.PlantName)));
            }
        }

        private void AddEntry(GardenManager garden)
        {
            Console.Clear();
            ConsoleUI.Header("ADD JOURNAL ENTRY");

            Console.WriteLine($"\n  Date: {DateTime.Now:yyyy-MM-dd HH:mm}");
            ConsoleUI.Prompt("Entry type (observation/harvest/issue/note)");
            string type = Console.ReadLine()?.Trim() ?? "note";

            ConsoleUI.Prompt("Plant name (or ALL for general note)");
            string plant = Console.ReadLine()?.Trim() ?? "General";

            ConsoleUI.Prompt("Your note");
            string note = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(note)) { ConsoleUI.Warning("Empty note, not saved."); Thread.Sleep(1000); return; }

            string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm}] [{type.ToUpper()}] [{plant}] {note}";
            AppendToLog(line);
            ConsoleUI.Success("Journal entry saved!");
            Thread.Sleep(1200);
        }

        private static void ViewLog()
        {
            ConsoleUI.Header("GARDEN JOURNAL LOG");

            if (!File.Exists(JournalPath))
            {
                ConsoleUI.Warning("No journal entries yet. Add your first entry!");
                return;
            }

            string[] lines = File.ReadAllLines(JournalPath);
            if (lines.Length == 0) { ConsoleUI.Warning("Journal is empty."); return; }

            // Show last 30 entries
            var recent = lines.TakeLast(30).ToArray();
            Console.WriteLine($"\n  Showing last {recent.Length} of {lines.Length} entries\n");

            foreach (string entry in recent)
            {
                // Color by type
                if (entry.Contains("[HARVEST]")) Console.ForegroundColor = ConsoleColor.Green;
                else if (entry.Contains("[ISSUE]")) Console.ForegroundColor = ConsoleColor.Red;
                else if (entry.Contains("[OBSERVATION]")) Console.ForegroundColor = ConsoleColor.Cyan;
                else Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("  " + entry);
                Console.ResetColor();
            }

            // Summary stats
            ConsoleUI.Divider();
            int harvests = lines.Count(l => l.Contains("[HARVEST]"));
            int issues   = lines.Count(l => l.Contains("[ISSUE]"));
            int obs      = lines.Count(l => l.Contains("[OBSERVATION]"));
            Console.WriteLine($"  Total: {lines.Length} entries  |  {harvests} harvests  |  {issues} issues  |  {obs} observations");
        }

        private static void AppendToLog(string line)
        {
            try { File.AppendAllText(JournalPath, line + Environment.NewLine); }
            catch { ConsoleUI.Error("Could not save journal entry."); }
        }
    }
}

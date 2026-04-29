using System.Text.Json;

namespace Project_2
{
    internal class GardenManager
    {
        private const int Rows = 6;
        private const int Cols = 10;

        private readonly List<GardenEntry> _entries = [];
        private static readonly string SavePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "garden_state.json");

        public GardenManager() => Load();

        public IReadOnlyList<GardenEntry> Entries => _entries;

        public bool AddPlant(string plantName, int row, int col, string notes = "")
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols) return false;
            if (_entries.Any(e => e.Row == row && e.Col == col)) return false;

            _entries.Add(new GardenEntry
            {
                PlantName = plantName,
                DatePlanted = DateTime.Now.ToString("yyyy-MM-dd"),
                Row = row, Col = col,
                Notes = notes
            });
            Save();
            return true;
        }

        public bool RemovePlant(int row, int col)
        {
            GardenEntry? entry = _entries.FirstOrDefault(e => e.Row == row && e.Col == col);
            if (entry == null) return false;
            _entries.Remove(entry);
            Save();
            return true;
        }

        public GardenEntry? GetAt(int row, int col) =>
            _entries.FirstOrDefault(e => e.Row == row && e.Col == col);

        public int RowCount => Rows;
        public int ColCount => Cols;

        private void Save()
        {
            try
            {
                string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SavePath, json);
            }
            catch { }
        }

        private void Load()
        {
            try
            {
                if (!File.Exists(SavePath)) return;
                string json = File.ReadAllText(SavePath);
                var loaded = JsonSerializer.Deserialize<List<GardenEntry>>(json);
                if (loaded != null) _entries.AddRange(loaded);
            }
            catch { }
        }

        public void DisplayGardenManage(WeatherDay? today)
        {
            ConsoleUI.Header("GARDEN MANAGER");

            while (true)
            {
                Console.Clear();
                ConsoleUI.Header("MY GARDEN");

                GardenVisualizer.Draw(_entries, Rows, Cols);

                if (today != null)
                {
                    ConsoleUI.Section("Today's Weather Advisory");
                    DisplayCareAdvice(today);
                }

                ConsoleUI.Section("Options");
                ConsoleUI.MenuItem("A", "Add a plant to a plot");
                ConsoleUI.MenuItem("R", "Remove a plant");
                ConsoleUI.MenuItem("V", "View plant details / progress");
                ConsoleUI.MenuItem("C", "Care actions  (Water / Cover / Skip)");
                ConsoleUI.MenuItem("X", "Back to main menu");

                ConsoleUI.Prompt("Choice");
                string input = Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

                if (input == "X") break;

                if (input == "A")
                {
                    Console.Clear();
                    ConsoleUI.Header("ADD PLANT TO GARDEN");
                    Console.WriteLine("\n  Choose a plant:\n");
                    var allPlants = PlantDatabase.All;
                    for (int i = 0; i < allPlants.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"  {i + 1,2}. ");
                        Console.ResetColor();
                        Console.Write($"{allPlants[i].Emoji} {allPlants[i].Name,-22}");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"[{allPlants[i].Category}]  {allPlants[i].DaysToHarvest}d to harvest");
                        Console.ResetColor();
                    }

                    ConsoleUI.Prompt("Enter number or plant name");
                    string nameInput = Console.ReadLine()?.Trim() ?? "";

                    string name;
                    if (int.TryParse(nameInput, out int plantIdx) && plantIdx >= 1 && plantIdx <= allPlants.Length)
                    {
                        name = allPlants[plantIdx - 1].Name;
                    }
                    else
                    {
                        Plant? found = PlantDatabase.Find(nameInput);
                        if (found == null) { ConsoleUI.Error($"Plant '{nameInput}' not found."); Thread.Sleep(1200); continue; }
                        name = found.Name;
                    }

                    ConsoleUI.Prompt("Row (0-5)");
                    if (!int.TryParse(Console.ReadLine(), out int r)) { ConsoleUI.Error("Invalid row."); Thread.Sleep(1000); continue; }
                    ConsoleUI.Prompt("Column (0-9)");
                    if (!int.TryParse(Console.ReadLine(), out int c)) { ConsoleUI.Error("Invalid column."); Thread.Sleep(1000); continue; }
                    ConsoleUI.Prompt("Notes (optional)");
                    string notes = Console.ReadLine() ?? "";

                    if (AddPlant(name, r, c, notes))
                        ConsoleUI.Success($"Added {name} at row {r}, col {c}.");
                    else
                        ConsoleUI.Error("Could not add — plot occupied or out of bounds.");
                    Thread.Sleep(1200);
                }
                else if (input == "R")
                {
                    ConsoleUI.Prompt("Row");
                    if (!int.TryParse(Console.ReadLine(), out int r)) continue;
                    ConsoleUI.Prompt("Column");
                    if (!int.TryParse(Console.ReadLine(), out int c)) continue;
                    if (RemovePlant(r, c)) ConsoleUI.Success("Plant removed.");
                    else ConsoleUI.Error("No plant at that location.");
                    Thread.Sleep(1200);
                }
                else if (input == "V")
                {
                    if (_entries.Count == 0) { ConsoleUI.Warning("No plants in garden yet."); Thread.Sleep(1200); continue; }
                    Console.Clear();
                    ConsoleUI.Header("PLANT PROGRESS");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"  {"#",-4} {"Plant",-20} {"Plot",-8} {"Day",-6} {"Progress",-22} Status");
                    ConsoleUI.Divider();
                    Console.ResetColor();
                    for (int i = 0; i < _entries.Count; i++)
                    {
                        var e = _entries[i];
                        Plant? pl = PlantDatabase.Find(e.PlantName);
                        int grown = e.DaysGrown();
                        bool ready = pl != null && grown >= pl.DaysToHarvest;
                        int daysLeft = pl != null ? Math.Max(0, pl.DaysToHarvest - grown) : 0;
                        Console.ForegroundColor = ready ? ConsoleColor.Green : ConsoleColor.Gray;
                        string bar = pl != null ? ConsoleUI.ProgressBar(grown, pl.DaysToHarvest, 16) : "----------------";
                        string status = ready ? "READY!" : (pl != null ? $"{daysLeft}d left" : "unknown");
                        Console.WriteLine($"  {i + 1,-4} {e.PlantName,-20} R{e.Row}C{e.Col,-6} {grown,3}d   {bar} {status}");
                        Console.ResetColor();
                    }

                    ConsoleUI.Prompt("Enter number to view full profile (or ENTER to skip)");
                    string sel = Console.ReadLine()?.Trim() ?? "";
                    if (string.IsNullOrEmpty(sel)) continue;

                    GardenEntry? entry = null;
                    if (int.TryParse(sel, out int idx) && idx >= 1 && idx <= _entries.Count)
                        entry = _entries[idx - 1];

                    if (entry == null) { ConsoleUI.Error("Invalid selection."); Thread.Sleep(1200); continue; }
                    Plant? p = PlantDatabase.Find(entry.PlantName);
                    if (p != null)
                    {
                        Console.Clear();
                        new PlantAdvisor([], []).DisplayPlantDetails(p);

                        int grown = entry.DaysGrown();
                        int remaining = Math.Max(0, p.DaysToHarvest - grown);
                        Console.WriteLine($"\n  Growth Progress:  {grown}/{p.DaysToHarvest} days");
                        Console.Write("  ");
                        Console.WriteLine(ConsoleUI.ProgressBar(grown, p.DaysToHarvest, 30));
                        Console.ForegroundColor = remaining == 0 ? ConsoleColor.Green : ConsoleColor.Yellow;
                        Console.WriteLine(remaining == 0
                            ? "  *** READY TO HARVEST! ***"
                            : $"  {remaining} days until harvest  (planted {entry.DatePlanted})");
                        Console.ResetColor();
                    }
                    ConsoleUI.WaitForKey();
                }
                else if (input == "C")
                {
                    if (_entries.Count == 0) { ConsoleUI.Warning("No plants in garden yet."); Thread.Sleep(1200); continue; }
                    Console.Clear();
                    ConsoleUI.Header("TODAY'S CARE ACTIONS");

                    if (today != null) DisplayCareAdvice(today);

                    ConsoleUI.Section("Choose an action for each plant");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("  [W] Water   [C] Cover (frost)   [S] Skip");
                    Console.ResetColor();

                    foreach (var e in _entries)
                    {
                        Plant? pl = PlantDatabase.Find(e.PlantName);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"  {e.PlantName} ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"(R{e.Row}C{e.Col}");
                        if (pl != null)
                        {
                            int grown = e.DaysGrown();
                            int remaining = Math.Max(0, pl.DaysToHarvest - grown);
                            Console.Write($"  Day {grown}/{pl.DaysToHarvest}");
                            if (remaining == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("  READY TO HARVEST");
                            }
                        }
                        Console.ResetColor();
                        Console.Write(")");

                        if (today != null)
                        {
                            string suggestion =
                                today.LowTemp <= 36 ? "  → Suggest: COVER" :
                                today.PrecipChance < 30 && today.Humidity < 60 ? "  → Suggest: WATER" :
                                "  → Suggest: SKIP";
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(suggestion);
                            Console.ResetColor();
                        }

                        Console.WriteLine();
                        ConsoleUI.Prompt("Action [W/C/S]");
                        string action = Console.ReadLine()?.Trim().ToUpperInvariant() ?? "S";

                        (string label, ConsoleColor col) = action switch
                        {
                            "W" => ("WATERED", ConsoleColor.Cyan),
                            "C" => ("COVERED", ConsoleColor.Blue),
                            _   => ("SKIPPED",  ConsoleColor.DarkGray),
                        };
                        Console.ForegroundColor = col;
                        Console.WriteLine($"  → {e.PlantName}: {label}");
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                    ConsoleUI.Success("Care actions recorded. Use Option 9 to log observations.");
                    ConsoleUI.WaitForKey();
                }
            }
        }

        private static void DisplayCareAdvice(WeatherDay today)
        {
            bool shouldWater = today.PrecipChance < 30 && today.Humidity < 60;
            bool tooCold = today.LowTemp < 40;
            bool tooHot = today.HighTemp > 90;

            if (shouldWater)
                ConsoleUI.Success($"Water your garden today! Low rain chance ({today.PrecipChance:F0}%) and dry air.");
            else
                ConsoleUI.Info("Watering:", $"Skip today — rain likely ({today.PrecipChance:F0}% chance).");

            if (tooCold)
                ConsoleUI.Warning($"Cold night ahead ({today.LowTemp:F0}°F). Cover tender seedlings with frost cloth!");
            if (tooHot)
                ConsoleUI.Warning($"Very hot day ({today.HighTemp:F0}°F). Mulch and water deeply in the morning.");
            if (today.WindSpeed > 20)
                ConsoleUI.Warning($"High winds ({today.WindSpeed:F0} mph). Stake tall plants and check supports.");
        }
    }
}

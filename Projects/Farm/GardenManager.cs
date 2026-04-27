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
                ConsoleUI.MenuItem("V", "View plant details");
                ConsoleUI.MenuItem("X", "Back to main menu");

                ConsoleUI.Prompt("Choice");
                string input = Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

                if (input == "X") break;

                if (input == "A")
                {
                    ConsoleUI.Prompt("Plant name");
                    string name = Console.ReadLine()?.Trim() ?? "";
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
                    Console.WriteLine("\n  Planted plots:");
                    foreach (var e in _entries)
                        Console.WriteLine($"  Row {e.Row}, Col {e.Col} — {e.PlantName} — Day {e.DaysGrown()} of growth");
                    ConsoleUI.Prompt("Row");
                    if (!int.TryParse(Console.ReadLine(), out int r)) continue;
                    ConsoleUI.Prompt("Column");
                    if (!int.TryParse(Console.ReadLine(), out int c)) continue;
                    var entry = GetAt(r, c);
                    if (entry == null) { ConsoleUI.Error("Nothing there."); Thread.Sleep(1200); continue; }
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

namespace Project_2
{
    // WOW FEATURE 1: Lunar Planting Guide
    // Many traditional and biodynamic gardeners plant by moon phase.
    // New Moon → root crops; Waxing → leafy greens; Full Moon → harvest
    internal static class MoonPhaseCalculator
    {
        private static readonly DateTime KnownNewMoon = new(2000, 1, 6, 18, 14, 0, DateTimeKind.Utc);
        private const double CycleLength = 29.530588853;

        public static double GetPhaseAge(DateTime date)
        {
            double days = (date.ToUniversalTime() - KnownNewMoon).TotalDays;
            double age = days % CycleLength;
            return age < 0 ? age + CycleLength : age;
        }

        public static string GetPhaseName(double age) => age switch
        {
            < 1.85  => "New Moon",
            < 7.38  => "Waxing Crescent",
            < 9.22  => "First Quarter",
            < 14.77 => "Waxing Gibbous",
            < 16.61 => "Full Moon",
            < 22.15 => "Waning Gibbous",
            < 23.99 => "Last Quarter",
            _       => "Waning Crescent",
        };

        public static string GetPhaseAscii(double age) => age switch
        {
            < 1.85  => "   ( )   ",
            < 7.38  => "  ()     ",
            < 9.22  => "  (|     ",
            < 14.77 => "  (O     ",
            < 16.61 => "   (O)   ",
            < 22.15 => "     O)  ",
            < 23.99 => "     |)  ",
            _       => "     ()  ",
        };

        public static string GetPlantingAdvice(double age) => age switch
        {
            < 1.85  => "Rest period — good for soil preparation, composting, and planning.",
            < 7.38  => "Waxing energy rising! Plant leafy greens: lettuce, spinach, kale, herbs.",
            < 9.22  => "First Quarter: excellent time for fruiting crops — tomatoes, peppers, beans.",
            < 14.77 => "Waxing Gibbous: prime time! Plant fruiting vegetables and annual flowers.",
            < 16.61 => "Full Moon! Harvest your bounty — plants at peak moisture and flavor.",
            < 22.15 => "Waning: harvest, ferment, make compost, prune trees.",
            < 23.99 => "Last Quarter: rest period, weed, prune, and prepare beds.",
            _       => "Waning Crescent: rest and soil preparation. Avoid planting.",
        };

        public static string GetBestPlantTypes(double age) => age switch
        {
            < 1.85  => "None (rest)",
            < 7.38  => "Leafy greens, herbs",
            < 9.22  => "Fruiting crops, above-ground vegetables",
            < 14.77 => "Fruiting crops, flowers",
            < 16.61 => "Harvest! (All plants at peak)",
            < 22.15 => "Root vegetables, bulbs",
            < 23.99 => "Root vegetables",
            _       => "None (rest)",
        };

        public static void DisplayLunarGuide()
        {
            ConsoleUI.Header("MOON PHASE PLANTING GUIDE");

            DateTime now = DateTime.Now;
            double age = GetPhaseAge(now);
            string phase = GetPhaseName(age);

            // Moon display
            ConsoleUI.Section("Tonight's Moon");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n        {GetPhaseAscii(age)}");
            Console.WriteLine($"\n  Phase:  {phase}");
            Console.WriteLine($"  Age:    Day {age:F1} of 29.5-day cycle");
            Console.ResetColor();

            // Progress bar
            Console.Write("  Cycle: [New");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ConsoleUI.ProgressBar(age, CycleLength, 20));
            Console.ResetColor();
            Console.WriteLine("Full]");

            ConsoleUI.Section("Planting Advice");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {GetPlantingAdvice(age)}");
            Console.ResetColor();
            Console.WriteLine($"\n  Best plants now: {GetBestPlantTypes(age)}");

            // 14-day lunar calendar
            ConsoleUI.Section("14-Day Lunar Calendar");
            Console.WriteLine($"  {"Date",-14} {"Phase",-20} {"Best Crops",-30}");
            ConsoleUI.Divider();

            for (int i = 0; i < 14; i++)
            {
                DateTime day = now.AddDays(i);
                double dayAge = GetPhaseAge(day);
                string dayPhase = GetPhaseName(dayAge);
                string crops = GetBestPlantTypes(dayAge);

                bool isToday = i == 0;
                Console.ForegroundColor = isToday ? ConsoleColor.Cyan : ConsoleColor.Gray;
                Console.Write(isToday ? "  >> " : "     ");
                Console.WriteLine($"{day:ddd MM/dd}     {dayPhase,-20} {crops}");
                Console.ResetColor();
            }

            ConsoleUI.Section("Lunar Planting Phases Explained");
            var phases = new (string name, string crops, string why)[]
            {
                ("New Moon",        "Rest/Prep",         "Low gravitational pull — soil rest"),
                ("Waxing Crescent", "Leafy greens/Herbs","Rising sap, leaves absorbing moisture"),
                ("First Quarter",   "Fruiting crops",    "Strong upward plant energy"),
                ("Waxing Gibbous",  "Flowers/Fruits",    "Peak above-ground growth energy"),
                ("Full Moon",       "HARVEST",           "Maximum moisture in plants"),
                ("Waning Gibbous",  "Root crops",        "Energy moves downward into roots"),
                ("Last Quarter",    "Root crops",        "Best root development time"),
                ("Waning Crescent", "Rest/Compost",      "Plants conserving energy"),
            };

            foreach (var (name, crops, why) in phases)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"  {name,-20}");
                Console.ResetColor();
                Console.Write($"  {crops,-22}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"  {why}");
                Console.ResetColor();
            }

            ConsoleUI.WaitForKey();
        }
    }
}

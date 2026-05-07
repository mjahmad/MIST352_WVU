namespace Project_2
{
    internal class Plant
    {
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";       // Vegetable, Herb, Flower
        public int MinZone { get; set; }
        public double MinTempF { get; set; }
        public double MaxTempF { get; set; }
        public string WaterNeeds { get; set; } = "";     // Low, Medium, High
        public string SunNeeds { get; set; } = "";       // Full Sun, Part Shade, Full Shade
        public int[] PlantingMonths { get; set; } = [];  // 1=Jan..12=Dec
        public int[] HarvestMonths { get; set; } = [];
        public int DaysToHarvest { get; set; }
        public string Description { get; set; } = "";
        public string[] CompanionPlants { get; set; } = [];
        public string[] AvoidPlants { get; set; } = [];
        public string[] AsciiArt { get; set; } = [];
        public string PlantingTip { get; set; } = "";
        public string Emoji { get; set; } = "";
    }
}

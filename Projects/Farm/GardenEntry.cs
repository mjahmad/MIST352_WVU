namespace Project_2
{
    internal class GardenEntry
    {
        public string PlantName { get; set; } = "";
        public string DatePlanted { get; set; } = "";
        public int Row { get; set; }
        public int Col { get; set; }
        public string Notes { get; set; } = "";

        public int DaysGrown()
        {
            if (DateTime.TryParse(DatePlanted, out DateTime planted))
                return (int)(DateTime.Now - planted).TotalDays;
            return 0;
        }
    }
}

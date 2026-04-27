namespace Project_2
{
    internal class HistoricalStats
    {
        public int Month { get; set; }
        public string MonthName => new DateTime(2000, Month, 1).ToString("MMMM");

        public double SumHighTemp { get; set; }
        public int CountHighTemp { get; set; }
        public double AvgHighTemp => CountHighTemp > 0 ? SumHighTemp / CountHighTemp : 0;

        public double SumLowTemp { get; set; }
        public int CountLowTemp { get; set; }
        public double AvgLowTemp => CountLowTemp > 0 ? SumLowTemp / CountLowTemp : 0;

        public double MinTemp { get; set; } = 999;

        public double TotalPrecip { get; set; }
        public int PrecipDays { get; set; }

        public double TotalSnow { get; set; }
        public int SnowDays { get; set; }

        public int FrostDays { get; set; }

        public DateTime? LastSpringFrost { get; set; }
        public DateTime? FirstFallFrost { get; set; }
    }
}

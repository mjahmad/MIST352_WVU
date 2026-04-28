using System;

namespace Project_1
{
    /// <summary>
    /// Compares tonight's conditions to historical bonfire-friendly nights
    /// in Morgantown, WV / West Virginia using NOAA GHCN averages.
    /// </summary>
    internal class HistoricalComparison
    {
        private WeatherDay _tonight;
        private NOAAService _service;

        // Historical averages for Morgantown, WV (April–October)
        // Based on NOAA Climate Normals 1991–2020
        private static readonly double[] HistAvgTempF =
        {
            /* Jan */ 35.0, /* Feb */ 37.8, /* Mar */ 46.4, /* Apr */ 56.3,
            /* May */ 65.4, /* Jun */ 73.2, /* Jul */ 77.5, /* Aug */ 76.2,
            /* Sep */ 69.0, /* Oct */ 57.5, /* Nov */ 47.1, /* Dec */ 38.0
        };

        private static readonly double[] HistAvgRainInch =
        {
            /* Jan */ 3.2, /* Feb */ 3.0, /* Mar */ 3.9, /* Apr */ 3.5,
            /* May */ 4.2, /* Jun */ 4.0, /* Jul */ 4.5, /* Aug */ 3.7,
            /* Sep */ 3.2, /* Oct */ 2.8, /* Nov */ 3.4, /* Dec */ 3.3
        };

        // Historical great bonfire months in WV (subjective but data-based)
        private static readonly string[] BonfireMonthRating =
        {
            /* Jan */ "Poor",  /* Feb */ "Poor",  /* Mar */ "Fair",  /* Apr */ "Good",
            /* May */ "Good",  /* Jun */ "Fair",  /* Jul */ "Fair",  /* Aug */ "Fair",
            /* Sep */ "Excellent", /* Oct */ "Excellent", /* Nov */ "Good", /* Dec */ "Poor"
        };

        public HistoricalComparison(WeatherDay tonight, NOAAService service)
        {
            _tonight = tonight;
            _service = service;
        }

        /// <summary>Displays the full historical comparison panel.</summary>
        public void Display()
        {
            ConsoleUI.Header("HISTORICAL BONFIRE COMPARISON");

            int month = DateTime.Today.Month;
            int idx   = month - 1; // 0-based array index

            double histTemp  = HistAvgTempF[idx];
            double histRain  = HistAvgRainInch[idx];
            string monthRating = BonfireMonthRating[idx];
            string monthName   = DateTime.Today.ToString("MMMM");

            ConsoleUI.Section("Historical Averages — " + monthName + " in Morgantown, WV");
            ConsoleUI.Row("Avg High Temp",      $"{histTemp:F1}°F  (NOAA 1991–2020)");
            ConsoleUI.Row("Avg Monthly Rain",   $"{histRain:F1} inches");
            ConsoleUI.Row("Bonfire Month Rank", monthRating);
            ConsoleUI.SectionEnd();

            ConsoleUI.Section("Tonight vs. Historical Average");

            // Temperature comparison
            double tempDiff = _tonight._temperature - histTemp;
            string tempComp = tempDiff > 0
                ? $"{tempDiff:F1}°F above average"
                : $"{Math.Abs(tempDiff):F1}°F below average";
            ConsoleColor tempColor = Math.Abs(tempDiff) < 5 ? ConsoleColor.Green : ConsoleColor.Yellow;
            ConsoleUI.Row("Tonight Temp",    $"{_tonight._temperature:F0}°F  ({tempComp})", tempColor);

            // Humidity
            ConsoleUI.Row("Tonight Humidity",  $"{_tonight._humidity:F0}%");

            // Rain chance
            ConsoleUI.Row("Tonight Rain %",    $"{_tonight._rainchance:F0}%");

            // Wind
            ConsoleUI.Row("Tonight Wind",      $"{_tonight._windspeed:F1} mph");

            ConsoleUI.SectionEnd();

            // ── Verdict ───────────────────────────────────────────────────
            ConsoleUI.Section("Historical Verdict");

            string verdict = GetHistoricalVerdict(tempDiff, monthRating);
            ConsoleUI.Info(verdict);

            // Best bonfire months
            Console.WriteLine();
            ConsoleUI.SetDim();
            Console.WriteLine("  Best bonfire months in West Virginia:");
            ConsoleUI.Reset();
            ConsoleUI.Good("September  — cool, low humidity, minimal rain");
            ConsoleUI.Good("October    — peak fall, crisp air, ideal temps");
            ConsoleUI.Good("April / May — warming up, lower humidity than summer");

            ConsoleUI.SectionEnd();

            // ── Month calendar ────────────────────────────────────────────
            DrawMonthRatingChart();
        }

        // ── private helpers ───────────────────────────────────────────────

        private string GetHistoricalVerdict(double tempDiff, string monthRating)
        {
            string month = DateTime.Today.ToString("MMMM");

            if (monthRating == "Excellent")
                return $"{month} is historically one of the best bonfire months in WV!";

            if (monthRating == "Good")
                return $"{month} is a good bonfire month. Tonight looks " +
                       (Math.Abs(tempDiff) < 5 ? "right on average." : "a bit unusual.");

            if (monthRating == "Fair")
                return $"{month} is hit-or-miss for bonfires in WV. " +
                       "Humidity and rain are the biggest factors this time of year.";

            return $"{month} is historically tough for outdoor fires in WV. " +
                   "If conditions look good tonight, take the opportunity!";
        }

        private void DrawMonthRatingChart()
        {
            ConsoleUI.Section("Monthly Bonfire Rating Calendar (WV)");
            ConsoleUI.SetDim();
            Console.WriteLine("  Month     Avg Temp   Rain    Bonfire");
            Console.WriteLine("  " + new string('─', 42));
            ConsoleUI.Reset();

            string[] months = { "Jan","Feb","Mar","Apr","May","Jun",
                                 "Jul","Aug","Sep","Oct","Nov","Dec" };
            int currentMonth = DateTime.Today.Month;

            for (int i = 0; i < 12; i++)
            {
                bool isNow = (i + 1 == currentMonth);

                if (isNow)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.Write(isNow ? "  ► " : "    ");
                ConsoleUI.Reset();

                Console.Write(months[i].PadRight(6));
                Console.Write($"{HistAvgTempF[i],5:F0}°F     ");
                Console.Write($"{HistAvgRainInch[i],3:F1}in   ");

                string rating = BonfireMonthRating[i];
                ConsoleColor rc = rating == "Excellent" ? ConsoleColor.Green
                                : rating == "Good"      ? ConsoleColor.Green
                                : rating == "Fair"      ? ConsoleColor.Yellow
                                :                         ConsoleColor.Red;
                Console.ForegroundColor = rc;
                Console.WriteLine(rating);
                ConsoleUI.Reset();
            }

            ConsoleUI.SectionEnd();
        }
    }
}

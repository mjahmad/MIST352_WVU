using System;

namespace Project_1
{
    /// <summary>
    /// Fun feature that rates the night for s'mores quality
    /// based on fire score, comfort, and overall conditions.
    /// </summary>
    internal class SmoresMode
    {
        private WeatherDay       _tonight;
        private FireScoreCalculator _calculator;

        public SmoresMode(WeatherDay tonight, FireScoreCalculator calculator)
        {
            _tonight    = tonight;
            _calculator = calculator;
        }

        /// <summary>Returns the s'mores rating label.</summary>
        public string GetSmoresRating()
        {
            int score = _calculator.TotalScore;

            if (score >= 88) return "ELITE";
            if (score >= 72) return "PRIME";
            if (score >= 55) return "SOLID";
            if (score >= 38) return "MID";
            return "NOT TONIGHT";
        }

        /// <summary>Returns the emoji/symbol for the rating.</summary>
        public string GetSmoresEmoji()
        {
            switch (GetSmoresRating())
            {
                case "ELITE":       return "★★★★★";
                case "PRIME":       return "★★★★☆";
                case "SOLID":       return "★★★☆☆";
                case "MID":         return "★★☆☆☆";
                default:            return "✗✗✗✗✗";
            }
        }

        /// <summary>Returns a flavour description of tonight's s'mores potential.</summary>
        public string GetSmoresDescription()
        {
            string rating = GetSmoresRating();
            switch (rating)
            {
                case "ELITE":
                    return "Perfect heat, no wind, beautiful night.\n" +
                           "  Your marshmallows will toast to golden perfection.\n" +
                           "  Conditions don't get better than this.";
                case "PRIME":
                    return "Great night for s'mores. Fire will be steady,\n" +
                           "  marshmallows will toast evenly. Minor breeze only.";
                case "SOLID":
                    return "Decent s'mores night. Fire may flicker a bit.\n" +
                           "  Stay patient — you'll get a good toast going.";
                case "MID":
                    return "S'mores are possible but tricky. Wind or chill\n" +
                           "  may make roasting inconsistent. Worth a try anyway.";
                default:
                    return "Not a s'mores night. Rain or wind will make it\n" +
                           "  very difficult. Consider indoor alternatives tonight.";
            }
        }

        /// <summary>Returns a chocolate pairing recommendation based on temp.</summary>
        public string GetChocolateTip()
        {
            double temp = _tonight._temperature;

            if (temp < 50) return "Cold night — use dark chocolate (holds up better in cold).";
            if (temp < 65) return "Milk chocolate is perfect for tonight's temps.";
            if (temp < 75) return "Any chocolate works — classic milk chocolate recommended.";
            return "Warm night — keep chocolate in a cool bag so it doesn't melt.";
        }

        /// <summary>Displays the full s'mores mode panel.</summary>
        public void Display()
        {
            ConsoleUI.Header("S'MORES MODE");

            DrawSmoresArt();

            string rating = GetSmoresRating();
            ConsoleColor color = GetRatingColor(rating);

            ConsoleUI.Section("S'mores Rating");

            Console.Write("  Rating  : ");
            Console.ForegroundColor = color;
            Console.Write(rating.PadRight(15));
            ConsoleUI.Reset();
            Console.WriteLine(GetSmoresEmoji());

            Console.WriteLine();
            ConsoleUI.SetDim();
            Console.Write("  ");
            ConsoleUI.Reset();
            Console.WriteLine(GetSmoresDescription());

            ConsoleUI.SectionEnd();

            ConsoleUI.Section("Tonight's Conditions for S'mores");
            ConsoleUI.Row("Fire Score",   $"{_calculator.TotalScore}/100");
            ConsoleUI.Row("Temperature",  $"{_tonight._temperature:F0}°F");
            ConsoleUI.Row("Wind",         $"{_tonight._windspeed:F1} mph");
            ConsoleUI.Row("Rain Chance",  $"{_tonight._rainchance:F0}%");
            ConsoleUI.SectionEnd();

            ConsoleUI.Section("Chocolate Pairing Tip");
            ConsoleUI.Info(GetChocolateTip());
            ConsoleUI.SectionEnd();

            ConsoleUI.Section("Pro S'mores Tips");
            ConsoleUI.Good("Let the fire burn down to coals — not open flame.");
            ConsoleUI.Good("Rotate marshmallow slowly 6–8 inches above coals.");
            ConsoleUI.Good("Graham crackers: honey or cinnamon both work great.");
            ConsoleUI.Good("Reese's cups instead of chocolate = game changer.");
            ConsoleUI.SectionEnd();
        }

        // ── private helpers ───────────────────────────────────────────────

        private ConsoleColor GetRatingColor(string rating)
        {
            switch (rating)
            {
                case "ELITE": return ConsoleColor.Green;
                case "PRIME": return ConsoleColor.Green;
                case "SOLID": return ConsoleColor.Yellow;
                case "MID":   return ConsoleColor.Yellow;
                default:      return ConsoleColor.Red;
            }
        }

        private void DrawSmoresArt()
        {
            ConsoleUI.SetWarn();
            Console.WriteLine();
            Console.WriteLine("       /\\  /\\  /\\        ");
            Console.WriteLine("      /  \\/  \\/  \\   s'mores time?");
            Console.WriteLine("     |  Graham   |       ");
            Console.WriteLine("     |  Cracker  |  🍫 + 🍬 + 🔥");
            Console.WriteLine("      \\__________/       ");
            ConsoleUI.Reset();
            Console.WriteLine();
        }
    }
}

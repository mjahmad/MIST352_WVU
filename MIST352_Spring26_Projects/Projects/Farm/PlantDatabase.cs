namespace Project_2
{
    internal static class PlantDatabase
    {
        public static readonly Plant[] All =
        [
            // ── Vegetables ────────────────────────────────────────────
            new Plant
            {
                Name = "Tomato", Category = "Vegetable", Emoji = "[TOM]",
                MinZone = 5, MinTempF = 55, MaxTempF = 95,
                WaterNeeds = "High", SunNeeds = "Full Sun",
                PlantingMonths = [4, 5, 6], HarvestMonths = [7, 8, 9, 10],
                DaysToHarvest = 75,
                Description = "America's favorite garden vegetable. Loves heat and sun.",
                CompanionPlants = ["Basil", "Marigold", "Carrot", "Parsley"],
                AvoidPlants = ["Fennel", "Broccoli", "Cabbage"],
                PlantingTip = "Plant deep — bury 2/3 of stem for stronger roots.",
                AsciiArt = [
                    "     ( o )    ",
                    "    (     )   ",
                    "     | | |    ",
                    "   --+-+-+--  ",
                    "   |  |||  |  ",
                ]
            },
            new Plant
            {
                Name = "Cucumber", Category = "Vegetable", Emoji = "[CUC]",
                MinZone = 4, MinTempF = 60, MaxTempF = 90,
                WaterNeeds = "High", SunNeeds = "Full Sun",
                PlantingMonths = [5, 6], HarvestMonths = [7, 8, 9],
                DaysToHarvest = 60,
                Description = "Fast-growing vine. Needs a trellis and consistent water.",
                CompanionPlants = ["Sunflower", "Dill", "Beans", "Marigold"],
                AvoidPlants = ["Sage", "Potato"],
                PlantingTip = "Sow seeds 1\" deep after last frost. Use a trellis to save space.",
                AsciiArt = [
                    "   /~~~~~/    ",
                    "  / ~~~~~ \\   ",
                    " |  ~~~~~  |  ",
                    "  \\_______/   ",
                    "     ||||     ",
                ]
            },
            new Plant
            {
                Name = "Pepper (Bell)", Category = "Vegetable", Emoji = "[PEP]",
                MinZone = 5, MinTempF = 60, MaxTempF = 90,
                WaterNeeds = "Medium", SunNeeds = "Full Sun",
                PlantingMonths = [4, 5, 6], HarvestMonths = [8, 9, 10],
                DaysToHarvest = 80,
                Description = "Sweet bell peppers in red, yellow, green, or orange.",
                CompanionPlants = ["Basil", "Carrot", "Tomato"],
                AvoidPlants = ["Fennel", "Beans"],
                PlantingTip = "Start indoors 8 weeks before last frost for best results.",
                AsciiArt = [
                    "    ( | )     ",
                    "   / | | \\   ",
                    "  |  | |  |   ",
                    "  |  | |  |   ",
                    "   \\_____/    ",
                ]
            },
            new Plant
            {
                Name = "Lettuce", Category = "Vegetable", Emoji = "[LET]",
                MinZone = 3, MinTempF = 40, MaxTempF = 75,
                WaterNeeds = "Medium", SunNeeds = "Part Shade",
                PlantingMonths = [3, 4, 8, 9], HarvestMonths = [5, 6, 10, 11],
                DaysToHarvest = 50,
                Description = "Cool-season crop. Bolts (goes to seed) in summer heat.",
                CompanionPlants = ["Carrot", "Radish", "Chives"],
                AvoidPlants = ["Celery"],
                PlantingTip = "Sow every 2 weeks for continuous harvest. Shade in summer.",
                AsciiArt = [
                    "  \\  |||  /   ",
                    "   \\ ||| /    ",
                    "    \\|||/     ",
                    "     |||      ",
                    "    _|||_     ",
                ]
            },
            new Plant
            {
                Name = "Spinach", Category = "Vegetable", Emoji = "[SPN]",
                MinZone = 3, MinTempF = 35, MaxTempF = 70,
                WaterNeeds = "Medium", SunNeeds = "Part Shade",
                PlantingMonths = [3, 4, 9, 10], HarvestMonths = [5, 6, 11],
                DaysToHarvest = 45,
                Description = "Nutritious cool-season green. Can tolerate light frost.",
                CompanionPlants = ["Strawberry", "Peas", "Beans"],
                AvoidPlants = [],
                PlantingTip = "Direct sow as soon as soil can be worked. Loves cool nights.",
                AsciiArt = [
                    "   /\\ /\\ /\\   ",
                    "  /  V  V  \\  ",
                    " | leaf leaf | ",
                    "  \\   |||  /  ",
                    "    \\_|||_/   ",
                ]
            },
            new Plant
            {
                Name = "Carrot", Category = "Vegetable", Emoji = "[CAR]",
                MinZone = 3, MinTempF = 40, MaxTempF = 80,
                WaterNeeds = "Medium", SunNeeds = "Full Sun",
                PlantingMonths = [3, 4, 5, 8], HarvestMonths = [6, 7, 10, 11],
                DaysToHarvest = 75,
                Description = "Root vegetable that sweetens after a light frost.",
                CompanionPlants = ["Lettuce", "Chives", "Rosemary", "Tomato"],
                AvoidPlants = ["Dill"],
                PlantingTip = "Loosen soil 12\" deep. Thin seedlings to 3\" apart.",
                AsciiArt = [
                    "   /\\  /\\     ",
                    "  /  \\/  \\    ",
                    " |    ||   |  ",
                    "  \\   ||  /   ",
                    "    \\ || /    ",
                    "     \\||/     ",
                    "      \\/      ",
                ]
            },
            new Plant
            {
                Name = "Kale", Category = "Vegetable", Emoji = "[KAL]",
                MinZone = 3, MinTempF = 25, MaxTempF = 75,
                WaterNeeds = "Medium", SunNeeds = "Full Sun",
                PlantingMonths = [3, 4, 7, 8], HarvestMonths = [5, 6, 7, 9, 10, 11, 12],
                DaysToHarvest = 55,
                Description = "Hardy superfood. Tastes sweeter after frost. Very nutritious.",
                CompanionPlants = ["Beet", "Celery", "Cucumber", "Onion"],
                AvoidPlants = ["Tomato", "Strawberry", "Beans"],
                PlantingTip = "Harvest outer leaves to encourage continued growth.",
                AsciiArt = [
                    "  /\\/\\/\\/\\    ",
                    " /  curly  \\   ",
                    "|   leaves  |  ",
                    " \\   |||   /   ",
                    "  \\__|__|__/   ",
                ]
            },
            new Plant
            {
                Name = "Zucchini", Category = "Vegetable", Emoji = "[ZUC]",
                MinZone = 4, MinTempF = 60, MaxTempF = 95,
                WaterNeeds = "High", SunNeeds = "Full Sun",
                PlantingMonths = [5, 6], HarvestMonths = [7, 8, 9],
                DaysToHarvest = 55,
                Description = "Prolific producer. One plant can feed a family all summer.",
                CompanionPlants = ["Beans", "Corn", "Marigold", "Nasturtium"],
                AvoidPlants = ["Potato"],
                PlantingTip = "Plant 2-3 plants — they cross-pollinate. Harvest at 6-8\".",
                AsciiArt = [
                    "  ___________  ",
                    " /  ~  ~  ~  \\ ",
                    "|  striped    | ",
                    " \\___________/ ",
                    "      |||      ",
                ]
            },
            new Plant
            {
                Name = "Green Beans", Category = "Vegetable", Emoji = "[GBN]",
                MinZone = 3, MinTempF = 60, MaxTempF = 85,
                WaterNeeds = "Medium", SunNeeds = "Full Sun",
                PlantingMonths = [5, 6, 7], HarvestMonths = [7, 8, 9],
                DaysToHarvest = 55,
                Description = "Easy to grow. Bush types need no support, pole types do.",
                CompanionPlants = ["Carrot", "Corn", "Cucumber", "Strawberry"],
                AvoidPlants = ["Onion", "Fennel", "Sunflower"],
                PlantingTip = "Direct sow after frost. Pick regularly to encourage production.",
                AsciiArt = [
                    "  | | | | |   ",
                    " /|/|/|/|/|\\  ",
                    "/ leaf leaf  \\ ",
                    "\\  bean bean / ",
                    " \\___________/ ",
                ]
            },
            new Plant
            {
                Name = "Broccoli", Category = "Vegetable", Emoji = "[BRO]",
                MinZone = 3, MinTempF = 40, MaxTempF = 75,
                WaterNeeds = "High", SunNeeds = "Full Sun",
                PlantingMonths = [3, 4, 7, 8], HarvestMonths = [5, 6, 10, 11],
                DaysToHarvest = 80,
                Description = "Cool-season brassica. Cut the main head to get side shoots.",
                CompanionPlants = ["Celery", "Potato", "Beet", "Onion"],
                AvoidPlants = ["Tomato", "Strawberry", "Beans"],
                PlantingTip = "Harvest when heads are tight and dark green, before flowers open.",
                AsciiArt = [
                    "  ***  ***    ",
                    " * o * o *    ",
                    "  * o * o *   ",
                    "    |||||     ",
                    "    |||||     ",
                ]
            },

            // ── Herbs ─────────────────────────────────────────────────
            new Plant
            {
                Name = "Basil", Category = "Herb", Emoji = "[BAS]",
                MinZone = 9, MinTempF = 60, MaxTempF = 90,
                WaterNeeds = "Medium", SunNeeds = "Full Sun",
                PlantingMonths = [5, 6], HarvestMonths = [6, 7, 8, 9, 10],
                DaysToHarvest = 25,
                Description = "King of herbs. Annual in zone 6 — loves heat and hates frost.",
                CompanionPlants = ["Tomato", "Pepper", "Oregano"],
                AvoidPlants = ["Sage"],
                PlantingTip = "Pinch flower buds to keep leaves coming. Pick from top down.",
                AsciiArt = [
                    "  (  )(  )    ",
                    " ( leaf leaf ) ",
                    "  ( )( )( )   ",
                    "    ||||      ",
                    "   _||||_     ",
                ]
            },
            new Plant
            {
                Name = "Mint", Category = "Herb", Emoji = "[MNT]",
                MinZone = 3, MinTempF = 40, MaxTempF = 85,
                WaterNeeds = "High", SunNeeds = "Part Shade",
                PlantingMonths = [4, 5], HarvestMonths = [5, 6, 7, 8, 9],
                DaysToHarvest = 90,
                Description = "Vigorous spreader! Grow in containers to control spreading.",
                CompanionPlants = ["Tomato", "Cabbage", "Peas"],
                AvoidPlants = [],
                PlantingTip = "ALWAYS plant in containers — mint will take over your garden!",
                AsciiArt = [
                    "  ()()()()    ",
                    " (cool leaves) ",
                    " (   ||||   ) ",
                    "      ||      ",
                    "    ==||==    ",
                ]
            },
            new Plant
            {
                Name = "Rosemary", Category = "Herb", Emoji = "[ROS]",
                MinZone = 7, MinTempF = 30, MaxTempF = 90,
                WaterNeeds = "Low", SunNeeds = "Full Sun",
                PlantingMonths = [4, 5, 6], HarvestMonths = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
                DaysToHarvest = 80,
                Description = "Drought-tolerant evergreen herb. Overwinter indoors in Zone 6.",
                CompanionPlants = ["Sage", "Carrot", "Beans", "Cabbage"],
                AvoidPlants = ["Mint", "Pumpkin"],
                PlantingTip = "Excellent drainage is critical. Bring indoors before hard frost.",
                AsciiArt = [
                    "  /\\ /\\ /\\    ",
                    " / needles \\   ",
                    "/  woody   \\   ",
                    "\\  stem    /   ",
                    " \\_________/  ",
                ]
            },
            new Plant
            {
                Name = "Lavender", Category = "Herb", Emoji = "[LAV]",
                MinZone = 5, MinTempF = 20, MaxTempF = 85,
                WaterNeeds = "Low", SunNeeds = "Full Sun",
                PlantingMonths = [4, 5], HarvestMonths = [6, 7, 8],
                DaysToHarvest = 90,
                Description = "Fragrant perennial. Attracts pollinators and repels pests.",
                CompanionPlants = ["Roses", "Vegetables", "Marigold"],
                AvoidPlants = ["Mint"],
                PlantingTip = "Needs excellent drainage. Do not overwater. Prune after bloom.",
                AsciiArt = [
                    "   *  *  *    ",
                    "  **  **  **  ",
                    " * purple  *  ",
                    "  spikes   *  ",
                    "   |||||      ",
                ]
            },
            new Plant
            {
                Name = "Chives", Category = "Herb", Emoji = "[CHV]",
                MinZone = 3, MinTempF = 35, MaxTempF = 90,
                WaterNeeds = "Medium", SunNeeds = "Full Sun",
                PlantingMonths = [3, 4, 5], HarvestMonths = [4, 5, 6, 7, 8, 9, 10],
                DaysToHarvest = 30,
                Description = "Hardy perennial herb. Beautiful purple blooms attract bees.",
                CompanionPlants = ["Carrot", "Tomato", "Pepper", "Apple"],
                AvoidPlants = ["Beans", "Peas"],
                PlantingTip = "Cut back to 2\" to encourage fresh growth. Flowers are edible!",
                AsciiArt = [
                    " | | | | | |  ",
                    " | | | | | |  ",
                    " | | | | | |  ",
                    " | | | | | |  ",
                    " |_|_|_|_|_|  ",
                ]
            },

            // ── Flowers ───────────────────────────────────────────────
            new Plant
            {
                Name = "Sunflower", Category = "Flower", Emoji = "[SUN]",
                MinZone = 3, MinTempF = 60, MaxTempF = 95,
                WaterNeeds = "Low", SunNeeds = "Full Sun",
                PlantingMonths = [5, 6], HarvestMonths = [8, 9, 10],
                DaysToHarvest = 90,
                Description = "Towering annual that follows the sun. Seeds attract birds.",
                CompanionPlants = ["Cucumber", "Squash", "Tomato"],
                AvoidPlants = ["Potato", "Beans"],
                PlantingTip = "Direct sow after frost. Water deeply but infrequently.",
                AsciiArt = [
                    "  \\  |  /     ",
                    " --( O )--    ",
                    "  /  |  \\     ",
                    "     |        ",
                    "     |        ",
                    "     |        ",
                ]
            },
            new Plant
            {
                Name = "Marigold", Category = "Flower", Emoji = "[MAR]",
                MinZone = 3, MinTempF = 50, MaxTempF = 90,
                WaterNeeds = "Low", SunNeeds = "Full Sun",
                PlantingMonths = [4, 5, 6], HarvestMonths = [6, 7, 8, 9, 10],
                DaysToHarvest = 55,
                Description = "Pest-repelling powerhouse. Plant around vegetables for protection.",
                CompanionPlants = ["Tomato", "Pepper", "Cucumber", "Basil"],
                AvoidPlants = ["Beans"],
                PlantingTip = "Deadhead spent blooms to extend flowering all season.",
                AsciiArt = [
                    "   *** ***    ",
                    "  *orange*    ",
                    "   * O *      ",
                    "    * *       ",
                    "     |        ",
                ]
            },
            new Plant
            {
                Name = "Zinnia", Category = "Flower", Emoji = "[ZIN]",
                MinZone = 3, MinTempF = 60, MaxTempF = 95,
                WaterNeeds = "Low", SunNeeds = "Full Sun",
                PlantingMonths = [5, 6], HarvestMonths = [7, 8, 9, 10],
                DaysToHarvest = 65,
                Description = "Heat-loving annual in vivid colors. Excellent cut flower.",
                CompanionPlants = ["Tomato", "Pepper"],
                AvoidPlants = [],
                PlantingTip = "Direct sow after last frost. Cutting encourages more blooms.",
                AsciiArt = [
                    "   /\\ /\\      ",
                    " /  \\  \\ \\   ",
                    "| vibrant  |  ",
                    " \\  /\\  / /  ",
                    "   \\/  \\/    ",
                    "      |       ",
                ]
            },
            new Plant
            {
                Name = "Black-Eyed Susan", Category = "Flower", Emoji = "[BES]",
                MinZone = 3, MinTempF = 30, MaxTempF = 90,
                WaterNeeds = "Low", SunNeeds = "Full Sun",
                PlantingMonths = [4, 5], HarvestMonths = [7, 8, 9, 10],
                DaysToHarvest = 90,
                Description = "Native perennial wildflower. Drought tolerant and pollinator magnet.",
                CompanionPlants = ["Coneflower", "Lavender", "Salvia"],
                AvoidPlants = [],
                PlantingTip = "Plant once, enjoy for years. Self-seeds readily.",
                AsciiArt = [
                    "  \\  * *  /   ",
                    " --( dark )--  ",
                    "  /  * *  \\   ",
                    "      |       ",
                    "      |       ",
                ]
            },
        ];

        public static Plant? Find(string name) =>
            All.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}

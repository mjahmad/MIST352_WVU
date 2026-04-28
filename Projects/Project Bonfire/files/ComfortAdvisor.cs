using System;
using System.Collections.Generic;

namespace Project_1
{
    /// <summary>
    /// Recommends what to bring or wear to a bonfire
    /// based on temperature, humidity, and forecast conditions.
    /// </summary>
    internal class ComfortAdvisor
    {
        private WeatherDay _weather;

        public ComfortAdvisor(WeatherDay weather)
        {
            _weather = weather;
        }

        /// <summary>Displays the full comfort recommendation panel.</summary>
        public void Display()
        {
            ConsoleUI.Header("COMFORT ADVISOR");

            List<string> bringList  = BuildBringList();
            List<string> wearList   = BuildWearList();
            List<string> avoidList  = BuildAvoidList();
            List<string> extraTips  = BuildExtraTips();

            // ── Bring list ────────────────────────────────────────────────
            ConsoleUI.Section("What to Bring");
            foreach (string item in bringList)
            {
                ConsoleUI.Good(item);
            }
            ConsoleUI.SectionEnd();

            // ── Wear list ─────────────────────────────────────────────────
            ConsoleUI.Section("What to Wear");
            foreach (string item in wearList)
            {
                ConsoleUI.Good(item);
            }
            ConsoleUI.SectionEnd();

            // ── Avoid list ────────────────────────────────────────────────
            if (avoidList.Count > 0)
            {
                ConsoleUI.Section("Avoid / Leave at Home");
                foreach (string item in avoidList)
                {
                    ConsoleUI.Warn(item);
                }
                ConsoleUI.SectionEnd();
            }

            // ── Extra tips ────────────────────────────────────────────────
            if (extraTips.Count > 0)
            {
                ConsoleUI.Section("Comfort Tips");
                foreach (string tip in extraTips)
                {
                    ConsoleUI.Info(tip);
                }
                ConsoleUI.SectionEnd();
            }
        }

        // ── private builders ──────────────────────────────────────────────

        private List<string> BuildBringList()
        {
            List<string> list = new List<string>();

            list.Add("Water bottle (stay hydrated!)");
            list.Add("Snacks / s'mores supplies");
            list.Add("Flashlight or headlamp");

            if (_weather._rainchance > 25)
                list.Add("Rain poncho or umbrella (just in case)");

            if (_weather._temperature < 55)
                list.Add("Extra blanket (it's chilly!)");
            else if (_weather._temperature < 65)
                list.Add("Light blanket");

            if (_weather._humidity > 65 || IsLateSpring())
                list.Add("Bug spray / insect repellent");

            if (_weather._windspeed > 8)
                list.Add("Windproof lighter or extra matches");

            list.Add("Camp chairs or seating");
            list.Add("Phone charger / portable battery");

            return list;
        }

        private List<string> BuildWearList()
        {
            List<string> list = new List<string>();

            double temp = _weather._temperature;

            if (temp < 45)
            {
                list.Add("Heavy winter coat");
                list.Add("Thermal layers underneath");
                list.Add("Warm hat and gloves");
                list.Add("Insulated boots");
            }
            else if (temp < 55)
            {
                list.Add("Heavy hoodie or fleece jacket");
                list.Add("Long pants (jeans or thermals)");
                list.Add("Closed-toe shoes or boots");
                list.Add("Light gloves if you run cold");
            }
            else if (temp < 65)
            {
                list.Add("Hoodie or light jacket");
                list.Add("Jeans or long pants");
                list.Add("Sneakers or casual boots");
            }
            else if (temp < 75)
            {
                list.Add("Light long-sleeve shirt");
                list.Add("Comfortable pants");
                list.Add("You'll be fine in layers");
            }
            else
            {
                list.Add("T-shirt and shorts are fine");
                list.Add("Light breathable clothing");
                list.Add("Sandals or sneakers");
            }

            return list;
        }

        private List<string> BuildAvoidList()
        {
            List<string> list = new List<string>();

            if (_weather._temperature < 55)
                list.Add("Shorts — too cold tonight");

            if (_weather._windspeed > 10)
                list.Add("Loose / flowy clothing near the fire — wind hazard");

            if (_weather._rainchance > 50)
                list.Add("Suede or leather items — rain likely");

            // Synthetic fabrics near fire are a safety concern
            list.Add("Synthetic fabrics directly near the fire (polyester melts)");

            return list;
        }

        private List<string> BuildExtraTips()
        {
            List<string> list = new List<string>();

            if (_weather._humidity < 30)
                list.Add("Very dry tonight — apply lip balm and drink extra water.");

            if (_weather._windspeed > 8)
                list.Add("Windy conditions — sit upwind and keep hair tied back.");

            if (_weather._temperature < 50 && _weather._temperature >= 35)
                list.Add("Cold night ahead — position yourself close to the fire.");

            if (_weather._rainchance > 30 && _weather._rainchance <= 55)
                list.Add("Light rain possible — set up a tarp as backup overhead cover.");

            list.Add("Sit at least 3 feet from the fire edge for comfort and safety.");

            if (IsLateSpring() || IsSummer())
                list.Add("Mosquitoes active this time of year — reapply bug spray every 2 hrs.");

            return list;
        }

        private bool IsLateSpring()
        {
            int month = DateTime.Today.Month;
            return month >= 4 && month <= 6;
        }

        private bool IsSummer()
        {
            int month = DateTime.Today.Month;
            return month >= 6 && month <= 8;
        }

        /// <summary>Returns a short comfort summary string.</summary>
        public string GetComfortLevel()
        {
            double temp = _weather._temperature;

            if (temp >= 58 && temp <= 72 && _weather._humidity < 65)
                return "Very Comfortable";
            if (temp >= 50 && temp <= 80)
                return "Comfortable with layers";
            if (temp < 50)
                return "Chilly — bundle up";
            if (temp > 80)
                return "Warm — light clothing";
            return "Moderate";
        }
    }
}

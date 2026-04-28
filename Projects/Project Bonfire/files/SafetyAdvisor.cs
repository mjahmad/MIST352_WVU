using System;
using System.Collections.Generic;

namespace Project_1
{
    /// <summary>
    /// Displays a comprehensive campfire safety advisory panel.
    /// Uses FireSafety for the logic; this class handles display only.
    /// </summary>
    internal class SafetyAdvisor
    {
        private WeatherDay _tonight;
        private FireSafety _safety;

        public SafetyAdvisor(WeatherDay tonight)
        {
            _tonight = tonight;
            _safety  = new FireSafety();
        }

        /// <summary>Displays the full safety advisor panel.</summary>
        public void Display()
        {
            ConsoleUI.Header("CAMPFIRE SAFETY ADVISOR");

            DrawOverallStatus();
            DrawWeatherWarnings();
            DrawSafetyChecklist();
            DrawWVFireLawReminder();
        }

        // ── private sections ──────────────────────────────────────────────

        private void DrawOverallStatus()
        {
            ConsoleUI.Section("Overall Safety Level");

            string level = _safety.GetSafetyLevel(_tonight);
            ConsoleColor color = level == "SAFE"        ? ConsoleColor.Green
                               : level == "ACCEPTABLE"  ? ConsoleColor.Green
                               : level == "USE CAUTION" ? ConsoleColor.Yellow
                               :                          ConsoleColor.Red;

            // Big status box
            Console.WriteLine();
            Console.ForegroundColor = color;
            Console.WriteLine("  ┌────────────────────────────┐");
            Console.Write("  │   STATUS:  ");
            Console.Write(level.PadRight(16));
            Console.WriteLine("│");
            Console.WriteLine("  └────────────────────────────┘");
            ConsoleUI.Reset();
            Console.WriteLine();

            ConsoleUI.Row("Wind Speed",  $"{_tonight._windspeed:F1} mph  (limit: {_safety._maxwind} mph)",
                          _tonight._windspeed > _safety._maxwind ? ConsoleColor.Red : ConsoleColor.Green);

            ConsoleUI.Row("Rain Chance", $"{_tonight._rainchance:F0}%",
                          _tonight._rainchance > 40 ? ConsoleColor.Yellow : ConsoleColor.Green);

            ConsoleUI.Row("Rainfall",    _tonight._rainfall > 0 ? "YES — precipitation expected"
                                                                 : "None — clear",
                          _tonight._rainfall > 0 ? ConsoleColor.Red : ConsoleColor.Green);

            ConsoleUI.SectionEnd();
        }

        private void DrawWeatherWarnings()
        {
            List<string> warnings = _safety.GetWarnings(_tonight);

            ConsoleUI.Section("Weather Warnings");

            if (warnings.Count == 0)
            {
                ConsoleUI.Good("No significant weather warnings tonight.");
                ConsoleUI.Good("Conditions are acceptable for a bonfire.");
            }
            else
            {
                foreach (string w in warnings)
                    ConsoleUI.Warn(w);
            }

            ConsoleUI.SectionEnd();
        }

        private void DrawSafetyChecklist()
        {
            ConsoleUI.Section("Pre-Bonfire Safety Checklist");

            ConsoleUI.Good("Keep a bucket of water or garden hose nearby.");
            ConsoleUI.Good("Clear a 10-foot radius around the fire pit.");
            ConsoleUI.Good("Never light a fire in windy conditions (>20 mph).");
            ConsoleUI.Good("Never leave the bonfire unattended.");
            ConsoleUI.Good("Keep children and pets a safe distance from fire.");
            ConsoleUI.Good("Fully extinguish fire — stir ashes, add water until cool.");
            ConsoleUI.Good("Do not burn trash, treated wood, or yard waste.");
            ConsoleUI.Good("Have a shovel nearby to smother flames if needed.");

            ConsoleUI.SectionEnd();
        }

        private void DrawWVFireLawReminder()
        {
            ConsoleUI.Section("West Virginia Outdoor Fire Reminders");

            ConsoleUI.Info("WV DNR may restrict open burning during dry periods.");
            ConsoleUI.Info("Always check local county burn bans before lighting.");
            ConsoleUI.Info("Residential fire pits: check your city or HOA rules.");
            ConsoleUI.Info("National Forest land: fires only in designated rings.");
            Console.WriteLine();
            ConsoleUI.SetDim();
            Console.WriteLine("  Reference: wvdnr.gov / local fire marshal office");
            ConsoleUI.Reset();

            ConsoleUI.SectionEnd();
        }
    }
}

using System;
using System.Net;

namespace WVU_Event_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            /***************************************************************
             * PROGRAM: Smart Event Planner (WVU)
             * PURPOSE:
             * This program helps student organizations decide whether
             * to proceed with outdoor events based on weather conditions.
             *
             * CONCEPTS COVERED:
             * - Arrays
             * - Loops (while)
             * - Switch statements
             * - Methods (ALL types)
             *
             * STORY:
             * WVU student org plans events. Weather affects success.
             * This system helps make better decisions.
             ***************************************************************/

            // ================================
            // ARRAYS (INITIAL DATA)
            // ================================
            string[] strEventNames = { "Club Fair", "Soccer Match", "Food Festival" };
            int[] intAttendance = { 150, 50, 200 };

            bool blnRunning = true;

            // ================================
            // MAIN LOOP
            // ================================
            while (blnRunning)
            {
                DisplayMenu();

                Console.Write("Enter option: ");
                string strChoice = Console.ReadLine().ToUpper();

                switch (strChoice)
                {
                    case "A":
                        DisplayEvents(strEventNames, intAttendance);
                        break;

                    case "B":
                        // ================================
                        // GET WEATHER INPUT
                        // ================================
                        Console.Write("Enter Temperature: ");
                        double dblTemp = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Rain Chance (%): ");
                        double dblRain = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Wind Speed: ");
                        double dblWind = Convert.ToDouble(Console.ReadLine());

                        // ================================
                        // CALL NON-VOID METHOD
                        // ================================
                        double dblScore = CalculateWeatherScore(dblTemp, dblRain, dblWind);

                        // ================================
                        // CALL VOID METHOD
                        // ================================
                        DisplayDecision(dblScore);
                        break;

                    case "C":
                        int intIndex = GetBestEventIndex(intAttendance);
                        Console.WriteLine("\nBest Event Today: " + strEventNames[intIndex] +
                                          " (Attendance: " + intAttendance[intIndex] + ")");
                        break;

                    case "D":
                        Console.Write("Enter New Event Name: ");
                        string strNewName = Console.ReadLine();

                        Console.Write("Enter Expected Attendance: ");
                        int intNewAttend = Convert.ToInt32(Console.ReadLine());

                        AddEvent(ref strEventNames, ref intAttendance, strNewName, intNewAttend);
                        Console.WriteLine("Event Added Successfully!");
                        break;

                    case "W":
                        // OPTIONAL FEATURE
                        Console.Write("Enter URL: ");
                        string strURL = Console.ReadLine();
                        FetchWeatherFromWeb(strURL);
                        break;

                    case "X":
                        blnRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Option. Try Again.");
                        break;
                }
            }

            Console.WriteLine("Program Ended.");
        }

        // ============================================================
        // METHOD 1: VOID - NO PARAMETERS
        // ============================================================
        static void DisplayMenu()
        {
            /***************************************************************
             * PURPOSE:
             * Displays the main menu to the user.
             *
             * WHY VOID?
             * - No value needs to be returned.
             * - Only prints to screen.
             *
             * WHY NO PARAMETERS?
             * - Does not need any input.
             ***************************************************************/

            Console.WriteLine("\n==== Smart Event Planner ====");
            Console.WriteLine("A - View Events");
            Console.WriteLine("B - Evaluate Weather");
            Console.WriteLine("C - Show Best Event");
            Console.WriteLine("D - Add Event");
            Console.WriteLine("W - Fetch Weather (Optional)");
            Console.WriteLine("X - Exit");
        }

        // ============================================================
        // METHOD 2: VOID - WITH PARAMETERS
        // ============================================================
        static void DisplayEvents(string[] strNames, int[] intAttend)
        {
            /***************************************************************
             * PURPOSE:
             * Displays all stored events.
             *
             * WHY PARAMETERS?
             * - Needs access to arrays from Main.
             *
             * WHY VOID?
             * - Only prints, no return value needed.
             ***************************************************************/

            Console.WriteLine("\n--- Event List ---");

            for (int i = 0; i < strNames.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + strNames[i] +
                                  " (Expected: " + intAttend[i] + ")");
            }
        }

        // ============================================================
        // METHOD 3: NON-VOID - WITH PARAMETERS
        // ============================================================
        static double CalculateWeatherScore(double dblTemp, double dblRain, double dblWind)
        {
            /***************************************************************
             * PURPOSE:
             * Calculates weather suitability score.
             *
             * FORMULA:
             * Score = Temp - (Rain * 0.5) - (Wind * 0.2)
             *
             * WHY NON-VOID?
             * - We must RETURN the calculated score.
             *
             * WHY PARAMETERS?
             * - Requires inputs from user.
             ***************************************************************/

            double dblScore = dblTemp - (dblRain * 0.5) - (dblWind * 0.2);
            return dblScore;
        }

        // ============================================================
        // METHOD 4: VOID - WITH PARAMETERS
        // ============================================================
        static void DisplayDecision(double dblScore)
        {
            /***************************************************************
             * PURPOSE:
             * Interprets the weather score and prints decision.
             *
             * WHY VOID?
             * - Only displays result.
             *
             * WHY PARAMETER?
             * - Needs score calculated earlier.
             ***************************************************************/

            Console.WriteLine("\nWeather Score: " + dblScore);

            if (dblScore >= 70)
            {
                Console.WriteLine("Decision: Proceed Outdoors");
            }
            else if (dblScore >= 50)
            {
                Console.WriteLine("Decision: Move Indoors");
            }
            else
            {
                Console.WriteLine("Decision: Cancel Event");
            }
        }

        // ============================================================
        // METHOD 5: NON-VOID - WITH PARAMETERS
        // ============================================================
        static int GetBestEventIndex(int[] intAttend)
        {
            /***************************************************************
             * PURPOSE:
             * Finds event with highest attendance.
             *
             * WHY NON-VOID?
             * - Returns index of best event.
             *
             * WHY PARAMETER?
             * - Needs access to attendance array.
             ***************************************************************/

            int intMaxIndex = 0;

            for (int i = 1; i < intAttend.Length; i++)
            {
                if (intAttend[i] > intAttend[intMaxIndex])
                {
                    intMaxIndex = i;
                }
            }

            return intMaxIndex;
        }

        // ============================================================
        // METHOD 6: VOID - WITH PARAMETERS (REF)
        // ============================================================
        static void AddEvent(ref string[] strNames, ref int[] intAttend,
                             string strNewName, int intNewAttend)
        {
            /***************************************************************
             * PURPOSE:
             * Adds new event to arrays.
             *
             * WHY REF?
             * - Arrays must be updated outside method.
             *
             * WHY VOID?
             * - No return needed, arrays are modified directly.
             ***************************************************************/

            // Resize arrays
            Array.Resize(ref strNames, strNames.Length + 1);
            Array.Resize(ref intAttend, intAttend.Length + 1);

            // Add new values
            strNames[strNames.Length - 1] = strNewName;
            intAttend[intAttend.Length - 1] = intNewAttend;
        }

        // ============================================================
        // OPTIONAL METHOD: WEB DATA
        // ============================================================
        static void FetchWeatherFromWeb(string strURL)
        {
            /***************************************************************
             * PURPOSE:
             * Demonstrates fetching external data from web.
             *
             * NOTE:
             * - This is a SIMPLE demo.
             * - No parsing, just prints raw HTML/text.
             *
             * WHY IMPORTANT?
             * - Shows real-world data integration.
             ***************************************************************/

            try
            {
                using (WebClient objClient = new WebClient())
                {
                    string strData = objClient.DownloadString(strURL);

                    Console.WriteLine("\n--- Web Data Preview ---");
                    Console.WriteLine(strData.Substring(0, Math.Min(500, strData.Length)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching data: " + ex.Message);
            }
        }
    }
}
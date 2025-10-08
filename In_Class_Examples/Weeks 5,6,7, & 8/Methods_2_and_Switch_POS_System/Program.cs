/*

 * Program: SmallShopPOS - Methods & Switch Comprehensive Demo
 * This code is given to you on eCampus under Weeks 5,6, & 7 (Putting it all together).
 * Author: MJ Ahmad

 * Course: Business Application Programming (C#)

 * Description:

 *  A mini "Point of Sale" (POS) console app that demonstrates:

 *   - Decision making via switch in Main (menu-driven program)

 *   - Method types:

 *     1) Void / No parameters       → PrintWelcome()

 *     2) Void / With parameters      → PrintLine(string)

 *     3) Non-void / No parameters     → GetTodayStamp()

 *     4) Non-void / With parameters    → CalcLineTotal(double, int)

 *   - Parameter passing:

 *     - Pass-by-value (default)      → CalcLineTotal

 *     - Pass-by-reference (ref)      → ApplyDiscount(ref double, double)

 *     - Out parameter (out)        → TryParsePositiveInt(string, out int)

 *   - User input methods, arrays, and printing a receipt

 *

 * Teaching Notes:

 *  - Methods encapsulate logic → cleaner, testable code.

 *  - "What happens in methods stays in methods": local scope is isolated.

 *  - By default, parameters are passed by value (copies).

 *  - Use 'ref' when you want the method to modify the caller variable.

 *  - Use 'out' to return an extra computed value (e.g., safe parsing).

 */



using System;



namespace SmallShopPOS

{

    internal class Program

    {

        // =========================

        // Configurable cart capacity

        // =========================

        const int intMaxItems = 50;



        // "Database" in memory (parallel arrays for a tiny POS demo)

        static string[] strItemNames = new string[intMaxItems];

        static double[] dblItemPrices = new double[intMaxItems];

        static int[] intItemQtys = new int[intMaxItems];

        static int intItemCount = 0;



        // Stores the active customer's name (collected via input method)

        static string strCustomerName = "";



        // ===========================================================

        // 1) VOID / NO PARAMETERS

        // ===========================================================

        /// <summary>

        /// Prints a welcome banner and usage hint.

        /// </summary>

        static void PrintWelcome()

        {

            Console.WriteLine("======================================");

            Console.WriteLine("  Welcome to SmallShop POS (Demo)  ");

            Console.WriteLine("======================================");

            Console.WriteLine($"Today: {GetTodayStamp()}");

            Console.WriteLine();

        }



        // ===========================================================

        // 2) VOID / WITH PARAMETERS

        // ===========================================================

        /// <summary>

        /// Prints a line with a simple prefix (used for consistent UI).

        /// </summary>

        /// <param name="strMessage">Message text to print.</param>

        static void PrintLine(string strMessage)

        {

            Console.WriteLine($"» {strMessage}");

        }



        // ===========================================================

        // 3) NON-VOID / NO PARAMETERS

        // ===========================================================

        /// <summary>

        /// Returns a short timestamp string (no inputs).

        /// </summary>

        /// <returns>Current date string suitable for a receipt header.</returns>

        static string GetTodayStamp()

        {

            return DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        }



        // ===========================================================

        // 4) NON-VOID / WITH PARAMETERS (pass-by-value)

        // ===========================================================

        /// <summary>

        /// Calculates a single line total for a cart item.

        /// (Default pass-by-value: price and qty are copied into the method.)

        /// </summary>

        /// <param name="dblUnitPrice">Unit price of the item.</param>

        /// <param name="intQty">Quantity purchased.</param>

        /// <returns>Total price for the line = price * qty.</returns>

        static double CalcLineTotal(double dblUnitPrice, int intQty)

        {

            double dblLineTotal = dblUnitPrice * intQty; // works on copies

            return dblLineTotal;

        }



        // ===========================================================

        // PASS BY REFERENCE (ref)

        // ===========================================================

        /// <summary>

        /// Applies a percentage discount to the referenced total.

        /// Example: ApplyDiscount(ref dblCartTotal, 10) → reduces total by 10%.

        /// </summary>

        /// <param name="dblTotal">The total to modify (by reference).</param>

        /// <param name="dblPercent">Percent discount (e.g., 10 = 10%).</param>

        static void ApplyDiscount(ref double dblTotal, double dblPercent)

        {

            if (dblPercent <= 0) return;

            dblTotal -= dblTotal * (dblPercent / 100.0);

        }



        // ===========================================================

        // OUT PARAMETER (out)

        // ===========================================================

        /// <summary>

        /// Safely parses a positive integer from input (e.g., menu or qty).

        /// </summary>

        /// <param name="strInput">Raw user input.</param>

        /// <param name="intValue">Parsed positive integer (out).</param>

        /// <returns>True if parse succeeded and value > 0; otherwise false.</returns>

        static bool TryParsePositiveInt(string strInput, out int intValue)

        {

            bool boolOk = int.TryParse(strInput, out intValue);

            if (!boolOk || intValue <= 0)

            {

                intValue = 0;

                return false;

            }

            return true;

        }



        // ===========================================================

        // INPUT HELPERS

        // ===========================================================

        /// <summary>

        /// Prompts the user repeatedly until a valid double >= 0 is entered.

        /// </summary>

        /// <param name="strPrompt">Prompt message.</param>

        /// <returns>Valid non-negative double.</returns>

        static double ReadNonNegativeDouble(string strPrompt)

        {

            while (true)

            {

                Console.Write(strPrompt);

                string strRaw = Console.ReadLine();

                if (double.TryParse(strRaw, out double dblVal) && dblVal >= 0.0)

                    return dblVal;



                PrintLine("Please enter a valid non-negative number.");

            }

        }



        /// <summary>

        /// Prompts the user repeatedly until a valid positive integer is entered.

        /// </summary>

        /// <param name="strPrompt">Prompt message.</param>

        /// <returns>Valid positive integer.</returns>

        static int ReadPositiveInt(string strPrompt)

        {

            while (true)

            {

                Console.Write(strPrompt);

                string strRaw = Console.ReadLine();

                if (TryParsePositiveInt(strRaw, out int intVal))

                    return intVal;



                PrintLine("Please enter a valid positive whole number.");

            }

        }



        /// <summary>

        /// Asks for and stores the customer name (shows pass-by-ref style input flow).

        /// </summary>

        static void AskAndSetCustomerName()

        {

            Console.Write("Enter customer name: ");

            string strInput = Console.ReadLine();

            strCustomerName = string.IsNullOrWhiteSpace(strInput) ? "Walk-in Customer" : strInput.Trim();

            PrintLine($"Customer set: {strCustomerName}");

        }



        // ===========================================================

        // CART OPERATIONS

        // ===========================================================

        /// <summary>

        /// Adds a single line item to the cart arrays.

        /// </summary>

        static void AddItemToCart()

        {

            if (intItemCount >= intMaxItems)

            {

                PrintLine("Cart is full.");

                return;

            }



            Console.Write("Item name: ");

            string strName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(strName)) strName = $"Item{intItemCount + 1}";



            double dblPrice = ReadNonNegativeDouble("Unit price: ");

            int intQty = ReadPositiveInt("Quantity: ");



            strItemNames[intItemCount] = strName;

            dblItemPrices[intItemCount] = dblPrice;

            intItemQtys[intItemCount] = intQty;

            intItemCount++;



            PrintLine($"Added: {strName} (x{intQty}) @ {dblPrice:F2}");

        }



        /// <summary>

        /// Calculates the sum of all line totals in the current cart.

        /// </summary>

        /// <returns>Cart subtotal before discounts.</returns>

        static double ComputeCartSubtotal()

        {

            double dblSubtotal = 0.0;

            for (int intIndex = 0; intIndex < intItemCount; intIndex++)

                dblSubtotal += CalcLineTotal(dblItemPrices[intIndex], intItemQtys[intIndex]); // pass-by-value



            return dblSubtotal;

        }



        /// <summary>

        /// Prints a neatly formatted receipt (arrays + calculations).

        /// </summary>

        static void PrintReceipt()

        {

            Console.WriteLine();

            Console.WriteLine("========== RECEIPT ==========");

            Console.WriteLine($"Customer: {strCustomerName}");

            Console.WriteLine($"Date:   {GetTodayStamp()}");

            Console.WriteLine("-----------------------------");

            Console.WriteLine($"{"Name",-18}{"Price",8}{"Qty",6}{"Total",10}");



            for (int intIndex = 0; intIndex < intItemCount; intIndex++)

            {

                string strName = strItemNames[intIndex];

                double dblPrice = dblItemPrices[intIndex];

                int intQty = intItemQtys[intIndex];

                double dblLine = CalcLineTotal(dblPrice, intQty);



                Console.WriteLine($"{strName,-18}{dblPrice,8:F2}{intQty,6}{dblLine,10:F2}");

            }



            Console.WriteLine("-----------------------------");

            double dblSubtotal = ComputeCartSubtotal();

            Console.WriteLine($"{"SUBTOTAL",-24}{dblSubtotal,10:F2}");

            Console.WriteLine("=============================\n");

        }



        // ===========================================================

        // MAIN: Menu + switch demo

        // ===========================================================

        static void Main(string[] args)

        {

            PrintWelcome();



            bool boolRunning = true;

            while (boolRunning)

            {

                Console.WriteLine("MENU");

                Console.WriteLine("1) Set/Change Customer");

                Console.WriteLine("2) Add Item to Cart");

                Console.WriteLine("3) View Receipt (Subtotal)");

                Console.WriteLine("4) Apply % Discount to Total (ref)");

                Console.WriteLine("5) Clear Cart");

                Console.WriteLine("6) Exit");

                Console.Write("Choose an option (1-6): ");



                string strChoice = Console.ReadLine();

                Console.WriteLine();



                switch (strChoice)

                {

                    case "1":

                        AskAndSetCustomerName(); // void, no parameters (but updates outer state)

                        break;



                    case "2":

                        AddItemToCart(); // uses input helpers and pass-by-value calc

                        break;



                    case "3":

                        PrintReceipt(); // prints current cart and subtotal

                        break;



                    case "4":

                        {

                            if (intItemCount == 0)

                            {

                                PrintLine("Cart is empty. Add items first.");

                                break;

                            }



                            double dblTotal = ComputeCartSubtotal(); // local copy (method scope)

                            double dblPercent = ReadNonNegativeDouble("Discount percent (e.g., 10): ");



                            // PASS-BY-REFERENCE: modifies dblTotal in-place

                            ApplyDiscount(ref dblTotal, dblPercent);



                            Console.WriteLine();

                            Console.WriteLine("====== TOTAL AFTER DISCOUNT ======");

                            Console.WriteLine($"Customer: {strCustomerName}");

                            Console.WriteLine($"Subtotal: {ComputeCartSubtotal():F2}");

                            Console.WriteLine($"Discount: {dblPercent:F2}%");

                            Console.WriteLine($"TOTAL:  {dblTotal:F2}");

                            Console.WriteLine("==================================\n");

                        }

                        break;



                    case "5":

                        // Demonstrates scope: resetting arrays/indices in this method only

                        intItemCount = 0;

                        PrintLine("Cart cleared.");

                        break;



                    case "6":

                        boolRunning = false;

                        PrintLine("Goodbye.");

                        break;



                    default:

                        PrintLine("Invalid option. Please choose 1-6.");

                        break;

                }



                Console.WriteLine();

            }

        }

    }

}



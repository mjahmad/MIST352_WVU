<<<<<<< HEAD
﻿/*
 */
=======
﻿// Mini Point-of-Sale (POS) — Variable Item Count
// -------------------------------------------------------
// Concepts practiced:
//  - Read user input safely (TryParse)
//  - Use arrays to store related data
//  - Use for-loops to collect/process items
//  - Apply simple business rules with if-statements
//  - Format a readable summary table
//
// Business rules:
//  - Bulk discount: 5% off any line with quantity >= 10
//  - Reorder flag: if post-sale stock < 5, mark "REORDER"
//  - Sales tax: 6% (editable via dblTaxRate)
// -------------------------------------------------------

using System;
using System.Globalization;
using System.Text;
>>>>>>> c3fbbbe91c8aa20e8bb1f9be32a65e052c2519bc

namespace Task3
{
    internal class Program
    {
<<<<<<< HEAD
        static void Main(string[] args)
        {
            Console.WriteLine("How many itesm would yo like to order?>");
            int intItemCount = int.Parse(Console.ReadLine());
            
            //define arrays of size intItemcount
=======
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // use dot decimal

            const double dblTaxRate = 0.06;
            const double dblBulkDiscountRate = 0.05;

            // ─────────────────────────────────────────────────────────
            // Ask how many items to process
            // ─────────────────────────────────────────────────────────
            Console.Write("How many items are in this order? ");
            if (!int.TryParse(Console.ReadLine(), out int intItemCount) || intItemCount <= 0)
            {
                Console.WriteLine("[warn] Invalid count. Defaulting to 1 item.");
                intItemCount = 1;
            }

            // ─────────────────────────────────────────────────────────
            // Allocate arrays based on user input
            // ─────────────────────────────────────────────────────────
>>>>>>> c3fbbbe91c8aa20e8bb1f9be32a65e052c2519bc
            string[] strNames = new string[intItemCount];
            double[] dblPrices = new double[intItemCount];
            int[] intQtys = new int[intItemCount];
            int[] intStocks = new int[intItemCount];
            double[] dblLineDiscounts = new double[intItemCount];
            double[] dblLineTotals = new double[intItemCount];
<<<<<<< HEAD
            bool[] blnReord = new bool[intItemCount];

            //the main for loop to accept items data and store them in the arrays above.

            for (int intIndex = 0; intIndex < strNames.Length; intIndex++)
            { }







=======
            bool[] blnReorder = new bool[intItemCount];

            Console.WriteLine("\n=== Mini POS: Enter item details ===");

            for (int i = 0; i < intItemCount; i++)
            {
                Console.WriteLine($"\nItem #{i + 1}");

                // 1) Product name (trim; default placeholder if blank)
                Console.Write("  Enter product name: ");
                string? strNameInput = Console.ReadLine();
                strNames[i] = string.IsNullOrWhiteSpace(strNameInput) ? $"Item{i + 1}" : strNameInput.Trim();

                // 2) Unit price (double)
                Console.Write("  Enter unit price (e.g., 12.50): ");
                if (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double dblPrice) || dblPrice < 0)
                {
                    Console.WriteLine("  [warn] Invalid price. Defaulting to 0.00");
                    dblPrice = 0.00;
                }
                dblPrices[i] = dblPrice;

                // 3) Quantity (int)
                Console.Write("  Enter quantity (integer): ");
                if (!int.TryParse(Console.ReadLine(), out int intQty) || intQty < 0)
                {
                    Console.WriteLine("  [warn] Invalid quantity. Defaulting to 0");
                    intQty = 0;
                }
                intQtys[i] = intQty;

                // 4) Stock on hand (int)
                Console.Write("  Enter stock on hand (integer): ");
                if (!int.TryParse(Console.ReadLine(), out int intStock) || intStock < 0)
                {
                    Console.WriteLine("  [warn] Invalid stock. Defaulting to 0");
                    intStock = 0;
                }
                intStocks[i] = intStock;

                // --- Business rules ---
                double dblGross = dblPrices[i] * intQtys[i];

                // Bulk discount if quantity >= 10
                if (intQtys[i] >= 10)
                    dblLineDiscounts[i] = dblGross * dblBulkDiscountRate;
                else
                    dblLineDiscounts[i] = 0.0;

                // Line total after discount
                dblLineTotals[i] = dblGross - dblLineDiscounts[i];

                // Reorder flag if post-sale stock < 5
                int intPostSaleStock = intStocks[i] - intQtys[i];
                blnReorder[i] = intPostSaleStock < 5;
            }

            // ─────────────────────────────────────────────────────────
            // Compute order totals
            // ─────────────────────────────────────────────────────────
            double dblSubtotal = 0.0;
            for (int i = 0; i < intItemCount; i++)
                dblSubtotal += dblLineTotals[i];

            double dblTax = dblSubtotal * dblTaxRate;
            double dblGrand = dblSubtotal + dblTax;

            // ─────────────────────────────────────────────────────────
            // Output: neat, aligned table
            // ─────────────────────────────────────────────────────────
            Console.WriteLine("\n=== Order Summary ===");
            Console.WriteLine(
                $"{"Name",-18}{"Price",-10}{"Qty",-5}{"Gross",-12}{"Disc",-10}{"Line Total",-12}{"Reorder",-8}");
            Console.WriteLine(new string('-', 75));

            for (int i = 0; i < intItemCount; i++)
            {
                double dblGross = dblPrices[i] * intQtys[i];
                Console.WriteLine(
                    $"{strNames[i],-18}{dblPrices[i],-10:0.00}{intQtys[i],-5}{dblGross,-12:0.00}{dblLineDiscounts[i],-10:0.00}{dblLineTotals[i],-12:0.00}{(blnReorder[i] ? "YES" : "NO"),-8}");
            }

            Console.WriteLine(new string('-', 75));
            Console.WriteLine($"{"Subtotal:",-45}{dblSubtotal,10:0.00}");
            Console.WriteLine($"{"Tax (6%):",-45}{dblTax,10:0.00}");
            Console.WriteLine($"{"GRAND TOTAL:",-45}{dblGrand,10:0.00}");

            Console.WriteLine("\nDone. Press Enter to exit.");
            Console.ReadLine();
>>>>>>> c3fbbbe91c8aa20e8bb1f9be32a65e052c2519bc
        }
    }
}

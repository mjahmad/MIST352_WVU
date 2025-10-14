// ===================================================
// MIST 352 — In-Class Activity 5
// Title: Tip & Tax Splitter Pro
// ---------------------------------------------------
// This program totals a restaurant bill, adds tax and tip,
// and splits the total between a group of people.
// You will complete 3 methods to make it work.
// ===================================================
using System;

namespace TipTaxSplitterPro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Tip & Tax Splitter Pro ===");

            // (1) Display program info and instructions
            ShowMenu();

            // A fixed order list for testing (no file I/O)
            double[] arrItems = { 12.50, 9.00, 15.99, 4.25, 7.75, 10.50 };
            int intCount = arrItems.Length;

            // Collect user inputs
            Console.Write("Tax rate (decimal, e.g., 0.07): ");
            double tax = double.TryParse(Console.ReadLine(), out double t) && t >= 0 ? t : 0;

            Console.Write("Tip rate (decimal, e.g., 0.18): ");
            double tip = double.TryParse(Console.ReadLine(), out double p) && p >= 0 ? p : 0;

            Console.Write("How many people? ");
            int people = int.TryParse(Console.ReadLine(), out int n) && n > 0 ? n : 1;

            // (2) Compute subtotal of all items
            double subtotal = ComputeSubtotal(arrItems, intCount);
            Console.WriteLine($"[SUBTOTAL] {subtotal:0.00}");

            // Add tax
            double withTax = subtotal * (1 + tax);
            Console.WriteLine($"[WITH_TAX] {withTax:0.00}");

            // (3) Apply tip (ref method updates the same variable)
            ApplyTip(ref withTax, tip);
            Console.WriteLine($"[WITH_TAX_TIP] {withTax:0.00}");

            // (4) Calculate per-person share (method returns a double)
            double perHead = PerPerson(withTax, people);
            Console.WriteLine($"[PER_PERSON] {perHead:0.00}");

            Console.WriteLine("=== Done ===");
        }

        // ==============================================
        // (You code this)
        // Method: ShowMenu
        // Purpose:
        //   Displays short instructions for the user.
        //   Explain what the program does and what inputs
        //   the user will provide (tax, tip, people).
        // Parameters:
        //   None
        // Returns:
        //   Nothing (void)
        // Notes:
        //   Just print 3–5 lines. Example topics:
        //   - Program adds up prices of meals.
        //   - User enters tax and tip rates as decimals.
        //   - Program splits the total between people.
        // ==============================================
        

        // ==============================================
        // (You code this) ComputeSubtotal
        // Method: ComputeSubtotal
        // Purpose:
        //   Calculates the total of all menu item prices.
        // Parameters:
        //   arr   - array of double values representing prices
        //   count - how many items to include from the array
        // Returns:
        //   The subtotal as a double.
        // Implementation Hints:
        //   - Initialize a double total = 0.
        //   - Use a for-loop from 0 to count - 1.
        //   - If arr[i] > 0, add it to total.
        //   - Return total at the end.
        // ==============================================
        

        // ==============================================
        // (You code this)
        // Method: ApplyTip
        // Purpose:
        //   Updates the total amount by adding a tip percentage.
        //   Uses a ref parameter to modify the variable directly.
        // Parameters:
        //   ref amountWithTax - the running total that already includes tax
        //   tipRate           - the tip rate as a decimal (e.g., 0.18 for 18%)
        // Returns:
        //   Nothing (void)
        // Implementation Hints:
        //   - Check if tipRate > 0.
        //   - Multiply amountWithTax by (1 + tipRate).
        // ==============================================
        

        // ==============================================
        // (You code this)
        // Method: PerPerson
        // Purpose:
        //   Divides the grand total by number of people to
        //   calculate each person’s share.
        // Parameters:
        //   grandTotal - total after tax and tip
        //   people     - number of people splitting the bill
        // Returns:
        //   Amount per person as a double.
        // Implementation Hints:
        //   - Avoid dividing by zero (if people <= 0, treat as 1).
        // ==============================================
        static double PerPerson(double grandTotal, int people)
        {
            // TODO: Return grandTotal / people (handle edge cases).
            return 0.0;
        }
    }
}

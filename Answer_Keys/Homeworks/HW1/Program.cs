// Author: [Your Name]
// Class: MIST352-Seciotn No-Fall2025
// HW #1
// This program asks the user for info about 4 products (name, serial, price, quantity, category),
// capitalizes the first letter of name and category, calculates total price for each (price * quantity),
// and prints all data in a formatted table with "||" between columns.

using System; // Provides Console input/output and basic types

class Program // Entry point container for the program
{
    static void Main() // Main method where the program starts
    {
        // ─────────────────────────────────────────────────────────────
        // Product 1: Read inputs from the user and store in variables
        // ─────────────────────────────────────────────────────────────

        Console.Write("Enter product 1 name: ");              // Prompt for product 1 name
        string strProductName1 = Console.ReadLine();          // Read product 1 name as text
        strProductName1 = strProductName1.Trim().ToLower();   // Trim spaces; normalize to lower-case
        strProductName1 = char.ToUpper(strProductName1[0])    // Capitalize first letter
                          + strProductName1.Substring(1);     // Append the rest of the string

        Console.Write("Enter product 1 serial number: ");     // Prompt for product 1 serial
        int intSerial1 = int.Parse(Console.ReadLine());       // Read as whole number (no decimals)

        Console.Write("Enter product 1 price: ");             // Prompt for product 1 price
        double dblPrice1 = double.Parse(Console.ReadLine());  // Read as decimal number

        Console.Write("Enter product 1 quantity: ");          // Prompt for product 1 quantity
        int intQty1 = int.Parse(Console.ReadLine());          // Read as whole number

        Console.Write("Enter product 1 category: ");          // Prompt for product 1 category
        string strCategory1 = Console.ReadLine();             // Read category as text
        strCategory1 = strCategory1.Trim().ToLower();         // Trim and lower-case
        strCategory1 = char.ToUpper(strCategory1[0])          // Capitalize first letter
                       + strCategory1.Substring(1);           // Append the rest
        double dblTotal1 = dblPrice1 * intQty1;               // Compute total price for product 1

        // ─────────────────────────────────────────────────────────────
        // Product 2
        // ─────────────────────────────────────────────────────────────

        Console.Write("Enter product 2 name: ");
        string strProductName2 = Console.ReadLine();
        strProductName2 = strProductName2.Trim().ToLower();
        strProductName2 = char.ToUpper(strProductName2[0]) + strProductName2.Substring(1);

        Console.Write("Enter product 2 serial number: ");
        int intSerial2 = int.Parse(Console.ReadLine());

        Console.Write("Enter product 2 price: ");
        double dblPrice2 = double.Parse(Console.ReadLine());

        Console.Write("Enter product 2 quantity: ");
        int intQty2 = int.Parse(Console.ReadLine());

        Console.Write("Enter product 2 category: ");
        string strCategory2 = Console.ReadLine();
        strCategory2 = strCategory2.Trim().ToLower();
        strCategory2 = char.ToUpper(strCategory2[0]) + strCategory2.Substring(1);
        double dblTotal2 = dblPrice2 * intQty2;

        // ─────────────────────────────────────────────────────────────
        // Product 3
        // ─────────────────────────────────────────────────────────────

        Console.Write("Enter product 3 name: ");
        string strProductName3 = Console.ReadLine();
        strProductName3 = strProductName3.Trim().ToLower();
        strProductName3 = char.ToUpper(strProductName3[0]) + strProductName3.Substring(1);

        Console.Write("Enter product 3 serial number: ");
        int intSerial3 = int.Parse(Console.ReadLine());

        Console.Write("Enter product 3 price: ");
        double dblPrice3 = double.Parse(Console.ReadLine());

        Console.Write("Enter product 3 quantity: ");
        int intQty3 = int.Parse(Console.ReadLine());

        Console.Write("Enter product 3 category: ");
        string strCategory3 = Console.ReadLine();
        strCategory3 = strCategory3.Trim().ToLower();
        strCategory3 = char.ToUpper(strCategory3[0]) + strCategory3.Substring(1);
        double dblTotal3 = dblPrice3 * intQty3;

        // ─────────────────────────────────────────────────────────────
        // Product 4
        // ─────────────────────────────────────────────────────────────

        Console.Write("Enter product 4 name: ");
        string strProductName4 = Console.ReadLine();
        strProductName4 = strProductName4.Trim().ToLower();
        strProductName4 = char.ToUpper(strProductName4[0]) + strProductName4.Substring(1);

        Console.Write("Enter product 4 serial number: ");
        int intSerial4 = int.Parse(Console.ReadLine());

        Console.Write("Enter product 4 price: ");
        double dblPrice4 = double.Parse(Console.ReadLine());

        Console.Write("Enter product 4 quantity: ");
        int intQty4 = int.Parse(Console.ReadLine());

        Console.Write("Enter product 4 category: ");
        string strCategory4 = Console.ReadLine();
        strCategory4 = strCategory4.Trim().ToLower();
        strCategory4 = char.ToUpper(strCategory4[0]) + strCategory4.Substring(1);
        double dblTotal4 = dblPrice4 * intQty4;

        // ─────────────────────────────────────────────────────────────
        // Print the table header and rows (no loops; print each row once)
        // ─────────────────────────────────────────────────────────────

        Console.WriteLine(); // Blank line before the table

        //Note about formatting:
        //The general form is:{ index,alignment: format}
        //where index → Which variable to print(0 = first, 1 = second, 2 = third, etc.).
        //alignment → How wide the column should be, and whether text is left - or right - aligned.
        //Negative(e.g., -15) = left - align in a field 15 characters wide.
        //Positive(e.g., 15) = right - align in a field 15 characters wide.
        //format → Optional(like F2 for 2 decimal places, C for currency, etc.).
        //So, {0,-15} → Print the first variable ("Name") in a column 15 characters wide, left-aligned. 

        Console.WriteLine("-----------------------------------------------------------------------------------"); // Top border
        Console.WriteLine("{0,-15} || {1,-10} || {2,-10} || {3,-10} || {4,-12} || {5,-12}",
                          "Name", "Serial", "Price", "Quantity", "Category", "Total Price"); // Column headers
        Console.WriteLine("-----------------------------------------------------------------------------------"); // Header divider

        // Row for product 1
        Console.WriteLine("{0,-15} || {1,-10} || ${2,-9:F2} || {3,-10} || {4,-12} || ${5,-11:F2}",
                          strProductName1, intSerial1, dblPrice1, intQty1, strCategory1, dblTotal1);

        // Row for product 2
        Console.WriteLine("{0,-15} || {1,-10} || ${2,-9:F2} || {3,-10} || {4,-12} || ${5,-11:F2}",
                          strProductName2, intSerial2, dblPrice2, intQty2, strCategory2, dblTotal2);

        // Row for product 3
        Console.WriteLine("{0,-15} || {1,-10} || ${2,-9:F2} || {3,-10} || {4,-12} || ${5,-11:F2}",
                          strProductName3, intSerial3, dblPrice3, intQty3, strCategory3, dblTotal3);

        // Row for product 4
        Console.WriteLine("{0,-15} || {1,-10} || ${2,-9:F2} || {3,-10} || {4,-12} || ${5,-11:F2}",
                          strProductName4, intSerial4, dblPrice4, intQty4, strCategory4, dblTotal4);
    }
}

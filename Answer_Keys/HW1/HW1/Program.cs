/*
Author: MJ Ahmad (Instructor Demo)
Class: MIST352
HW #2 - NO LOOPS / NO METHODS version (Improved Formatting)
Description: Collect 5 product sales entries, store in arrays, calculate per-item totals,
             then print a clean sales report + total quantity + grand total.
*/

using System;

class Program
{
    static void Main()
    {
        const int N = 5;

        // Arrays (required)
        string[] productNames = new string[N];
        int[] productIds = new int[N];
        decimal[] unitPrices = new decimal[N];
        int[] quantities = new int[N];
        string[] categories = new string[N];
        decimal[] productTotals = new decimal[N];

        Console.WriteLine("===============================================================");
        Console.WriteLine("MIST352 - Weekly Sales Order System (HW2 Demo)");
        Console.WriteLine("===============================================================\n");

        // ---------------- PRODUCT 1 ----------------
        Console.WriteLine("--- Product #1 of 5 ---");
        Console.Write("Product Name: ");
        productNames[0] = (Console.ReadLine() ?? "").Trim();
        if (productNames[0].Length > 0) productNames[0] = char.ToUpper(productNames[0][0]) + productNames[0].Substring(1).ToLower();

        Console.Write("Category/Department: ");
        categories[0] = (Console.ReadLine() ?? "").Trim();
        if (categories[0].Length > 0) categories[0] = char.ToUpper(categories[0][0]) + categories[0].Substring(1).ToLower();

        Console.Write("Product ID (whole number): ");
        productIds[0] = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Unit Price (e.g., 19.99): ");
        unitPrices[0] = decimal.Parse((Console.ReadLine() ?? "0").Replace("$", "").Trim());

        Console.Write("Quantity Sold (whole number): ");
        quantities[0] = int.Parse(Console.ReadLine() ?? "0");

        productTotals[0] = unitPrices[0] * quantities[0];
        Console.WriteLine();

        // ---------------- PRODUCT 2 ----------------
        Console.WriteLine("--- Product #2 of 5 ---");
        Console.Write("Product Name: ");
        productNames[1] = (Console.ReadLine() ?? "").Trim();
        if (productNames[1].Length > 0) productNames[1] = char.ToUpper(productNames[1][0]) + productNames[1].Substring(1).ToLower();

        Console.Write("Category/Department: ");
        categories[1] = (Console.ReadLine() ?? "").Trim();
        if (categories[1].Length > 0) categories[1] = char.ToUpper(categories[1][0]) + categories[1].Substring(1).ToLower();

        Console.Write("Product ID (whole number): ");
        productIds[1] = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Unit Price (e.g., 19.99): ");
        unitPrices[1] = decimal.Parse((Console.ReadLine() ?? "0").Replace("$", "").Trim());

        Console.Write("Quantity Sold (whole number): ");
        quantities[1] = int.Parse(Console.ReadLine() ?? "0");

        productTotals[1] = unitPrices[1] * quantities[1];
        Console.WriteLine();

        // ---------------- PRODUCT 3 ----------------
        Console.WriteLine("--- Product #3 of 5 ---");
        Console.Write("Product Name: ");
        productNames[2] = (Console.ReadLine() ?? "").Trim();
        if (productNames[2].Length > 0) productNames[2] = char.ToUpper(productNames[2][0]) + productNames[2].Substring(1).ToLower();

        Console.Write("Category/Department: ");
        categories[2] = (Console.ReadLine() ?? "").Trim();
        if (categories[2].Length > 0) categories[2] = char.ToUpper(categories[2][0]) + categories[2].Substring(1).ToLower();

        Console.Write("Product ID (whole number): ");
        productIds[2] = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Unit Price (e.g., 19.99): ");
        unitPrices[2] = decimal.Parse((Console.ReadLine() ?? "0").Replace("$", "").Trim());

        Console.Write("Quantity Sold (whole number): ");
        quantities[2] = int.Parse(Console.ReadLine() ?? "0");

        productTotals[2] = unitPrices[2] * quantities[2];
        Console.WriteLine();

        // ---------------- PRODUCT 4 ----------------
        Console.WriteLine("--- Product #4 of 5 ---");
        Console.Write("Product Name: ");
        productNames[3] = (Console.ReadLine() ?? "").Trim();
        if (productNames[3].Length > 0) productNames[3] = char.ToUpper(productNames[3][0]) + productNames[3].Substring(1).ToLower();

        Console.Write("Category/Department: ");
        categories[3] = (Console.ReadLine() ?? "").Trim();
        if (categories[3].Length > 0) categories[3] = char.ToUpper(categories[3][0]) + categories[3].Substring(1).ToLower();

        Console.Write("Product ID (whole number): ");
        productIds[3] = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Unit Price (e.g., 19.99): ");
        unitPrices[3] = decimal.Parse((Console.ReadLine() ?? "0").Replace("$", "").Trim());

        Console.Write("Quantity Sold (whole number): ");
        quantities[3] = int.Parse(Console.ReadLine() ?? "0");

        productTotals[3] = unitPrices[3] * quantities[3];
        Console.WriteLine();

        // ---------------- PRODUCT 5 ----------------
        Console.WriteLine("--- Product #5 of 5 ---");
        Console.Write("Product Name: ");
        productNames[4] = (Console.ReadLine() ?? "").Trim();
        if (productNames[4].Length > 0) productNames[4] = char.ToUpper(productNames[4][0]) + productNames[4].Substring(1).ToLower();

        Console.Write("Category/Department: ");
        categories[4] = (Console.ReadLine() ?? "").Trim();
        if (categories[4].Length > 0) categories[4] = char.ToUpper(categories[4][0]) + categories[4].Substring(1).ToLower();

        Console.Write("Product ID (whole number): ");
        productIds[4] = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Unit Price (e.g., 19.99): ");
        unitPrices[4] = decimal.Parse((Console.ReadLine() ?? "0").Replace("$", "").Trim());

        Console.Write("Quantity Sold (whole number): ");
        quantities[4] = int.Parse(Console.ReadLine() ?? "0");

        productTotals[4] = unitPrices[4] * quantities[4];
        Console.WriteLine();

        // ---------------- TOTALS OF TOTALS (NO LOOPS) ----------------
        int totalQuantity = quantities[0] + quantities[1] + quantities[2] + quantities[3] + quantities[4];
        decimal grandTotal = productTotals[0] + productTotals[1] + productTotals[2] + productTotals[3] + productTotals[4];

        // ---------------- REPORT OUTPUT (Better Table) ----------------
        Console.WriteLine("\n===============================================================");
        Console.WriteLine("SALES REPORT (Summary)");
        Console.WriteLine("===============================================================");

        // Table header
        Console.WriteLine(
            $"{"Product",-18}" +
            $"{"ID",-8}" +
            $"{"Category",-14}" +
            $"{"Unit Price",12}" +
            $"{"Qty",6}" +
            $"{"Line Total",14}"
        );

        Console.WriteLine(new string('-', 18 + 8 + 14 + 12 + 6 + 14));

        // Rows (NO LOOPS)
        Console.WriteLine($"{productNames[0],-18}{productIds[0],-8}{categories[0],-14}{unitPrices[0],12:C2}{quantities[0],6}{productTotals[0],14:C2}");
        Console.WriteLine($"{productNames[1],-18}{productIds[1],-8}{categories[1],-14}{unitPrices[1],12:C2}{quantities[1],6}{productTotals[1],14:C2}");
        Console.WriteLine($"{productNames[2],-18}{productIds[2],-8}{categories[2],-14}{unitPrices[2],12:C2}{quantities[2],6}{productTotals[2],14:C2}");
        Console.WriteLine($"{productNames[3],-18}{productIds[3],-8}{categories[3],-14}{unitPrices[3],12:C2}{quantities[3],6}{productTotals[3],14:C2}");
        Console.WriteLine($"{productNames[4],-18}{productIds[4],-8}{categories[4],-14}{unitPrices[4],12:C2}{quantities[4],6}{productTotals[4],14:C2}");

        Console.WriteLine(new string('-', 18 + 8 + 14 + 12 + 6 + 14));

        // Totals
        Console.WriteLine($"{"TOTALS",-52}{totalQuantity,6}{grandTotal,14:C2}");
        Console.WriteLine("========================================================================\n");

        Console.WriteLine("Done.");
    }
}

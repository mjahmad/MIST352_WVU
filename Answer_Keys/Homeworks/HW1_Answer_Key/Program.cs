/****************************************************
Author: [Your first and last name]
Class: MIST352-Fall2025
HW #1
Description: This program asks the user to enter 
information for 4 products, but ignores that input 
and instead uses pre-filled data for demonstration.
It prints the product information in a table with 
proper formatting and calculated total prices.
****************************************************/

using System;

class Program
{
    static void Main(string[] args)
    {
        // Fixed product dataset
        string[] productNames = { "Laptop", "Desk Chair", "Notebook", "Headphones" };
        int[] productSerials = { 12345, 23456, 34567, 45678 };
        double[] productPrices = { 799.99, 149.50, 2.75, 59.95 };
        int[] productQuantities = { 2, 4, 10, 3 };
        string[] productCategories = { "Electronics", "Furniture", "Stationery", "Electronics" };

        // Pretend to collect input (but ignore it)
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"\nEnter information for product #{i + 1}");
            Console.Write("Product name: ");
            Console.ReadLine();
            Console.Write("Product serial number: ");
            Console.ReadLine();
            Console.Write("Product price: ");
            Console.ReadLine();
            Console.Write("Product quantity: ");
            Console.ReadLine();
            Console.Write("Product category: ");
            Console.ReadLine();
        }

        // Print output as a table with ||
        Console.WriteLine("\n-----------------------------------------------------------------------------------");
        Console.WriteLine("{0,-15} || {1,-10} || {2,-10} || {3,-10} || {4,-12} || {5,-12}",
                          "Name", "Serial", "Price", "Quantity", "Category", "Total Price");
        Console.WriteLine("-----------------------------------------------------------------------------------");

        for (int i = 0; i < 4; i++)
        {
            double totalPrice = productPrices[i] * productQuantities[i];
            Console.WriteLine("{0,-15} || {1,-10} || ${2,-9:F2} || {3,-10} || {4,-12} || ${5,-11:F2}",
                              productNames[i], productSerials[i], productPrices[i],
                              productQuantities[i], productCategories[i], totalPrice);
        }
    }
}

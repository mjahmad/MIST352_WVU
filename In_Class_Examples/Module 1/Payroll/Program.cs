/*
 * Mj Ahmad
 * Payroll system
 * 8/27/26
 */
using System;   
    internal class Program
    {
        static void Main(string[] args)
        {
        // INPUT
        Console.WriteLine("Enter your first name");
        string strFirstName =Console.ReadLine();

        Console.WriteLine("Enter your mid name Initial");
        char chrMidInitial = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.WriteLine("Enter your last name");
        string strLastName = Console.ReadLine();
        
        
        Console.WriteLine("Enter price per item:");
        double pricePerItem = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter quantity:");
        int quantity = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter tax rate as a decimal (example: 0.06):");
        double taxRate = double.Parse(Console.ReadLine());

        // PROCESSING
        double subTotal = pricePerItem * quantity;
        double taxAmount = subTotal * taxRate;
        double finalTotal = subTotal + taxAmount;

        // OUTPUT
        Console.WriteLine();
        Console.WriteLine("----- INVOICE SUMMARY -----");
        Console.WriteLine("Subtotal: $" + subTotal);
        Console.WriteLine("Tax:      $" + taxAmount);
        Console.WriteLine("Total:    $" + finalTotal);
        Console.WriteLine($"Good bye {strFirstName} {chrMidInitial}. {strLastName}");
    }
    }


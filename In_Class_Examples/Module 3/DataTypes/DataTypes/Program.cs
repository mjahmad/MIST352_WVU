/*
=====================================================================
MIST 352 – Business Application Programming
Module 3: Chapter 2: Data Types (Module 2.A)

IMPORTANT STUDENT NOTES
- This program demonstrates all major data types covered in Chapter 2.
- Everything is written INSIDE Main (NO methods used).
- You are encouraged to COMMENT / UNCOMMENT sections while testing.
- Run using Ctrl + F5 so the console window stays open.

=====================================================================
*/

using System;
using System.Text;   // Needed later for StringBuilder (concept only)

class Program
{
    static void Main()
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("MIST 352 - Chapter 2: Data Types Demo Program");
        Console.WriteLine("==============================================\n");

        // ============================================================
        // SECTION 1: Type Name Forms
        // ============================================================

        Console.WriteLine("----- SECTION 1: Type Name Forms -----");

        int quantity = 10;
        double taxRate = 0.06;
        decimal accountBalance = 1250.75m;
        bool isActive = true;
        char grade = 'A';
        string customerName = "Alice";

        Console.WriteLine($"int quantity = {quantity}");
        Console.WriteLine($"double taxRate = {taxRate}");
        Console.WriteLine($"decimal accountBalance = {accountBalance}");
        Console.WriteLine($"bool isActive = {isActive}");
        Console.WriteLine($"char grade = {grade}");
        Console.WriteLine($"string customerName = {customerName}\n");

        // ============================================================
        // SECTION 2: Literal Values
        // ============================================================

        Console.WriteLine("----- SECTION 2: Literal Values -----");

        int count = 5;                 // integer literal
        double rate = 0.08;            // double literal
        decimal price = 19.99m;        // decimal literal (m required)
        bool approved = true;          // boolean literal
        char letter = 'X';             // character literal
        string message = "Hello!";     // string literal

        Console.WriteLine($"count (int): {count}");
        Console.WriteLine($"rate (double): {rate}");
        Console.WriteLine($"price (decimal): {price}");
        Console.WriteLine($"approved (bool): {approved}");
        Console.WriteLine($"letter (char): {letter}");
        Console.WriteLine($"message (string): {message}\n");

        // ============================================================
        // SECTION 3: Fundamental Numeric Types
        // ============================================================

        Console.WriteLine("----- SECTION 3: Fundamental Numeric Types -----");

        // Integer (whole numbers)
        int unitsSold = 12;

        // Floating-point (general decimals)
        double averageRating = 4.6;

        // Decimal (money)
        decimal pricePerUnit = 19.99m;

        int moreUnitsSold = 3;
        int totalUnits = unitsSold + moreUnitsSold;

        double adjustedRating = averageRating - 0.2;

        decimal revenue = pricePerUnit * totalUnits;
        decimal halfRevenue = revenue / 2m;

        Console.WriteLine($"unitsSold (int): {unitsSold}");
        Console.WriteLine($"averageRating (double): {averageRating}");
        Console.WriteLine($"pricePerUnit (decimal): {pricePerUnit}");
        Console.WriteLine($"totalUnits (int): {totalUnits}");
        Console.WriteLine($"adjustedRating (double): {adjustedRating}");
        Console.WriteLine($"revenue (decimal): {revenue}");
        Console.WriteLine($"halfRevenue (decimal): {halfRevenue}");
        Console.WriteLine($"Formatted revenue (currency): {revenue:C}\n");

        // ============================================================
        // SECTION 4: More Fundamental Types (bool, char)
        // ============================================================

        Console.WriteLine("----- SECTION 4: Boolean and Character Types -----");

        bool isApproved = true;
        bool isEmployeeActive = false;
        char serviceTier = 'B';

        Console.WriteLine($"isApproved (bool): {isApproved}");
        Console.WriteLine($"isEmployeeActive (bool): {isEmployeeActive}");
        Console.WriteLine($"serviceTier (char): {serviceTier}\n");

        // ============================================================
        // SECTION 5: Strings
        // ============================================================

        Console.WriteLine("----- SECTION 5: Strings -----");

        string fullName = "Sarah Smith";
        string department = "Sales";

        // String interpolation
        Console.WriteLine($"Employee: {fullName}");
        Console.WriteLine($"Department: {department}");

        // Newline
        Console.WriteLine("\nLine 1\nLine 2\nLine 3\n");

        // Raw string literal (multi-line)
        string reportHeader = """
        ==========================
        WEEKLY SALES REPORT
        ==========================
        """;
        Console.WriteLine(reportHeader);

        // String length
        Console.WriteLine($"Length of fullName: {fullName.Length}");

        // String methods
        Console.WriteLine($"Uppercase name: {fullName.ToUpper()}");
        Console.WriteLine($"Contains 'Smith': {fullName.Contains("Smith")}");
        Console.WriteLine($"Replace Sales -> Marketing: {department.Replace("Sales", "Marketing")}");

        // String formatting
        double total = 1234.56789;
        Console.WriteLine($"\nFormatted total (2 decimals): {total:F2}");
        Console.WriteLine($"Formatted total (currency): {total:C}\n");

        // ============================================================
        // SECTION 6: Strings Are Immutable + StringBuilder (Concept)
        // ============================================================

        Console.WriteLine("----- SECTION 6: String Immutability -----");

        string greeting = "Hello";
        greeting = greeting + ", world!";
        Console.WriteLine($"Greeting: {greeting}");

        Console.WriteLine("\nStringBuilder example (concept only):");

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Invoice Summary:");
        sb.AppendLine("- Item: USB Keyboard");
        sb.AppendLine("- Quantity: 2");
        sb.AppendLine("- Total: $39.98");

        Console.WriteLine(sb.ToString());

        // ============================================================
        // SECTION 7: null and void (Conceptual)
        // ============================================================

        Console.WriteLine("----- SECTION 7: null and void (Conceptual) -----");

        string middleName = null;
        Console.WriteLine($"Middle name: {middleName}");

        Console.WriteLine("Note: void means 'returns nothing'.");
        Console.WriteLine("Main is a void method.\n");

        // ============================================================
        // SECTION 8: Conversions Between Data Types
        // ============================================================

        Console.WriteLine("----- SECTION 8: Type Conversions -----");

        // Implicit conversion
        int items = 5;
        double itemsAsDouble = items;
        Console.WriteLine($"Implicit int -> double: {itemsAsDouble}");

        // Explicit cast
        double score = 9.99;
        int scoreAsInt = (int)score;
        Console.WriteLine($"Explicit double -> int: {scoreAsInt} (from {score})");

        // Parsing strings
        string hoursText = "40";
        string rateText = "25.50";

        int hoursWorked = int.Parse(hoursText);
        double hourlyRate = double.Parse(rateText);

        double totalPay = hoursWorked * hourlyRate;
        Console.WriteLine($"Parsed hours: {hoursWorked}");
        Console.WriteLine($"Parsed rate: {hourlyRate}");
        Console.WriteLine($"Total Pay: {totalPay:F2}");

        // Convert class
        string unitsText = "12";
        int units = Convert.ToInt32(unitsText);
        Console.WriteLine($"Convert.ToInt32(\"12\"): {units}");

        Console.WriteLine("\nIMPORTANT:");
        Console.WriteLine("- If parsing fails, the program crashes.");
        Console.WriteLine("- We will handle this safely later.");

        Console.WriteLine("\n==============================================");
        Console.WriteLine("END of Chapter 2: Data Types Demo Program");
        Console.WriteLine("==============================================");
    }
}

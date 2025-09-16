/*
--------------------------------------------------------
Author: Mohammad Jamil Ahmad
Date:   August 28, 2025
Chapter 1
Purpose: Demonstration of variables, input, and output
Description:
This program calculates the area of a circle,
asks for user input (name, age, etc.),
and demonstrates different Console.WriteLine formats.

--------------------------------------------------------
*/

namespace Chapter1
{
    using System;

class Program
{
    static void Main()
    {
        // 1. Printing out things using different Console.Write/WriteLine statements
        Console.WriteLine("Hello, World!");
        Console.Write("This is printed without a new line. ");
        Console.WriteLine("And this continues on the same line.");

        // 2. Defining variables (calculate area of a circle, age, and something fun)
        double radius = 5.0;
        double area = Math.PI * radius * radius;
        int birthYear = 1995;
        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;
        string funFact = "C# was created by Microsoft!";

        Console.WriteLine($"\nThe area of a circle with radius {radius} is {area:F2}");
        Console.WriteLine($"If you were born in {birthYear}, your age is about {age} years.");
        Console.WriteLine("Fun Fact: " + funFact);

        // 3. Printing out using {} in the WriteLine statement
        Console.WriteLine("Your age is {0} and the circle area is {1:F2}", age, area);

        // 4. Inputs from user (read three strings)
        Console.WriteLine("\nPlease enter your first name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter your favorite color:");
        string favoriteColor = Console.ReadLine();
        Console.WriteLine("Enter your favorite hobby:");
        string hobby = Console.ReadLine();

        Console.WriteLine($"Hello {firstName}, your favorite color is {favoriteColor} and you enjoy {hobby}!");

        // 5. Accept other inputs: int, float, string, and date
        Console.WriteLine("\nEnter your age (int):");
        int userAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter your GPA (float):");
        float gpa = float.Parse(Console.ReadLine());

        Console.WriteLine("Enter your city (string):");
        string city = Console.ReadLine();

        Console.WriteLine("Enter your birth date (yyyy-mm-dd):");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());

        // 6. Display results using different printing styles
        Console.WriteLine("\n=== Results ===");
        Console.WriteLine("Name: " + firstName);
        Console.WriteLine($"Age: {userAge} | GPA: {gpa}");
        Console.WriteLine("City: {0}", city);
        Console.WriteLine("Birth Date: {0:MMMM dd, yyyy}", birthDate); // masking with format

        Console.WriteLine("\nThank you for trying this C# program!");
    }
}

}

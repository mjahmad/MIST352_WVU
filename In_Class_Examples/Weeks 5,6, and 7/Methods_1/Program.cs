<<<<<<< HEAD
﻿using System.Diagnostics;

namespace Methods_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intVal1 = 90, intVal2 = 10;
            GreetUser();
            Console.WriteLine( SumTwoNumbers(intVal2,intVal1));
            Console.WriteLine(MultiPlyTwoNumbers(intVal1,intVal2));
            AskUserNameAndGreet();
            char chrOption = 'A';
        } 
        /// <summary>
        /// This method calcualte the sum of two variables
        /// </summary>
        /// <param name="intFirstVal"> First value passed from outside</param>
        /// <param name="intSecondVal"> Second vale from outside</param>
        /// <returns>The sum of intFirstVal and intSecondVal</returns>
        static int SumTwoNumbers(int intFirstVal, int intSecondVal)
        {
            int intSum = intFirstVal + intSecondVal;
            return intSum;
        }
        /// <summary>
        /// This greets used to printintout out a nice message
        /// </summary>
        static void GreetUser()
        {
            Console.WriteLine("Hello user. ");
        }

        //create a methoid that accepts two values and multiplies them and returns that
        static int MultiPlyTwoNumbers(int intX, int intY)
        {
            int intZ = intX * intY;
            return intZ;
        }

        static void AskUserNameAndGreet()
        {
            Console.WriteLine("What is yoru name?");
            string strName = Console.ReadLine();
            Console.WriteLine($"Its good to see you {strName}");
        }

=======
﻿/*
 * Tuesday 9/30/2025
 * Program: Basic Methods Example
 * Description:
 * This program demonstrates different types of methods in C#:
 *   1. Void methods (with and without parameters)
 *   2. Non-void methods (with and without parameters)
 * 
 * Each method performs a simple task such as:
 *   - Printing a message
 *   - Accepting user input
 *   - Adding or multiplying numbers
 */

using System;

namespace BasicMethodsDemo
{
    internal class Program
    {
        // ===========================================================
        // MAIN METHOD
        // The entry point of the program. Demonstrates how to call the methods above.
        // ===========================================================
        static void Main(string[] args)
        {
            // Example 1: Calling a void method (no parameters)
            PrintWelcomeMessage();

            // Example 2: Calling a void method with a parameter
            PrintUserName("MJ Ahmad");

            // Example 3: Calling a non-void method with parameters (sum)
            int intResult = SumTwoNumbers(5, 10);
            Console.WriteLine($"The sum of 5 and 10 is: {intResult}");

            // Example 4: Calling a non-void method with parameters (multiplication)
            double dblResult = MultiplyTwoNumbers(4.5, 2.0);
            Console.WriteLine($"The product of 4.5 and 2.0 is: {dblResult}");

            // Example 5: Calling a void method that accepts user input
            AskAndPrintName();

            Console.WriteLine("\nProgram execution completed successfully!");
        }

        // ===========================================================
        //VOID Method - NO PARAMETERS
        // This method does not take any parameters and does not return a value.
        // It simply prints a welcome message.
        // ===========================================================
        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Hello User! Welcome to the Basic Methods Demo.");
        }

        // ===========================================================
        // VOID Method - WITH PARAMETERS
        // This method accepts a user's name as a parameter and prints it.
        // Since it is a void method, it does not return a value.
        // ===========================================================
        static void PrintUserName(string strName)
        {
            Console.WriteLine($"Hello, {strName}! Nice to meet you.");
        }

        // ===========================================================
        // NON-VOID Method - WITH PARAMETERS
        // This method accepts two integers and returns their sum.
        // The method returns an integer result using the 'return' keyword.
        // ===========================================================
        static int SumTwoNumbers(int intNum1, int intNum2)
        {
            int intSum = intNum1 + intNum2;  // Add the two numbers
            return intSum;                    // Return the result
        }

        // ===========================================================
        // NON-VOID Method - WITH PARAMETERS
        // This method accepts two doubles and returns their multiplication result.
        // ===========================================================
        static double MultiplyTwoNumbers(double dblNum1, double dblNum2)
        {
            double dblProduct = dblNum1 * dblNum2;  // Multiply the two numbers
            return dblProduct;                      // Return the product
        }

        // ===========================================================
        // VOID Method - NO PARAMETERS
        // This method accepts input from the user and prints the name.
        // The user's input is read from the console using Console.ReadLine().
        // ===========================================================
        static void AskAndPrintName()
        {
            Console.Write("Enter your name: ");
            string strUserName = Console.ReadLine();   // Accept user input
            Console.WriteLine($"Welcome, {strUserName}!");
        }

       
        
>>>>>>> b87ee5d3a7eb29a0438970b78ee36726d1e59363
    }
}

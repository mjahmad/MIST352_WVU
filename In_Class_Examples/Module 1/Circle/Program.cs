/*
 * Circle Program
 * 
 */

using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

    internal class Program
    {
        static void Main(string[] args)
    {
        // A = πr², where r is the radius of the circle.
        Console.WriteLine("Helo, this calcalutes the ara of a cirlce.");
        Console.WriteLine("What is the raduis?");
        
        double dblRaduis = Convert.ToDouble(Console.ReadLine());
        double dblArea = Math.PI * Math.Pow(dblRaduis, 2);

        Console.WriteLine($"The area of circle of {dblRaduis} raduis is {dblArea}");
        //Console.WriteLine("The area of circle of " + dblRaduis+ " raduis is " +  dblArea);

    }
}


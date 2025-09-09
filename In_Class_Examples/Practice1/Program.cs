/*
 * =======================================================
 * Name: MJ Ahmad
 * Date: Thursda 8/28/25
 * In class practice 
 * This program does something.....
 * ======================================================
 */


namespace Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to Practice 1");
            Console.WriteLine("This portion shows us ho wto print thign out");
            // ################### Functionality 1 #############################
            Console.WriteLine("You now are in Functionality 1");
            Console.WriteLine("----------------You now are in Functionality 1----------------------------------------------");

            Console.WriteLine("A circle with an raduis of 1 is 3.14");
            // The formula to calculate the area of a circle is X * X * 3.14, where r is raduis
            // r stores the raduis
            double theRaduis = 10.5;
            //a stores the area
            double theArea = theRaduis * theRaduis * 3.14;

            String n = "Circle 1";
            // The next 3 lines are show differente ways to print out the area
            //Console.WriteLine("A circle with a raduis of " + r + " is " + a);
            //Console.WriteLine("A circle with a raduis of {0} is {1}",r, a);
            //Console.WriteLine($"A circle with a raduis of {r} is {a}");

            Console.WriteLine($"{n} with a raduis of {theRaduis} is {theArea}");
            Console.WriteLine("--------------------------------------------------------------");





        }
    }
}

/*
 * Tuesday 9/23/25
 * While loop and thier uses
 */

using System.Runtime.ExceptionServices;

namespace While_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] dblNumbers = { 19.0, 18, 10, 0.7, 5.5 };
            for (int intIndex = dblNumbers.Length - 1; intIndex >=0; intIndex--)
            {
                Console.WriteLine(dblNumbers[intIndex]);
                intIndex++;
            }


            //int intWhileIndex = 0;
            //while (intWhileIndex < dblNumbers.Length)
            //{
            //    Console.WriteLine(dblNumbers[intWhileIndex]);
            //    intWhileIndex++;
            //}

            /*       String strMagicWord = "";
                   Console.WriteLine("What is 5 * 5?");
                   while (strMagicWord != "25")
                   { 
                       Console.WriteLine("wrong answer. Try again");
                       strMagicWord = Console.ReadLine();
                   }


       */



        }
    }
}

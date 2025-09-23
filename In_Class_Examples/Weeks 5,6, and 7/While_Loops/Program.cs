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
            //for (int intIndex = 0; intIndex < dblNumbers.Length; intIndex++)
            //{
            //    Console.WriteLine(dblNumbers[intIndex]);
            //}

            //while loop
            int intWhileIndex = 0;
            while (intWhileIndex < dblNumbers.Length)
            {
                Console.WriteLine(dblNumbers[intWhileIndex]);
                //intWhileIndex++;

            }

            //String strPassword = "";
            //while (strPassword!="Cats")
            //{
            //    Console.WriteLine("Give me a password");
            //    strPassword = Console.ReadLine();

            //}



        }
    }
}

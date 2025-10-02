using System.Diagnostics;

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

    }
}

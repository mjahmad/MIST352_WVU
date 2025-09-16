/*
 * MJ Ahmad
 * Tuesday 9/2/25
 * Practice trasnlating pseudo code to C#
 * 
 */

namespace Practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* double dblVal1, dblVal2;
             Console.WriteLine("Give me the first value: ");
             dblVal1 = Convert.ToDouble(Console.ReadLine());
             //test 
             //Console.WriteLine(dblVal1);

             Console.WriteLine("Give me the second value: ");
             dblVal2 = Convert.ToDouble(Console.ReadLine());
             //test 
             double dblTotal = dblVal1 + dblVal2;
             Console.WriteLine("The sum of {dblVal1} and {dblVal2} is {dblTotal}");*/

            int dblVal1, dblVal2;
            Console.WriteLine("Give me the first value: ");
            dblVal1 = int.Parse(Console.ReadLine());
            //test 
            //Console.WriteLine(dblVal1);

            Console.WriteLine("Give me the second value: ");
            dblVal2 = int.Parse(Console.ReadLine());
            //test 
            double dblTotal = dblVal1 + dblVal2;
            Console.WriteLine($"The sum of {dblVal1} and {dblVal2} is {dblTotal}");
        }
    }
}

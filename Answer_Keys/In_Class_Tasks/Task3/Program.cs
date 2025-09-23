/*
 */

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many itesm would yo like to order?>");
            int intItemCount = int.Parse(Console.ReadLine());
            
            //define arrays of size intItemcount
            string[] strNames = new string[intItemCount];
            double[] dblPrices = new double[intItemCount];
            int[] intQtys = new int[intItemCount];
            int[] intStocks = new int[intItemCount];
            double[] dblLineDiscounts = new double[intItemCount];
            double[] dblLineTotals = new double[intItemCount];
            bool[] blnReord = new bool[intItemCount];

            //the main for loop to accept items data and store them in the arrays above.

            for (int intIndex = 0; intIndex < strNames.Length; intIndex++)
            { }







        }
    }
}

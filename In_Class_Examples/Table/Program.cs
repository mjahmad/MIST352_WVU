/*
 * MJ Ahnad
 * HW1
 * MIST253-002
 * Date 
 */

namespace Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //define variables
            String strProduct1 = "laptop";

            double dblPrice1 = 10.2;

            Console.WriteLine("Give me produc 1 info");
            Console.Write("Product Name: ");
            strProduct1 = Console.ReadLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("Name\t\t|| Serial\t\t|| Qty\t\t||");
            Console.WriteLine("===============================================");
            Console.WriteLine($"{strProduct1}\t\t||{dblPrice1}\t\t||{strProduct1}\t\t{strProduct1}\t\t{strProduct1}");

        }
    }
}

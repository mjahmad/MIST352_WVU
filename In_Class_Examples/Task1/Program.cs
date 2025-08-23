namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("This is my first C# program");

            // Lets define some variables

            int intAge = 0;
            double intPrice = 1.5;
            String strName = " Mohammad J Ahmad";

            //Printout variables
            Console.WriteLine(strName);
            Console.WriteLine(intPrice);
            Console.WriteLine("Give me age");

            //Read from usuer the age
            intAge = Convert.ToInt32(Console.ReadLine());

            //Print out age
            Console.WriteLine(intAge);


        }


    }
}

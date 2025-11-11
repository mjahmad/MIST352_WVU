namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
/*
            Car BMW = new Car();
            BMW.Model="";
            BMW.DisplayInfo();

            Car Malibuc = new Car("Chevy", "Malibu");
            Malibuc.DisplayInfo();*/

            Employee Kayla = new Employee("Kayla");
            Kayla.DisplayInfo();
            Kayla.HoursPerWeek = -1;
            Kayla.HourlyRate = 101;
            Kayla.DisplayInfo();



        }
    }
}

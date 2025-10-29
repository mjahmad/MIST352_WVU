using System.Runtime.CompilerServices;

namespace Students_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student mj = new Student("800-0000", "MJ", "Ahmad");
           
            mj.SetGPA(2.1);
            mj.phone = "555-55-5555";
            mj.PrintInfo();

            Student NewStudent = new Student("900-0011");


            Student sarah = new Student("900-000", "Sarah","Gree");
        
            sarah.SetGPA(4.0);
            sarah.phone = "555-22-2222";
            sarah.PrintInfo();

            if (mj.GetGPA() < sarah.GetGPA())

            {
                Console.WriteLine($"{sarah.FirstName} is smarter than {mj.FirstName}");
            }
            else
            {
                Console.WriteLine($"{mj.FirstName} is smarter than {sarah.FirstName}");

            }


        }
    }
}

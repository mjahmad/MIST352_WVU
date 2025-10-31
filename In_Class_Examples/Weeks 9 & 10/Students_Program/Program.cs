using System.Runtime.CompilerServices;

namespace Students_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FancyStudent Student1 = new FancyStudent("Sarah Ahmad", 22, 3.5);
            FancyStudent Student2 = new FancyStudent("Beth Green");
            FancyStudent Student3 = new FancyStudent(22);
           
            Student1.DisplayInfo();
            Student2.DisplayInfo(); 
            Student3.DisplayInfo();

            Console.WriteLine(Student1.Name);

            // Now, try changing a student's name to nothing and see what hapens. 
            Student1.Name = "";




            //Student mj = new Student("800-0000", "MJ", "Ahmad");

            //mj.SetGPA(2.1);
            //mj.phone = "555-55-5555";
            //mj.PrintInfo();

            //Student NewStudent = new Student("900-0011");


            //Student sarah = new Student("900-000", "Sarah", "Gree");

            //sarah.SetGPA(4.0);
            //sarah.phone = "555-22-2222";
            //sarah.PrintInfo();

            //if (mj.GetGPA() < sarah.GetGPA())

            //{
            //    Console.WriteLine($"{sarah.FirstName} is smarter than {mj.FirstName}");
            //}
            //else
            //{
            //    Console.WriteLine($"{mj.FirstName} is smarter than {sarah.FirstName}");

            //}


        }
    }
}

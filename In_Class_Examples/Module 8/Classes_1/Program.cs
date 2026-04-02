namespace Classes_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            STUDENT st1 = new STUDENT();
            LECTURE lt1 = new LECTURE();
            st1.FirstName = "MJ";
            st1.LastName = "Ahmad";
            //st1.ID = "100";
            st1.firstGrades = 90.8;
            st1.PrintInfo();
            lt1.professor = "Sarah Conor";
            lt1.location = "4006 REH";
            lt1.startTime = "10:00AM";
            lt1.Capacity = 25;



            //st2.FirstName = "Sarah";
            //st2.LastName = "Conor";
            //st2.ID = "101";
            //st2.firstGrades = 93.6;

        }
    }
}

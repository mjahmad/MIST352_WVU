namespace Students_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi");
            Student St1 = new Student("Sarah Smith", 5);
            St1.PrintTranscript();
            CourseGrade St1G1 = new CourseGrade("MIST352", 90, 3);
            CourseGrade St1G2 = new CourseGrade("MIST351", 100, 3);
            CourseGrade St1G3 = new CourseGrade("MIST353", 55, 3);
            CourseGrade St1G4 = new CourseGrade("MIST400", 77, 3);

            St1.AddGrade(0,new CourseGrade("MIST460",88, 4));
            St1.AddGrade(1, St1G1);
            St1.AddGrade(2, St1G2);
            St1.AddGrade(3, St1G3);
            St1.AddGrade(4, St1G4);

            St1.PrintTranscript();


        }
    }
}

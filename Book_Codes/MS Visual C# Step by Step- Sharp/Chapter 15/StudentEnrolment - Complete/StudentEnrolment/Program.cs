using System;

namespace StudentEnrolment
{
    class Program
    {
        static void doWork()
        {
            var enrolments = new Enrolment[4];
            enrolments[0] = new Enrolment(StudentID: 1, CourseName: "Physics", DateEnrolled: new DateOnly(2021, 07, 20));
            enrolments[1] = new Enrolment(StudentID: 1, CourseName: "Chemistry", DateEnrolled: new DateOnly(2021, 07, 20));
            enrolments[2] = enrolments[0];
            enrolments[3] = enrolments[0] with { StudentID = 2};

            foreach (var enrolment in enrolments)
            {
                Console.WriteLine($"{enrolment}");
            }

            var firstEnrolment = enrolments[0];
            foreach (var enrolment in enrolments[1..4])
            {
                Console.WriteLine($"{firstEnrolment == enrolment}");
            }

            //enrolments[0].DateEnrolled = new DateOnly(2021, 08, 15);
        }

        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

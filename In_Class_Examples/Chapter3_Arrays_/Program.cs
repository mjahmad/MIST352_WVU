/*
 * Genlte introduction to arrays and for loops
 * Tuesday 9/9/25
 */
namespace Chapter3_Arrays_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // lets calcaulte avegrae of grades (old way using variables)
            String strName = "MJ Ahmad";
            double dblGrade1 = 50, dblGrade2 = 90, dblGrade3 = 63, dblGrade4 = 80, dblGrade5 = 70, dblAvg = 0, dblSum=0;
            //dblAvg = (dblGrade1 + dblGrade2 + dblGrade3 + dblGrade4 + dblGrade5) / 5;
            //Console.WriteLine($"Hello {strName}, your average is {dblAvg}");

            // define an arrray of double to store the grades.
            double[] dblGradesFancy = { 50, 90, 63, 80, 70, 90, 99 };
            String[] strAssessments = { "Task1", "HW1", "Task2", "Quiz1", "Exam1", "HW2","Exam2"};

            //Print out each individual grade (long and awful especially if you have many grades)
            //Console.WriteLine($"{dblGradesFancy[0]} - {dblGradesFancy[1]} - {dblGradesFancy[2]} - {dblGradesFancy[3]} - {dblGradesFancy[4]}");
            //calcutel the avergae (manually)
            //dblAvg = (dblGradesFancy[0] + dblGradesFancy[1] + dblGradesFancy[2] + dblGradesFancy[3] + dblGradesFancy[4]) / 5;
            //Console.WriteLine($"Hello {strName}, your average is {dblAvg}");

            //for loop to interact with arrays
            // standard way to deal with arrays is to use for loop
            // index start at zero, keeps track of items to read, until the last item (at index length - 1) is reched.
            // everytime i access a new item, add it to sum, kepe doing that until no grades are there to read
            for (int intIndex = 0; intIndex < dblGradesFancy.Length; intIndex++)
            {
                //dblSum = dblSum + dblGradesFancy[intIndex];
                
                dblSum += dblGradesFancy[intIndex];

                //Console.WriteLine($"{strAssessments[intIndex]}==={dblGradesFancy[intIndex]}");
            }
            // Now i have sum or all grades, simply divide it over the number of grades to get average.
            Console.WriteLine($"The average is {dblSum / dblGradesFancy.Length}");


        }
    }
}
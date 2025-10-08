/*
 * Tuesday 9/16/25
 * Ask user for several grades. Evaluate each and summerize all grades
 */

namespace IF_Multiple_Grades_Evaluation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many grade do you have?");
            //Read number of grades as integer (conversion is needed)
            int intNoGrades = Convert.ToInt32(Console.ReadLine());
            //variable to summerize letter grades
            int intAs = 0, intBs = 0, intCs = 0, intDs = 0, intFs = 0;
            //Create an atrray of double with the specified number of grades.
            double [] dblGrades = new double [intNoGrades];
            char [] chrLetterGrades = new char [intNoGrades];

            //collecting grade and stroing in the array
            for (int intIndex = 0; intIndex < dblGrades.Length; intIndex++)
            {
                Console.WriteLine($"What is grade no {intIndex+1}?");
                dblGrades[intIndex] = Double.Parse(Console.ReadLine());

            }

            //evaluation 
            for (int intIndex = 0; intIndex < dblGrades.Length; intIndex++)
            {
                if (dblGrades[intIndex] >= 90)
                {
                    chrLetterGrades[intIndex] = 'A';
                    intAs++;
                }
                else if (dblGrades[intIndex] >= 80)
                {
                    chrLetterGrades[intIndex] = 'B';
                    intBs++;
                }
                else if (dblGrades[intIndex] >= 70)
                {
                    chrLetterGrades[intIndex] = 'C';
                    intCs++;
                }
                else if (dblGrades[intIndex] >= 60)
                {
                    chrLetterGrades[intIndex] = 'D';
                    intDs++;
                }
                else
                {
                    chrLetterGrades[intIndex] = 'F';
                    intFs++;
                }
            }
            Console.WriteLine($"No of A\t\t{intAs}\nNo of B\t\t{intBs}\nNo of C\t\t{intCs}\nNo of D\t\t{intDs}\nNo of F\t\t{intFs} ");



        }
    }
}

/*
 * Thursday 9/11/2025
 * 
 */

namespace Chapter3_Arrays_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // define an array of grades and assessments
            string[] strAssessments = { "Task1", "HW1", "Task2", "Quiz1", "Exam1", "HW2", "task3", "QUIZ2" };
            float[] fltGrades = { 90, 88, 70, 95, 60, 50, 77, 50 };

            //for loop to access/ read/ manipulate contetns of the array
            Console.WriteLine("Printout all arrays contents");
            for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
            {
                Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");
            }

            Console.WriteLine("===================================================");
            Console.WriteLine("Printout homeworks only and their grades.");

            for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
            {
                if (strAssessments[intIndex].Contains("HW"))
                {
                    Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");

                }

            }

            Console.WriteLine("===================================================");
            Console.WriteLine("Printout homeworks and tasks only and their grades (regarless upper or lower case).");

            for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
            {
                if (strAssessments[intIndex].ToLower().Contains("HW".ToLower()) || strAssessments[intIndex].ToLower().Contains("Task".ToLower()))
                {
                    Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");

                }

            }


            Console.WriteLine("===================================================");
            

        }
    }
}


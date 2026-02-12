namespace Operattors_If
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Part 1: Is a number positive or nagative?
            //int intValue = 0;

            //if (intValue > 0)
            //{
            //    Console.WriteLine($"{intValue} is positive");
            //}
            //else if (intValue < 0)
            //{
            //    Console.WriteLine($"{intValue} is negative");

            //}
            //else
            //{
            //    Console.WriteLine($"{intValue} is zero, funny you!");

            //}



            //// part 2: array of grades, evaluate each pass/fail///////////////////////////////////////////////
            //double[] dblGrades = { 55,66,79,88,99};

            //if (dblGrades[0] >= 60)
            //{
            //    Console.WriteLine($"{dblGrades[0]} => Valid and Pass");
            //}
            //else
            //{
            //    Console.WriteLine($"{dblGrades[0]} => Fail");
            //}

            //if (dblGrades[1] >= 60)
            //{
            //    Console.WriteLine($"{dblGrades[1]} => Pass");
            //}
            //else
            //{
            //    Console.WriteLine($"{dblGrades[1]} => Fail");
            //}

            //if (dblGrades[2] >= 60)
            //{
            //    Console.WriteLine($"{dblGrades[2]} => Pass");
            //}
            //else
            //{
            //    Console.WriteLine($"{dblGrades[2]} => Fail");
            //}

            //if (dblGrades[3] >= 60)
            //{
            //    Console.WriteLine($"{dblGrades[3] }=> Pass");
            //}
            //else
            //{
            //    Console.WriteLine($"{dblGrades[3]} => Fail");
            //}

            //if (dblGrades[4] >= 60)
            //{
            //    Console.WriteLine($"{dblGrades[4]} => Pass");
            //}
            //else
            //{
            //    Console.WriteLine($"{dblGrades[4]} => Fail");
            //}

            //
            //double dblGradesSum = dblGrades[0] + dblGrades[1] + dblGrades[2] + dblGrades[3] + dblGrades[4]  ;
            //double dblAvg = dblGradesSum / dblGrades.Length;
            //Console.WriteLine($"The average is {dblAvg}");
            //if (dblAvg < 0 || dblAvg > 100)
            //{
            //    Console.WriteLine("Invalid");

            //}
            //else if (dblAvg >= 60)
            //{
            //    Console.WriteLine("Pass");

            //}

            //else
            //{
            //    Console.WriteLine("Fail");
            //}

            double dblMyGrade = 78;
            // if the issue is to decide wthere + or - , then you inly if and else
            if (dblMyGrade > 0)
            {
                Console.WriteLine("Positive");
                Console.WriteLine("hi");

            }
            else
            {
                Console.WriteLine("Positive");
            }


            // print letter grade from mygade
            if (dblMyGrade >= 90)
            {
                Console.WriteLine('A');

            }
            else if (dblMyGrade >= 80)
            {
                Console.WriteLine('B');

            }
            else if (dblMyGrade >= 70)
            {
                Console.WriteLine('C');

            }
            else if (dblMyGrade >= 60)
            {
                Console.WriteLine('D');

            }
            else
            { 
                Console.WriteLine('F');
            }


        }
    }
}

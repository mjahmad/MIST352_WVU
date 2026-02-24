namespace ForLoops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare an empty array to store the grades.
            double[] dblGrades = new double[5];

            for (int intIndex = 0; intIndex < dblGrades.Length; intIndex++)
            {
                Console.WriteLine($"Give me grade No {intIndex + 1}");
                dblGrades[intIndex] = Double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Lets test the array");

            for (int intIndex = 0; intIndex < dblGrades.Length; intIndex++)
            {
                Console.WriteLine(dblGrades[intIndex]);
            }


            Console.WriteLine("Lets calcualte average");
            double dblSum = 0, dblAvg = 0;

            for (int intIndex = 0; intIndex < dblGrades.Length; intIndex++)
            {
                //dblSum = dblSum + dblGrades[intIndex];
                dblSum+= dblGrades[intIndex]; 
                //Console.WriteLine(dblGrades[intIndex]);
            }
            dblAvg = dblSum/dblGrades.Length;
            Console.WriteLine($"The Averga of all grades is {dblAvg}");


            Console.WriteLine("Lets find max and min ");
            double dblMax = dblGrades[0]; double dblMin = dblGrades[0];
            for (int intIndex = 0; intIndex < dblGrades.Length; intIndex++)
            { 
                // Check whethe the current item accessed is >= the current max
                if (dblGrades[intIndex]>=dblMax)
                    dblMax = dblGrades[intIndex];
                
                if (dblGrades[intIndex] <= dblMin)
                    dblMin = dblGrades[intIndex];
            }
            Console.WriteLine($"The highest grade is {dblMax}");
            Console.WriteLine($"The lowest grade is {dblMin}");


        }
    }
}

namespace Methods_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] dblSalaries = { 10000, 90000, 80000, 60000, 75000 };
            double[] dblPersonalTaxRates = { 0.5, 0.1, 0.15, 0.12 , 0.14};
            string[] strNames = { "Sarah Johnson", "Ali ahmad", " Mike Mike", " Ashley Smith", " Tiffany Mike" };
            //PrintHighestSalary(dblSalaries);
            int intIndexhighest = HighestSalaryIndex(dblSalaries);
            Console.WriteLine(intIndexhighest);
            Console.WriteLine(strNames[intIndexhighest]);
            double dblSalariesAvg = SalaryAvg(dblSalaries);
            Console.WriteLine(dblSalariesAvg);
            double[] dblProcessedTaxes = TaxAmonts(dblSalaries,dblPersonalTaxRates);

            for (int intIndex = 0; intIndex < dblProcessedTaxes.Length; intIndex++)
            {
                Console.WriteLine(dblProcessedTaxes[intIndex]);
            }
        }
        public static double[] TaxAmonts(double[] theSalaries, double[] rates)
        {
            double[] dblTaxes = new double[theSalaries.Length];

            for (int intIndex = 0; intIndex < theSalaries.Length; intIndex++)
            {

                dblTaxes[intIndex] = rates[intIndex] * theSalaries[intIndex];
            }

            return dblTaxes;
        
        }


        public static double SalaryAvg(double[] salaries)
        {
            double dblAvg = 0, dblSum = 0 ;

            for (int intIndex = 0; intIndex < salaries.Length; intIndex++)
            { 
                dblSum += salaries[intIndex];
            }
            dblAvg = dblSum / salaries.Length-1;
            return dblAvg;
        }

        /// <summary>
        /// This method rerutns the index of the highest salary found in the array of salaries
        /// </summary>
        /// <param name="salaries"> The array that contains all salaries</param>
        /// <returns> Index of the highest salary found.</returns>
        public static int HighestSalaryIndex(double[] salaries)
        {
            //{ 10000, 90000, 80000, 60000, 75000 };

            int intHighestIndex = 0;
            double dblHighest = salaries[0]; //=>10000
            for (int intIndex = 0; intIndex < salaries.Length; intIndex++)
            {
                if (dblHighest < salaries[intIndex])
                {                    dblHighest = salaries[intIndex];

                    intHighestIndex = intIndex; //=> 1          
                }

            }
            return intHighestIndex;

        }

        /// <summary>
        /// This methods prints out the highets salary fond in the array
        /// </summary>
        /// <param name="theSalaries">The array of salaries</param>
        public static void PrintHighestSalary(double[] theSalaries)
        {
            double dblHighest = theSalaries[0];
            for (int intIndex = 0; intIndex < theSalaries.Length; intIndex++)
            {
                if (dblHighest < theSalaries[intIndex])
                {
                    dblHighest = theSalaries[intIndex];
                }
            }
            Console.WriteLine(dblHighest);
            
        }
    }
}

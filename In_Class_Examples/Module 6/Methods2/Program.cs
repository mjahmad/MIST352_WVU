/**
 * More about methods. Mainly, non-void methods
 */

    internal class Program
    {
        static void Main(string[] args)
        {
        double[] dblTaxesRates = {0.10, 0.15, 0.13, 0.30 };
        double[] dblSalesAmount = { 600, 500, 830, 970 };
        //DisplayTaxRateAmounts(dblTaxesRates, dblSalesAmount);
        double[] dblSalesTaxAmounts = SalesTaxAmounts(dblTaxesRates, dblSalesAmount);
        //PrintGreetings();

        ////15% tax rate => 500
        //// 17% tax rate => 430
        //DisplaySalesTax(0.16, 500);
        //DisplaySalesTax(0.17, 430);

        ////Compare two sales tax amounts
        //if (CalculateSalesTax(0.16,500) > CalculateSalesTax(.17,450))
        //    Console.WriteLine("Transaction 1 is greater");
        //else
        //    Console.WriteLine("Transaction 1 is greater");

        ////Just call the circle area and display it
        //Console.WriteLine($"The area of a circle with raduis {10} is {CircleArea(10)}");

        ////Comapre the two areas.
        //double dblCircle1 = CircleArea(13), dblCircle2 = CircleArea(10);
        //if (dblCircle1 > dblCircle2)
        //    Console.WriteLine("Circle 1 is bigger");
        //else
        //    Console.WriteLine("Circle 2 is bigger");




    }

    public static double[] SalesTaxAmounts(double[] rates, double[] sales)
    {
        //create an empty array of doubles with same size as rates
        double[] FinalTaxAmounts = new double[rates.Length];

        for (int intIndex = 0; intIndex < rates.Length; intIndex++)
        { 
        FinalTaxAmounts[intIndex] = rates[intIndex] * sales[intIndex];
        }
        return FinalTaxAmounts;
    }



    /// <summary>
    /// This acceptas two arrays (rates and amounts) and displays the total tax amount for each elements in the arrays
    /// </summary>
    /// <param name="taxRates"></param>
    /// <param name="salesAmounts"></param>
    public static void DisplayTaxRateAmounts(double[] taxRates, double[] salesAmounts)
    {
        for (int intIndex = 0; intIndex < taxRates.Length; intIndex++)
        {
            Console.WriteLine($"{taxRates[intIndex] * salesAmounts[intIndex]}");
        }
    
    }

    /// <summary>
    /// This prints some messages.
    /// </summary>
    public static void PrintGreetings()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("This project is all about methods");

    }
    /// <summary>
    /// 
    /// This Displays athe sales tax
    /// </summary>
    /// <param name="dblTaxRate"></param>
    /// <param name="dblSalesAmount"></param>
    public static void DisplaySalesTax(double dblTaxRate, double dblSalesAmount)
    {
        Console.WriteLine($"Sales tax: {dblTaxRate * dblSalesAmount}");
    
    }
    /// <summary>
    /// This calcaultes sales tax 
    /// </summary>
    /// <param name="dblTaxRate"></param>
    /// <param name="dblSalesAmount"></param>
    /// <returns> The final sales tax</returns>
    public static double CalculateSalesTax(double dblTaxRate, double dblSalesAmount)
    {

        return dblTaxRate * dblSalesAmount ;
    }

    /// <summary>
    /// Calculate the area of a given circle given its raduis.
    /// </summary>
    /// <param name="dblRad"></param>
    /// <returns>The area</returns>
    public static double CircleArea(double dblRad)
    { 
        return Math.PI * Math.Pow(dblRad, 2); ;
    }
}


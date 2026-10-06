
internal class Program
{
    static void Main(string[] args)
    {
        //PrintMessages();
        //Console.WriteLine("What is your full name?");
        //string strName = Console.ReadLine();
        //PrintLastName(strName);
        //double[] dblSalaries = { 90000, 100000, 2500, 1000000,85000,75000 };
        //PrintMaxSalary(dblSalaries);
        //PrintMinSalary(dblSalaries);
        //PrintAvg(dblSalaries);
        PrintCircleArea("MJ",10.0);
        PrintCircleArea("Sarah", 11.0);

        PrintCircleArea("Mike", 102.0);
        PrintCircleArea("Ali", 1000.0);


    }

    public static void PrintCircleArea(string strCircleName, double dblRaduis)
    {
        Console.WriteLine($"{strCircleName}'s circle with raduis of {dblRaduis} is {Math.PI * Math.Pow(dblRaduis,2)}");
    }

    public static void PrintAvg(double[] theCats)
    {
        double  dblSum=0;
        for (int intIndex = 0; intIndex < theCats.Length; intIndex++)
        {
            dblSum += theCats[intIndex];
            dblSum = dblSum + theCats[intIndex];
        }
        Console.WriteLine($"The averag salary is {dblSum / theCats.Length}");



    }

    /// <summary>
    /// This method prints out the minimum value (salary) in a given array
    /// </summary>
    /// <param name="theSalaries"></param>
    public static void PrintMinSalary(double[] theSalaries)
    {
        double dblMin = theSalaries[0];
        for (int intIndex = 0; intIndex < theSalaries.Length; intIndex++)
        {
            if (theSalaries[intIndex] < dblMin)
            {
                dblMin = theSalaries[intIndex];
            }
        }
        Console.WriteLine($"The min value{dblMin}");

    }
    public static void PrintMaxSalary(double[] theSalaries)
    {
        double dblMax = theSalaries[0];
        for (int intIndex = 0; intIndex < theSalaries.Length; intIndex++)
        {
            if (theSalaries[intIndex] > dblMax)
            {
                dblMax = theSalaries[intIndex];
            }
        }
        Console.WriteLine($"The max value{dblMax}");

    }

    public static void PrintLastName(string strFullName)
    {
        string[] splittedName = strFullName.Split(" ");
        Console.WriteLine(splittedName[2]);
    }

    /// <summary>
    /// Simply greet user with lovely messages
    /// </summary>
    public static void PrintMessages()
    {
        Console.WriteLine("Welcome. This program is about methods");
        Console.WriteLine("You may choose an option later");
        Console.WriteLine("You can not use numbers here as input");

    }

    }


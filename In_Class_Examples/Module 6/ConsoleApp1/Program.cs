
    internal class Program
    {
        static void Main(string[] args)
        {
        //PrintMessages();
        PrintMessages();
        string strName = "Mohammad Jamil ahmad";
        PrintLastName("Sarah Mike Conor");

        double[] dblSalaries = { 25000,100000,90000,500000,50000};
        PrintMaxSalary(dblSalaries);
        PrintMinSalary(dblSalaries);
        PrintCircleArea("Mike",10);
        PrintCircleArea("Sarah", 10);
        PrintCircleArea("Ali", 150);
        PrintCircleArea("Callie", 10);
        PrintCircleArea("Me", 10643);
        PrintCircleArea("You", 10);
        PrintCircleArea("nobody", 10);
        PrintCircleArea("cats", 1055);
        PrintCircleArea("dogs", 106433);

    }

    public static void PrintCircleArea(string strName, double dblRaduis)
    {
        Console.WriteLine($"{strName}'s circle, with raduis of {dblRaduis} has an area of {Math.PI * Math.Pow(dblRaduis,2)}");
    }


    public static void PrintMinSalary(double[] dblAllSalaries)
    {
        double dblMin = dblAllSalaries[0];
        for (int intIndex = 0; intIndex < dblAllSalaries.Length; intIndex++)
        {
            if (dblAllSalaries[intIndex] < dblMin)
            {
                dblMin = dblAllSalaries[intIndex];
            }
        }
        Console.WriteLine($"The min salary is {dblMin}");
    }
    /// <summary>
    /// The method prints out the maximim value in an array (salary)
    /// </summary>
    /// <param name="dblAllSalaries"></param>
    public static void PrintMaxSalary(double[] dblAllSalaries)
    {
        double dblMax = dblAllSalaries[0];
        for (int intIndex = 0; intIndex < dblAllSalaries.Length; intIndex++)
        {
            if (dblAllSalaries[intIndex] > dblMax)
            {
                dblMax = dblAllSalaries[intIndex];
            }
        }
        Console.WriteLine($"The max salary is {dblMax}");
    }

    public static void PrintLastName(string strFullName)
    {
        string[] strSplittedNames = strFullName.Split(" ");
        Console.WriteLine($"The last name is {strSplittedNames[2].ToUpper()}");       
    
    
    }

    /// <summary>
    /// This method prints out lovley messages to user
    /// </summary>
    public static void PrintMessages()
    {
        Console.WriteLine("Hello welcome to our program");
        Console.WriteLine("This is just a demo");
        Console.WriteLine("Inputs will come later");

    }

    }


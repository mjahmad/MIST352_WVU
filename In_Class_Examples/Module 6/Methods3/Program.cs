
    internal class Program
    {
    static void Main(string[] args)
    {
        string strName = "MoHaMMaD jamil mohammad Khalid AHMad";
        //string strName2 = "Sarah";
        //Console.WriteLine(strName2[0]);
        //string strFixedName = Extract1st_LastName(strName2);
        //Console.WriteLine(strFixedName);
        //Console.WriteLine(ExtractInitials(strName));
        PrintData(strName);

        }
    /// <summary>
    /// 
    /// This method extracts and processes first and last name from a given name
    /// </summary>
    /// <param name="theName"></param>
    /// <returns>First and last name, seperated by a space and lowered</returns>
    public static string Extract1st_LastName(string theName)
    {

        //a varibale named theName = >get first and last name only
        string[] splittedName = theName.Split(' ');
        string strFinalProcessedName = splittedName[0] +" " + splittedName[splittedName.Length-1] ;
        //string strFinalProcesedName = String.Concat(splittedName[0], " ", splittedName[splittedName.Length - 1]);

        return strFinalProcessedName.ToLower();

    }

    /// <summary>
    /// 
    /// Recieves a name and return initials (upper case) of 1st, 2nd, and last name
    /// </summary>
    /// <param name="theName"></param>
    /// <returns> Initials all upper case</returns>
    public static string ExtractInitials(string theName)
    {
        string[] splittedText = theName.Split(' ');
        //Console.WriteLine(splittedText[0][0]);
        //Console.WriteLine(splittedText[1][0]);
        //Console.WriteLine(splittedText[0][0] + splittedText[1][0]);

        string strInitials = splittedText[0].Substring(0, 1) + splittedText[1].Substring(0, 1) + splittedText[splittedText.Length - 1].Substring(0, 1);

        return strInitials.ToUpper();
        return (splittedText[0][0].ToString() + splittedText[1][0]+ splittedText[splittedText.Length - 1][0]).ToUpper();

    
    }

    public static void PrintData(string theName)
    {

        Console.WriteLine($"The given name was {theName}, the extracted first and last names are {Extract1st_LastName(theName)}, and the initials are {ExtractInitials(theName)}");
    }
    }


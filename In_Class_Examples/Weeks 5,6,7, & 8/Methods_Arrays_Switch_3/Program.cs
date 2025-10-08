namespace Methods_Arrays_Switch_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strNames = { "Sarah","Ahmad","John", "Sarah","Tiffany", "Mike", "Rachel", "Sarah" , "Sarah" };
            char chrUserChoice = 'A';
            while (chrUserChoice != 'X')
            {
                WelcomeMessageAndOptions();
                chrUserChoice = Console.ReadKey().KeyChar;

                switch (chrUserChoice)
                {
                    case 'A':
                        Console.WriteLine("\nOk this will printout the name in the array");
                        PrintOutNames(strNames);
                        break;
                    case 'B':
                        Console.WriteLine("\nOk this will search for a name in the array");
                        Console.WriteLine("\nGive me a name to search for.");
                        string strNameToSearchFor = Console.ReadLine();

                        SearchForName(strNameToSearchFor, strNames);
                        break;
                    case 'X':
                        Console.WriteLine("\nGood bye. The program will now exit");

                        break;
                    default:
                        Console.WriteLine("\nInvalid inoput. Try again");
                        break;

                }


            }



          

            
        }

        static void WelcomeMessageAndOptions()
        {
            Console.WriteLine("\nWelcome. Choose an option from below");
            Console.WriteLine("\nA - printout all names in the array\nB- Search for a name in the array\nX- Exit hte program");
        }

        /// <summary>
        /// Printout the contents of a given array
        /// </summary>
        /// <param name="strNames"> The array of data coming from outside</param>
        static void PrintOutNames(string[] strNames)
        {
            for (int intIndex = 0; intIndex < strNames.Length; intIndex++)
            {
                Console.WriteLine(strNames[intIndex]);
            }
        }

        /// <summary>
        /// Finds and reports the locaiton of a given name in the given array of names
        /// </summary>
        /// <param name="strTheNameToFind"> The name to find in the array (external)</param>
        /// <param name="strTheNamesArray"> The array of names to search in (external) </param>
        static void SearchForName(string strTheNameToFind, string[] strTheNamesArray)
        {
            for (int intIndex = 0; intIndex < strTheNamesArray.Length; intIndex++)
            {
                if (strTheNamesArray[intIndex].Equals(strTheNameToFind))
                {
                    Console.WriteLine($"The name {strTheNameToFind} found in locantio {intIndex}");
                }

            }
        }

        
    }
}

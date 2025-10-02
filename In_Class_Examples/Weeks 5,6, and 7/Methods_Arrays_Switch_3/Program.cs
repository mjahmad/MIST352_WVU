namespace Methods_Arrays_Switch_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strNames = { "Sarah","Ahmad"," John", "Sarah","Tiffany", "Mike", "Rachel", "Sarah" , "Sarah" };
            char chrUserChoice = 'A';

            while (chrUserChoice != 'X')
            {
                DisplayWlecomeAndOptions();

             chrUserChoice = Console.ReadKey().KeyChar;
                
                switch (chrUserChoice)
                {
                    case 'A':
                        //do something here
                        Console.WriteLine($"\nYou clicked {chrUserChoice}, I will printout the array for you");
                        PrintNames(strNames);
                        break;
                    case 'B':
                        //dom something else here
                        Console.WriteLine($"\nYou clicked {chrUserChoice}, We will search for a name in the array");
                        Console.WriteLine("Give me a name to search for");
                        string strNameFromUser = Console.ReadLine();
                        SearchForName(strNames, strNameFromUser);
                        break;
                    case 'X':
                        //dom something else here
                        Console.WriteLine($"\nYou clicked {chrUserChoice}, Program is exiting - Good bye");
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input, try again");
                        break;


                }
                
          

            }
        }

        static void DisplayWlecomeAndOptions()
        {
            Console.WriteLine("\nChoose an option from below:\n");
            Console.WriteLine("\nA- Print out all names \n B- Search for a name \n X to exit\n");
        }

        /// <summary>
        /// Printout the content of the array of strings
        /// </summary>
        /// <param name="strTheNames"> The array passed from outside with data (names)</param>
        static void PrintNames(string[] strTheNames)
        {
            for (int intIndex = 0; intIndex < strTheNames.Length; intIndex++)
            {
                Console.WriteLine(strTheNames[intIndex]);
            
            }

        
        }

        /// <summary>
        /// Seach for a given name in a given array
        /// </summary>
        /// <param name="strTheNames"> Array full of names from the main method</param>
        /// <param name="strNameToLookFor"> Name to search for in the array</param>
        static void SearchForName(string[] strTheNames, string strNameToLookFor)
        {
            bool blnNotFound = false;
            //Console.WriteLine("Give me a name to search for in the array");
            for (int intIndex = 0; intIndex < strTheNames.Length; intIndex++)
            {
                if (strTheNames[intIndex].Equals(strNameToLookFor))
                    Console.WriteLine($"Name found at location {intIndex}");
                else
                    blnNotFound = true;

            }
            if (blnNotFound) 
            
            {
                Console.WriteLine($"The name {strNameToLookFor} is not found anywhere in the array");
            
            }



        }


    }
}

using System.Reflection.PortableExecutable;

namespace Methods_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            int[] intData = { 90, 100, 77, -1, -9, 0,0,0,1,200 };

            //DisplayAll(intData);
            if (ValidIdentity())
                Console.WriteLine("Welcome");
            else
                Console.WriteLine("Invalid user or password");

            string[] theNames = AcceptNames();
            PrintDataInArray(theNames);



        }

        /// <summary>
        /// This simply prints out all data in any given array
        /// </summary>
        /// <param name="names"></param>
        public static void PrintDataInArray(string[] names)
        {
            for (int intIndex = 0; intIndex < names.Length; intIndex++)
            {
                Console.WriteLine(names[intIndex]);
            }

        }

        /// <summary>
        /// This method accepts 5 names from user into an array
        /// </summary>
        /// <returns>The array of names</returns>
        public static string[] AcceptNames()
            {
            string[] strNames = new string[5];
            for (int intdIndex = 0; intdIndex < strNames.Length; intdIndex++)
            {
                Console.WriteLine($"Give me name No. {intdIndex+1}");
                strNames[intdIndex] = Console.ReadLine(); 

            }
            return strNames;


            }


        public static void DisplayAll(int[] intData)
        {
            DisplayInfo();
            Console.WriteLine(FindMax(intData));

            Console.WriteLine(FindMin(intData));
        }

        /// <summary>
        /// This msethod verifies the identity of a given user
        /// It accepts user name and password and verifies they are equal to pre-coded credintials.
        /// </summary>
        /// <returns>True if user and pass are correct, false otherwise.<returns>
        public static bool ValidIdentity()
        {
            Console.WriteLine("Give me your user name");
            string strUser = Console.ReadLine();

            Console.WriteLine("Give me your password");
            string strPass = Console.ReadLine();
            if (strUser.Equals("user1") && strPass.Equals("pass1"))
                return true;

            return false;
        }


        /// <summary>
        /// This method finds the max value in a given array
        /// </summary>
        /// <param name="theData"> The array or integers </param>
        /// <returns>The maximum value in the array</returns>
        public static int FindMax(int[] theData)
        {
            int intMax = theData[0];
            for (int intIndex = 0; intIndex < theData.Length; intIndex++)
            {
                if (theData[intIndex] >= intMax)
                    intMax = theData[intIndex];

            }
            return intMax;
        
        }

        /// <summary>
        /// This method finds the min value in a given array
        /// </summary>
        /// <param name="theData"> The array or integers </param>
        /// <returns>The min value in the array</returns>
        public static int FindMin(int[] theData)
        {
            int intMin = theData[0];
            for (int intIndex = 0; intIndex < theData.Length; intIndex++)
            {
                if (theData[intIndex] <= intMin)
                    intMin = theData[intIndex];

            }
            return intMin;

        }
        /// <summary>
        /// This simply calls all methods in this program
        /// It prints out the messages in DisplayInfo, and min and max by calling 
        /// the two other methods (FindMin , and FindMax).
        /// </summary>
        public static void DisplayInfo()
        {
            Console.WriteLine("Good morning, World!");
            Console.WriteLine("This will find min and max!");

        }

    }
}

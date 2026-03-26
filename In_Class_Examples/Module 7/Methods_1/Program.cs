using System;

namespace Methods_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intNo1 = 100, intNo2 = 90, intNo3 = 60;
            string strMyName = "Mohammad Jamil Ahmad";
            
           //ShowMenu();
            
            Console.WriteLine(CalculateAvg(intNo1, intNo2, intNo3));

            Console.WriteLine($"The letter grade of {intNo3} is {CalculateLetterGrade(intNo3)}");

            Console.WriteLine($"The initials of the name {strMyName} is {GetInitials(strMyName)}");


        }
        /// <summary>
        /// this simply displays the menu options.
        /// </summary>
        public static void ShowMenu()
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(" Option 1: Display info");
            Console.WriteLine(" Option 2: Accept Data");
            Console.WriteLine(" Option 3: Calcualte GPA");
            Console.WriteLine(" Option 4: Exit");
        }

        /// <summary>
        /// The method calcaultes the average of three given values
        /// </summary>
        /// <param name="No1"> 1ST value</param>
        /// <param name="No2">2nd value</param>
        /// <param name="No3"> 3rd value</param>
        /// <returns> The avrage of No1, No2, and No3</returns>
        public static int CalculateAvg(int No1, int No2, int No3 )
        {
            int intAvg = (No1 + No2 + No3) / 3;
            return intAvg;
        
        }

        public static char CalculateLetterGrade(int intTheGrade)
        {
            if (intTheGrade >= 90)
                return 'A';
            else if (intTheGrade >= 80)
                return 'B';
            else if (intTheGrade >= 70)
                return 'C';
            else if (intTheGrade >= 60)
                return 'D';
            else
                return 'F';
        
        }

        /// <summary>
        /// This method accetps a name and return the initials of that name
        /// </summary>
        /// <param name="theName"> The name from the main mehtod</param>
        /// <returns>returns the initials</returns>
        public static string GetInitials(string theName)
        {
            string[] splittedName = theName.Split(" ");
            string strFirstName = splittedName[0];
            string strMidName = splittedName[1];
            string strLastName = splittedName[2];
            string chr1 = strFirstName.Substring(0,1);
            string chr2 = strMidName.Substring(0, 1);
            string chr3 = strLastName.Substring(0, 1);
            return chr1 + chr2 + chr3;

       }

    }
}

namespace More_Conditionals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strText = "Today is  2/12/2, tomorrow is . It is freezing. MIST352 @@ my email. Car. cat. ";
            bool blnThursdayFound = false;
            //Decide whether Thursday is there or not.
            //if (strText.Contains("Thursday"))
            //{
            //    Console.WriteLine("Found");
            //}
            //else
            //{ Console.WriteLine("Not Found"); }
            //// Do we have thurday without friday? If yes, print SAD.
            //// Do we have T and F? If yes, confused.
            //// Do we have F wihtout T? If yes, print happy.
            //if (strText.Contains("Thursday") && !strText.Contains("Friday"))
            //{
            //    Console.WriteLine("SAD");
            //}
            //else if (strText.Contains("Thursday") && strText.Contains("Friday"))
            //{
            //    Console.WriteLine("Confused");
            //}
            //else if (strText.Contains("Friday") && !strText.Contains("Thursday"))
            //{ Console.WriteLine("Happy"); }
            //else
            //    Console.WriteLine("IDK somethine else");

            //Print out th enumbe of postive nad negative values
            int[] intValues = { -50, 60, -70, 40, 66 };
            int intPostivies =0 , intNegatives = 0, intOdds =0, intEvens =0;

            if (intValues[0] > 0)
            
                intPostivies++;
            
            else
                intNegatives++;

            if (intValues[1] > 0)

                intPostivies++;

            else
                intNegatives++;

            if (intValues[2] > 0)

                intPostivies++;

            else
                intNegatives++;

            if (intValues[3] > 0)

                intPostivies++;

            else
                intNegatives++;

            if (intValues[4] > 0)

                intPostivies++;

            else
                intNegatives++;

            Console.WriteLine($"The number of positive values is {intPostivies} and The number of negative values is {intNegatives}");







            if (intValues[0] % 2 == 0)

                intEvens++;

            else
                intOdds++;
            if (intValues[1] % 2 == 0)

                intEvens++;

            else
                intOdds++;

            if (intValues[2] % 2 == 0)

                intEvens++;

            else
                intOdds++;
            if (intValues[3] % 2 ==0)

                intEvens++;

            else
                intOdds++;

            if (intValues[4] % 2 == 0)

                intEvens++;

            else
                intOdds++;

            Console.WriteLine($"The number of even values is {intEvens} and The number of odd values is {intOdds}");













        }
    }
}

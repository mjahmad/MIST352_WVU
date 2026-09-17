
internal class Program
{
    static void Main(string[] args)
    {
        int intAge = -10;
        double dblDiscoint = 0.0;
        string strUser = "Mike";
        //First, verify age is valid
        //A valid age is an age between 0 and 100.
      
            if (intAge < 0 || intAge >= 100 || strUser!="Sarah") 
            {
            Console.WriteLine("age is invalid, or you are not sarah");

            
            }
            else
        {
            Console.WriteLine("Thank you, age is valid");

            if (intAge >= 40)
            {
                Console.WriteLine("Welcome");
            }
            else
                Console.WriteLine("Get old and come back");
        }
        
        

















        //The discoun rules:
        //age <= 20 --> 25%
        //age between 21 and 40 --> 1   5%
        //age is 42 and bove --> 5%

        //assuming the age is correct:

        //True && True && False
        //If the user is Sarah and the age is valid .... then evaluate. ||
        //if (intAge < 0 || intAge > 100 || strUser == "Sarah")
        //{
        //    Console.WriteLine("Age is invalid or you are Sarah");
        //}


        //else
        //{
        //    Console.WriteLine("Age is valid");
        //    if (intAge <= 20)
        //        Console.WriteLine("25% discount");
        //    else if (intAge > 20 && intAge <= 40)
        //        Console.WriteLine("15%");
        //    else
        //        Console.WriteLine("5% discount");

        //}


        //if (intAge > 0 && intAge <= 100)
        //{
        //    Console.WriteLine("Thank you for providing your age");
        //    if (intAge >= 40)
        //    {
        //        Console.WriteLine("Welcome");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Get old and come back");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("Invalid age");

        //}



    }
}


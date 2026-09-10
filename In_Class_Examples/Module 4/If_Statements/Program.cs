
    internal class Program
    {
        static void Main(string[] args)
        {


        int intA = 30, intB = 90;
        string strName1 = "Sarah", strName2 = "Mike";
        //Basic if (you can use > greater than, >=greater than or equals to, < less than, <= less than or equal to, == equals, ! not)
        //check whether ot not two variables are equal. If yes, do something, if not, do something else.
        if (intA == intB) 
        {
            Console.WriteLine($"The value{intA} is greater than the value of {intB}");
        }
        else
        {
            Console.WriteLine($"The value {intA} is less than the value of {intB}");

        }

        //compare the two strings. Make sure both are lowered case or upper case. Unify the two =
        
        if ((strName1.ToLower()).Equals(strName2.ToLower()))
        {
            Console.WriteLine("Both names are identical");
            Console.WriteLine(" :D :D :D ");

        }
        else
        {
            Console.WriteLine("Names are not identical");
        }

        //using && and operator. 
        // True && True ==> True. True && False ==> False. False && True ==> False, False && False ==> False.
       
        if (strName2.ToLower().Equals("Mike".ToLower()) && intA >=70)
        {
            Console.WriteLine("Pass");
            Console.WriteLine("Good job");
        }
        else
        {
            Console.WriteLine("Fail");
            Console.WriteLine("Or maybe you are not Mike!");
        }



    }
}


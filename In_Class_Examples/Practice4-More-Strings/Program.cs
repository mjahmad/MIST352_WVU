// more about strings
namespace Practice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //next four lines are brilliant.
            //Ask user for some input, if user doesnt provide any input (pressed enter only), then make the string = the word empty
            Console.WriteLine("give me some text, if you dont, then i'll take care of it.");
            string? strInput = Console.ReadLine();
            strInput = string.IsNullOrEmpty(strInput) ? "empty" : strInput;
            Console.WriteLine($"The input you provided is: {strInput}");



            string strData = "mohammad jamil ahmad";
            //Console.WriteLine(strData.Length);

            // remove left side spaces, AND update the original variable with the trimmed daa.
            strData = strData.TrimStart();
            // remove right side spaces
            strData = strData.TrimEnd();
            Console.WriteLine("Use TrimStart and test");
            Console.WriteLine(strData);

            //print out the text's length
            Console.WriteLine(strData.Length);

            //Lets find some data in the text. The first line only prints out the LOCATION of the first space.
            Console.WriteLine(strData.IndexOf(" "));
            // Here we store the location of the first S in the string in an integer.
            int intIndexOfM = strData.IndexOf("S");

            //Print out strData all upper then all lower
            Console.WriteLine(strData.ToLower());
            Console.WriteLine(strData.ToUpper());

            //From strData, printout 4 characters after the zeroth character.
            Console.WriteLine(strData.Substring(0, 4));
            Console.WriteLine($"Original name is {strData}");

            // store the location of the FIRST space in an integer 
            int intFirstSpace = strData.IndexOf(' ');

            // store the location of the LAST space in an integer 
            int intLastSpace = strData.LastIndexOf(' ');

            //We need to know the LENGTH of middle name name by subtracting the location of the first space from the locaiton of the last space.

            int intLengthOfMidName = intLastSpace - intFirstSpace;
            Console.WriteLine($"firs space is at location {intFirstSpace} and last space is at locaiton {intLastSpace}");
            // Print out everything between locaiton 0 and location intFirstSpace which has the locaiton of the first space.
            Console.WriteLine($"The first name is {strData.Substring(0, intFirstSpace)}");
            Console.WriteLine($"The middle name is {strData.Substring(intFirstSpace, intLengthOfMidName)}");

            Console.WriteLine($"The last name is {strData.Substring(intLastSpace)}");

            //se whether i can make first char in first name upper case
            String strFirstName = strData.Substring(0, intFirstSpace);
            Console.WriteLine(strFirstName);
            char chrMid = 'A';
            char chrLast = 'B';

            //Combining multiple strings and characters in one string.
            String strBoth = String.Concat(chrMid, chrLast, "yeeeeeeha");
            Console.WriteLine(strBoth);


        }
    }
}

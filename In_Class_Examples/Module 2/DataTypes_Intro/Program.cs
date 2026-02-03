/*
 * Mohammad Jamil Ahmad
 * MIST352
 * Thursday 1/22/26
 * More about data types
 */
namespace DataTypes_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, We will be collecting info. from you, student");
            // read, store, and print name
            Console.WriteLine("Whats is your full name?");

            String strName = "Sarah Mike Conor";
         

            //Console.WriteLine(strName.Length);
            //Console.WriteLine(strName.ToLower());
            //Console.WriteLine(strName.ToUpper());
            //Console.WriteLine((strName.ToLower()).Contains("Ahmad".ToLower()));
            //Console.WriteLine(strName);
            //Console.WriteLine(strName.IndexOf('a'));
            //Console.WriteLine(strName.LastIndexOf('a'));
            
            int intFirstSpace = strName.IndexOf(' ');
            int intLastSpace = strName.LastIndexOf(' ');
            Console.WriteLine(intFirstSpace);
            Console.WriteLine(intLastSpace);
            Console.WriteLine(strName.Substring(intFirstSpace, intLastSpace));










            /*//initlize ID
            int intID = 101;
            
            // read and store DOB
            Console.WriteLine("Whats is your DOB?");
            var dateTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(dateTime);


            //read and store salaru
            Console.WriteLine("Whats is your salary?");
            double dblSalary = Double.Parse(Console.ReadLine());

            char chrMidInitial = 'e';

            bool blnActive = true;*/






        }
    }
}

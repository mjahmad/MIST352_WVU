namespace BasicTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intAge = 42;

            string strName = "Sarah,Mike Conor";
            string strSplittedName = strName.Split(',')[1];
            Console.WriteLine(strSplittedName.Split(' ')[0]);


            //Console.WriteLine(blnLetterExsist);
            ////find the location of the first space. location has index, starts with 0.
            //int intFirstSpace = strName.IndexOf(" ");
            //Console.WriteLine(intFirstSpace);
            //int intLastSpace = strName.LastIndexOf(" ");
            //Console.WriteLine(intLastSpace);
            //int intMidNameLength = intLastSpace - intFirstSpace;
            //Console.WriteLine(strName.Substring(intFirstSpace+1, intMidNameLength));
            //Console.WriteLine(strName.Split(',')[0]);
            //Console.WriteLine(strName.Split(',')[1]);
            //Console.WriteLine(strName.Split(',')[2]);


        }
    }
}

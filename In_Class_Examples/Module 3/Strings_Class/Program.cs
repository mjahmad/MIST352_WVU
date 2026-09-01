namespace Strings_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string strCompany = "The company cocacoal sell coca cola. WVU .. morgantownwvw . 009988877.";
            //// Only print in upper case. Original value remains the same.
            //Console.WriteLine(strCompany.ToUpper());

            ////Change the company name make it all upper case.

            //strCompany = strCompany.ToUpper();
            //Console.WriteLine(strCompany);
            ////We need to find the company name and store in a new variable.
            //int intLocation = strCompany.IndexOf(' ');
            //string strPartialData = strCompany.Substring(intLocation+1, 7);
            //Console.WriteLine(strPartialData);
            //string strTempData = strCompany.Replace(strPartialData,"");
            //Console.WriteLine(strTempData);
            //int intLocation2 = strTempData.IndexOf(" ")+1;
            //Console.WriteLine(intLocation2);
            ////delete the first 5 chars fro the string.
            //strTempData = strTempData.Replace((strTempData.Substring(0, 5)), "");
            //Console.WriteLine(strTempData);
            ////Print everything between char 0 and locaiton of first space.
            //string strFinalCompanyName = strTempData.Substring(0,strTempData.IndexOf(' '));
            //Console.WriteLine(strFinalCompanyName);
            /*  string strData = "MJ  MIS                  Morgantown 555-55-5555";
              //Split the data using , by creating an array. Each element of the array will have one word between any given two ,
              string[] strSplittedData = strData.Split(' ');
              Console.WriteLine(strSplittedData[0]);
              Console.WriteLine(strSplittedData[3].Trim() + "++++");*/
            string mixAccount = "mahmad2@mix.wvu.edu";
            //extract user name
            int intLocation = mixAccount.IndexOf('@');
            Console.WriteLine(intLocation);
            string strUserName = mixAccount.Substring(intLocation+1, 11);
            Console.WriteLine(strUserName);
            int intLength = mixAccount.Length;
            string strUniversity = mixAccount.Substring(intLocation+1, mixAccount.Length - (intLocation+1));




        }
    }
}

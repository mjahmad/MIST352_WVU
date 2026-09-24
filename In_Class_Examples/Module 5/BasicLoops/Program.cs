
    internal class Program
{
    static void Main(string[] args)
    {
        string strTxt = "Neo || Hi || Wakeup || 7:46 ";

        string[] strSplittedMsg = strTxt.Split("||");

        string[] strProducts = { "Laptop", "Monitor","Mpuse","Keyboard"};
        string[] strCat = { "Laptop", "Monitor", "Mpuse", "Keyboard" };
        int[] strProductsqty = {22,33,55,77};
        double [] price = { 1.9,9.99,8.9,8 };

        //print everythingin the array, one line at a time.
        for (int intIndex=0; intIndex < strProducts.Length;intIndex++)
        {

            Console.WriteLine(strProducts[intIndex]);   
        }

        //pprintout all even (OrderedParallelQuery odd or what)
        //for (int intIndex = 200; intIndex >= 1; intIndex--) 
        //{
        //    //Check whther th enumber if even or not
        //    if (intIndex % 2 == 0 && intIndex %3 ==0 && intIndex % 5 !=0)
        //    {
        //        Console.WriteLine(intIndex);

        //    }
        //}






        //for loop to prinout somthitng 5 times.


        //for (int intIndex = 20; intIndex >0; intIndex--)
        //{
        //    Console.WriteLine($" {intIndex}");

        //}
        ////printout all even number sbetween 1-100.
        //for (int intIndex = 1; intIndex <= 100; intIndex++)
        //{
        //    if (intIndex%2 == 0 )
        //            {
        //        Console.WriteLine(intIndex);
        //            }
        // }

        //string strText = "Hello Neo || Good morning || Wakeup || 7:45AM ||Hello Neo || Good morning || Wakeup || 7:45AM||Hello Neo || Good morning || Wakeup || 7:45AM||Hello Neo || Good morning || Wakeup || 7:45AM||Hello Neo || Good morning || Wakeup || 7:45AM||Hello Neo || Good morning || Wakeup || 7:45AM||Hello Neo || Good morning || Wakeup || 7:45AM||Hello Neo || Good morning || Wakeup || 7:45AM||Hello Neo || Good morning || Wakeup || 7:45AM||Hello Neo || Good morning || Wakeup || 7:45AM||Hello Neo || Good morning || Wakeup || 7:45AM";
        //string[] strSplittedText = strText.Split("||");
        //for (int intIndex = 0; intIndex < strSplittedText.Length; intIndex++)
        //{
        //    Console.WriteLine($"{strSplittedText[intIndex]}");

        //}
        ////create an array of 4 products names
        //string[] strProductsNames = {"Laptop","Monitor","iPad","Others" };
        //double[] dblProductsPrices = { 1,2,3,4.99 };
        //int[] intProductsQtys = {22,33,44,5};
        //string[] strProductsCategories = { "IT","IT","IT","Others" };

        //for (int intIndex = 0; intIndex <= strProductsNames.Length; intIndex++)
        //{
        //    Console.WriteLine($"{strProductsNames[intIndex]}  {dblProductsPrices[intIndex]}  {intProductsQtys[intIndex]}");
        //}






        //inout1

    }
}


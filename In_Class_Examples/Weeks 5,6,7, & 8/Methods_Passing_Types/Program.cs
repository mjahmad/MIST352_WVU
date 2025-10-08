namespace Methods_Passing_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intFirstVal = 1, intScondVal = 2, intThirdVal;

            //Console.WriteLine($"Before method: {intFirstVal}\t {intScondVal}");
            //Multiply(intFirstVal, intScondVal);
            //Console.WriteLine(Multiply2(intFirstVal,intScondVal));
            //MultiplyByReference(ref intFirstVal, ref intScondVal);
            //Console.WriteLine($"after method: {intFirstVal}\t {intScondVal}");

            //int[] intNumbers = { 10, 20, 30, 40 };
            //PrintArray(intNumbers);
            //Console.WriteLine(intNumbers[0]);
            //Console.WriteLine($"Before ecalling the method {intFirstVal}\t{intScondVal}");

            //SumValues(ref intFirstVal, ref intScondVal, out intThirdVal);
            //Console.WriteLine($"After ecalling the method {intFirstVal}\t{intScondVal}\t{intThirdVal}");
            String strUserEmail;
            AcceptAndVerifyEmail(out strUserEmail);
            Console.WriteLine(strUserEmail);



        }


        static void AcceptAndVerifyEmail(out String strTheEamil)
        {

            bool blnValidEmail = true;
            strTheEamil = "";
            while (blnValidEmail)

            {
                Console.WriteLine("What is your email?");
                strTheEamil = Console.ReadLine();
                if (strTheEamil.Contains("@") && strTheEamil.Contains("."))
                {
                    break;

                }
                else

                {
                    Console.WriteLine("Wrong email - provide it again");
                    //strTheEamil = Console.ReadLine();


                }



            }



        }

        static void SumValues(ref int Val1, ref int Val2, out int Val3)
        {
            Val3 = 10;

            Console.WriteLine(Val1 + Val2 + Val3);

            Val1 = Val2 = Val3 = 0;

        }


        static void PrintArray(int[] intData)
        {
            intData[0] = 100;
            for (int intIndex = 0; intIndex < intData.Length; intIndex++)
                Console.WriteLine(intData[intIndex]);

        }

        static void MultiplyByReference(ref int Val1, ref int Val2)
        {
            Val1 = 20;
            Console.WriteLine(Val1 * Val2);
            Val2 = 90;

        }

        //static void Multiply(int Val1, int Val2)
        //{
        //    Val1 = 20;
        //    Console.WriteLine(Val1 * Val2);
        //}


        //static int Multiply2(int Val1, int Val2)
        //{
        //    Val1 = 20;
        //    return Val1 * Val2;
        //}


    }
}


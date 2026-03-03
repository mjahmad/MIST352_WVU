namespace While_Loops_Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*for (int intIndex = 1; intIndex <=10; intIndex++)
            {
                //Console.WriteLine($"{intIndex} Loop 1 : ");
                Console.WriteLine();
                for (int intIndex2 = intIndex; intIndex2 <= 10; intIndex2++)
                {
                    Console.Write($" {intIndex2}");
                    //Console.Wri

                }
            }*/
            //Console.WriteLine("For loop");
            //for (int intIndex = 1; intIndex <= 5; intIndex++)
            //{
            //    Console.WriteLine(intIndex);
            //}
            ////Console.WriteLine(intIndex);


            //Console.WriteLine("While loop");

            //int intWhileIndex = 1;
            //while (intWhileIndex <= 5)
            //{
            //    Console.WriteLine(intWhileIndex);
            //    intWhileIndex++;

            //}
            //Console.WriteLine(intWhileIndex);

            // Keep asking user for a passwrod. (abc). I fnot provided, keep asking them.
            //Console.WriteLine("Give me the password");
            //string strPassword = Console.ReadLine();

            //while (!strPassword.Equals("abc"))
            //{
            //    Console.WriteLine("Wrong passwrod. Try again");
            //    strPassword = Console.ReadLine();
            //}
            //Console.WriteLine("Corectt passwrod. Acces Granted");


            //
            Console.WriteLine($"0. Exit. \n 1. Displaty Info.\n 2. Calcualte Total \n 3. Appky Discount. \n 4. Print All");

            int intChoice = int.Parse(Console.ReadLine());
            while (intChoice != 0)
            {
                switch (intChoice)
                {
                    case 1:
                        Console.WriteLine("Displaying Infor......");
                        break;
                    case 2:
                        Console.WriteLine("Calculating Total......");
                        break;
                    case 3:
                        Console.WriteLine("Apply Discount.....");
                        break;
                    case 4:
                        Console.WriteLine("Print All......");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        Console.WriteLine($"0. Exit. \n 1. Displaty Info.\n 2. Calcualte Total \n 3. Appky Discount. \n 4. Print All");
                        //intChoice = int.Parse(Console.ReadLine());
                        break;
                }
                Console.WriteLine($"0. Exit. \n 1. Displaty Info.\n 2. Calcualte Total \n 3. Appky Discount. \n 4. Print All");
                intChoice = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("Good Bye");

        }
    }
}

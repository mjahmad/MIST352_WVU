using System;

namespace WhileLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //print hello world 10 times using for loop
            //for (int intIndex = 1; intIndex <=5; intIndex++)
            //{
            //    Console.WriteLine("Hello, World!");
            //}


            //int intIndexW = 1;
            //while (intIndexW <= 5)
            //{
            //    Console.WriteLine(" -- while --Hello, World!");
            //    intIndexW--;

            //}
            //====Keep asking user for their name. if its admin, let them through
            //if not, keep asking for their name
            //Console.WriteLine("What is 3+8");
            //int intInput = int.Parse(Console.ReadLine());
            Console.WriteLine("give me your user name");
            

            string strName = Console.ReadLine().ToLower();
            int intIndexJack = 0;
            //username =>user && pass
                    
                while (strName != "admin".ToLower() && intIndexJack<=3)
               
            {
                Console.WriteLine($"Index is {intIndexJack}");
                Console.WriteLine("Wrong Anwere.");
                Console.WriteLine("give me your user name");
                strName = Console.ReadLine().ToLower();
                intIndexJack++;

            }

            //Console.WriteLine("thank you, Admin");


        }
    }
}

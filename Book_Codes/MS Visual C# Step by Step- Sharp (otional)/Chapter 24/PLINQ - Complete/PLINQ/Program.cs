using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PLINQ
{
    class Program
    {
        public const int NUM = int.MaxValue / 1000;

        static void Main(string[] args)
        {
            // Test1();
            Test2();
        }

        public static void Test1()
        {
            Console.WriteLine("\nTest 1");

            int[] numbers = new int[NUM];
            Random random = new Random(999);

            for (int i = 0; i < NUM; i++)
            {
                numbers[i] = random.Next(200);
            }

            var over100 = from n in numbers.AsParallel()
                          where TestIfTrue(n > 100)
                          select n;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            List<int> numbersOver100 = new List<int>(over100);
            timer.Stop();
            long milliseconds = timer.ElapsedMilliseconds;

            Console.WriteLine($"There are {numbersOver100.Count} numbers over 100");
            Console.WriteLine($"Time taken was {milliseconds} ms");
        }

        public static bool TestIfTrue(bool expr)
        {
            Thread.SpinWait(100);
            return expr;
        }

        public static void Test2()
        {
            Console.WriteLine("\nTest 2");

            try
            {
                // Create a LINQ query that retrieves customers and orders from arrays
                // Store each row returned in an OrderInfo object
                var orderInfoQuery =
                    from c in CustomersInMemory.Customers.AsParallel()
                    join o in OrdersInMemory.Orders.AsParallel()
                    on c.Split(',')[0] equals o.Split(',')[1]
                    where Convert.ToDateTime(o.Split(',')[2], new CultureInfo("en-US"))
                        >= new DateTime(1997, 1, 1)
                        && Convert.ToDateTime(o.Split(',')[2], new CultureInfo("en-US"))
                        < new DateTime(1998, 1, 1)
                    select new OrderInfo
                    {
                        CustomerID = c.Split(',')[0],
                        CompanyName = c.Split(',')[1],
                        OrderID = Convert.ToInt32(o.Split(',')[0]),
                        OrderDate = Convert.ToDateTime(o.Split(',')[2],
                             new CultureInfo("en-US"))
                    };

                Stopwatch timer = new Stopwatch();
                timer.Start();

                // Run the LINQ query and save the results in a List<OrderInfo> object
                List<OrderInfo> orderInfo = new List<OrderInfo>(orderInfoQuery); ;

                
                timer.Stop();
                long milliseconds = timer.ElapsedMilliseconds;

                // Display the results
                Console.WriteLine($"There are {orderInfo.Count} orders");

                Console.WriteLine($"Time taken for joining two arrays in memory: {milliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}

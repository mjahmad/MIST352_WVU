using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Program
    {
        private const int NUMELEMENTS = 10;

        static void Main(string[] args)
        {
            SerialTest();
            //ParallelTest();
        }

        static void SerialTest()
        {
            int[] data = new int[NUMELEMENTS];
            int j = 0;

            for (int i = 0; i < NUMELEMENTS; i++)
            {
                j = i;
                doAdditionalProcessing();
                data[i] = j;
                doMoreAdditionalProcessing();
            }

            for (int i = 0; i < NUMELEMENTS; i++)
            {
                Console.WriteLine($"Element {i} has value {data[i]}");
            }
        }

        static void ParallelTest()
        {
            int[] data = new int[NUMELEMENTS];
            int j = 0;

            Parallel.For(0, NUMELEMENTS, (i) =>
            {
                j = i;
                doAdditionalProcessing();
                data[i] = j;
                doMoreAdditionalProcessing();
            });

            for (int i = 0; i < NUMELEMENTS; i++)
            {
                Console.WriteLine($"Element {i} has value {data[i]}");
            }
        }

        static void doAdditionalProcessing()
        {
            Thread.Sleep(10);
        }

        static void doMoreAdditionalProcessing()
        {
            Thread.Sleep(10);
        }
    }
}

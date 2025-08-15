using System;

namespace GarbageCollection
{
    class Program
    {
        static void doWork()
        {
            // TODO: Test garbage collection
        }

        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

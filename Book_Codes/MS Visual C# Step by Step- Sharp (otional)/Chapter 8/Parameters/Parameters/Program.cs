using System;

namespace Parameters
{
    class Program
    {
        static void doWork()
        {
            // TODO: Test value and reference types
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

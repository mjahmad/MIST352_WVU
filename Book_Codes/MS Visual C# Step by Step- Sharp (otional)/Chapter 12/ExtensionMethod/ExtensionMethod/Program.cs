using System;

namespace ExtensionMethod
{
    class Program
    {
        static void doWork()
        {
            // TODO:		
        }

        static void Main()
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}

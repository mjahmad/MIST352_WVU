using System;

namespace StructsAndEnums
{
    class Program
    {
        static void doWork()
        {
            // Month first = Month.December;
            // Console.WriteLine(first);
            // first++;
            // Console.WriteLine(first);

            // var defaultDate = new Date();
            // Console.WriteLine(defaultDate);

            Date weddingAnniversary = new Date(2021, Month.July, 4);
            Console.WriteLine(weddingAnniversary);

            Date weddingAnniversaryCopy = weddingAnniversary;
            Console.WriteLine($"Value of copy is {weddingAnniversaryCopy}");

            weddingAnniversary.AdvanceMonth();
            Console.WriteLine($"New value of weddingAnniversary is {weddingAnniversary}");
            Console.WriteLine($"Value of copy is still {weddingAnniversaryCopy}");
        }

        static void Main()
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

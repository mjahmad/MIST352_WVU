namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chrA = { 'x', 'y', 'z' };
            for (int intIndex = chrA.Length - 1; intIndex >= 0; --intIndex)
            {
                if (chrA[intIndex] != 'y')
                {
                    Console.Write(chrA[intIndex]);
                }
            }



        }
    }
}

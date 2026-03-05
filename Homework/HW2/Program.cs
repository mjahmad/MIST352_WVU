namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] students = File.ReadAllLines("data.txt");
            if (File.Exists("data.txt"))
                Console.WriteLine("Data read successfully.");


        }
    }
}

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Product p1 = new Product("cpu",499);
            p1.SetName("");
            Console.WriteLine(p1.GetName());

        }
    }
}

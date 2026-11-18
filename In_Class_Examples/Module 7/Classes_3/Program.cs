namespace Classes_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Shape pen = new Shape("cat");
            Rectangle pen = new(10,10);
            Console.WriteLine(pen.Name);

        }
    }
}

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            Owner mj = new Owner();
            mj.DisplayInfo();

            Owner sarah = new Owner("Sarah Conor","555-55-5555");
            sarah.DisplayInfo();
            Console.WriteLine(sarah.BuildContactCard());

            Pet fluffkinz = new Pet();
            fluffkinz.DisplayInfo();


        }
    }
}

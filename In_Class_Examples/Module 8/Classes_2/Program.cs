namespace Classes_2
{
    //https://ecampus.wvu.edu/ultra/courses/_247536_1/outline/edit/document/_554636660_1?courseId=_247536_1&view=content&state=view
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Creating a product using the first constructor (no info)
            Product product1 =  new Product();
            //Console.WriteLine($"{product1.Id}, {product1.Name}," +
            //    $"{product1.Price}, {product1._category}");
            product1.DisplayInfo();


            //Creating a product using the second constructor (given ID and Name)

            Product product2 = new Product(101,"Monitor");
            product2.DisplayInfo();

            //Console.WriteLine($"{product2.Id}, {product2.Name}," +
            //    $"{product2.Price}, {product2._category}");

            Product product3 = new Product(201,"Laptop",299.99, "IT");
            product3.DisplayInfo();

            //Console.WriteLine($"{product3.Id}, {product3.Name}," +
            // $"{product3.Price}, {product3._category}");

            //product1.Id = 100;
            //product1.Name = "Keyboard";
            //product1.Price = 20.5;
            //product1._category = "IT";
        }
    }
}

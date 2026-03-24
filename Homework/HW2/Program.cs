namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] students = File.ReadAllLines("data.txt");
            if (File.Exists("data.txt"))
                Console.WriteLine("Data read successfully.");
            Console.WriteLine("Menue\n A) Print\n B) Count\n C) Avg\n D) Highest GPA\n X) Exit.");

            char chrChoice = Console.ReadLine()[0];

            while (!chrChoice.Equals('X'))
            {
                switch (chrChoice)
                {
                    case 'A':
                        for (int i = 0; i < students.Length; i++)
                        {
                            Console.WriteLine($"{students[i]}");
                        }
                        break;
                    case 'B':
                        for (int i = 0; i < students.Length; i++)
                        {
                            string[] data = students[i].Split(',');
                            
                            Console.WriteLine($"{data[2]}");
                        }

                        break;
                    case 'C':
                        break;
                    case 'D':
                        break;
                    case 'X':
                        break;

                    default:
                        Console.WriteLine("Invalid");

                        break;
                }
                Console.WriteLine("Menue\n A) Print\n B) Count\n C) Avg\n D) Highest GPA\n X) Exit.");

                chrChoice = Console.ReadLine()[0];

            }



        }
    }
}

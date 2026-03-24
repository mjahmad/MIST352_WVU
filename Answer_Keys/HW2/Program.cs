namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] students = File.ReadAllLines("data.txt");
            if (File.Exists("data.txt"))
                Console.WriteLine("Data read successfully.");

            // Now you have an array of strings named students[]. Your code goes here. Go crazy.
            Console.WriteLine("\nMENU");
            Console.WriteLine("Select option: ");
            Console.WriteLine("A - Print Student Table");
            Console.WriteLine("B - Count Students by Letter Grade");
            Console.WriteLine("C - Show Average GPA");
            Console.WriteLine("D - Show Highest GPA Student");
            Console.WriteLine("X - Exit\n\n");
            char choice = Console.ReadLine()[0];
            while (choice != 'X')
            {

                switch (choice)
                {
                    case 'A':
                        PrintStudents(students);
                        Console.WriteLine();
                        break;

                    case 'B':
                        PrintGradeCounts(students);
                        Console.WriteLine();

                        break;

                    case 'C':
                        PrintAverageGPA(students);
                        Console.WriteLine();

                        break;

                    case 'D':
                        PrintTopStudent(students);
                        Console.WriteLine();

                        break;

                    case 'X':
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option.\n==========================================");

                        Console.WriteLine("\nMENU");
                        Console.WriteLine("Select option: ");
                        Console.WriteLine("A - Print Student Table");
                        Console.WriteLine("B - Count Students by Letter Grade");
                        Console.WriteLine("C - Show Average GPA");
                        Console.WriteLine("D - Show Highest GPA Student");
                        Console.WriteLine("X - Exit\n\n");
                        break;
                }
                choice = Console.ReadLine()[0];

            }
            Console.WriteLine("Good Bye!");

        }

        // Method A — Print Student Table
        public static void PrintStudents(string[] students)
        {
            Console.WriteLine("\nID\tName\t\tGPA");
            Console.WriteLine("--------------------------------");

            foreach (string s in students)
            {
                string[] parts = s.Split(',');
                Console.WriteLine($"{parts[0]}\t{parts[1]}\t{parts[2]}");
            }
        }

        // Method B — Count Students by Letter Grade
        public static void PrintGradeCounts(string[] students)
        {
            int a = 0, b = 0, c = 0, d = 0;

            foreach (string s in students)
            {
                string[] parts = s.Split(',');
                double gpa = Convert.ToDouble(parts[2]);

                if (gpa >= 3.7)
                    a++;
                else if (gpa >= 3.0)
                    b++;
                else if (gpa >= 2.0)
                    c++;
                else
                    d++;
            }

            Console.WriteLine("\nGrade Counts");
            Console.WriteLine($"A: {a}");
            Console.WriteLine($"B: {b}");
            Console.WriteLine($"C: {c}");
            Console.WriteLine($"D: {d}");
        }

        // Method C — Print Average GPA
        public static void PrintAverageGPA(string[] students)
        {
            double total = 0;

            foreach (string s in students)
            {
                string[] parts = s.Split(',');
                total += Convert.ToDouble(parts[2]);
            }

            double avg = total / students.Length;

            Console.WriteLine($"\nAverage GPA: {avg:F2}");
        }

        // Method D — Find Student with Highest GPA
        public static void PrintTopStudent(string[] students)
        {
            double highest = 0;
            string name = "";

            foreach (string s in students)
            {
                string[] parts = s.Split(',');
                double gpa = Convert.ToDouble(parts[2]);

                if (gpa > highest)
                {
                    highest = gpa;
                    name = parts[1];
                }
            }

            Console.WriteLine($"\nTop Student: {name} with GPA {highest}");
        }


    }
}

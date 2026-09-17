
    internal class Program
    {
        static void Main(string[] args)
        {
        //Evaluaete somebody's GPA = > Offer gift card
        //A -->$50
        //B -->$40
        //C --> $30
        //D --> $20
        //F --> 0
        //invalid GPA
        Console.WriteLine("Whats ir yourGPA");
        char chrUserGPA = Console.ReadKey().KeyChar; //X
        Console.WriteLine();
        //if (chrUserGPA == 'A')
        //    Console.WriteLine("$50");
        //else if (chrUserGPA == 'B')
        //    Console.WriteLine("$40");
        //else if (chrUserGPA == 'C')
        //    Console.WriteLine("$30");
        //else if (chrUserGPA == 'D')
        //    Console.WriteLine("$20");
        //else if (chrUserGPA == 'F')
        //    Console.WriteLine("$0");
        //else
        //    Console.WriteLine("Invalid GPA");

        //Using Switch to replace IF

        switch (chrUserGPA)
        {
            case 'A':
                Console.WriteLine("$50");
                Console.WriteLine("Good job");
                break;
            case 'B':
                Console.WriteLine("$40");
                break;
            case 'C':
                Console.WriteLine("$30");
                break;
            case 'D':
                Console.WriteLine("$20");
                break;
            case 'F':
                Console.WriteLine("$0");
                break;
            default:
                Console.WriteLine("Invdali GPA");
                break;
        }





    }
}


using System.ComponentModel.Design;

namespace Classes_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What si yoiur SSN?");
            
        
            string userSSN = Console.ReadLine();

           

                        STUDENT st1 = new STUDENT(userSSN);
            st1.theFirstName = "Sarah";
            st1.theLastName = "Conor";



           //STUDENT st2 = new STUDENT("", "");
           // STUDENT str3 = new STUDENT("Ripley","Smith","998-009-22",90.9,101222);

        }
    }
}

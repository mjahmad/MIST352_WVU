// Mohammad Jamil Ahmad
// MIST352 
// 
// 


namespace PayrollApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. This prpogram calcualtes your total payroll, given hours and hourly rate");
            Console.WriteLine("How many hours did you work this week?");

            
            //declare a numerical variable.
            double noOfHours;
            //REad data from user
            noOfHours  = Convert.ToDouble(Console.ReadLine());
            //print out tht hours.
            //Console.WriteLine(noOfHours);

            Console.WriteLine("What is your hourly rate?");
            //declare a numerical variable.
            double hourlyRate;
            hourlyRate = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine(hourlyRate);

            //do the math.
            double totalPay = noOfHours * hourlyRate;

            Console.WriteLine($"Given that you have worked {noOfHours} hours last week and ${hourlyRate} hourly rate, the total pay is ${totalPay}");

        }
    }
}

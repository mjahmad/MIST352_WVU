/**
 * This class uses overloaded methods to return an employee's 
 * weekly salary.
 */

public class Pay
{
   /**
    * The following method calculates the gross weekly pay of  
    * an hourly paid employee. The parameter hours holds the   
    * number of hours worked. The parameter payRate holds the  
    * hourly pay rate. The method returns the weekly salary.
    */

   public static double getWeeklyPay(int hours, double payRate)
   {
      return hours * payRate;
   }

   /**
    * The following method overloads the getWeeklyPay method.  
    * It calculates the gross weekly pay of a salaried         
    * employee. The parameter holds the employee's yearly      
    * salary. The method returns the weekly salary.
    */

   public static double getWeeklyPay(double yearlySalary)
   {
      return yearlySalary / 52;
   }
}

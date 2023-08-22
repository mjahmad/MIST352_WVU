/**
 * This class holds values for hours worked and the
 * hourly pay rate. It calculates the gross pay and
 * adds additional pay for overtime.
 */

public class Payroll
{
   private double hoursWorked; // Number of hours worked
   private double payRate;     // The hourly pay rate

   /**
    * The constructor initializes the hoursWorked and
    * payRate fields to 0.0. 
    */
   
   public Payroll()
   {
      hoursWorked = 0.0;
      payRate = 0.0;
   }
   
   /**
    * The setHoursWorked method accepts an argument
    * that is stored in the hoursWorked field.
    */

   public void setHoursWorked(double hours)
   {
      hoursWorked = hours;
   }

   /**
    * The setPayRate method accepts an argument which
    * is stored in the payRate field.
    */

   public void setPayRate(double rate)
   {
      payRate = rate;
   }

   /**
    * The getHoursWorked method returns the hoursWorked
    * field.
    */

   public double getHoursWorked()
   {
      return hoursWorked;
   }

   /**
    * The getPayRate method returns the payRate field.
    */

   public double getPayRate()
   {
      return payRate;
   }

   /**
    * The getGrossPay method calculates and returns the
    * gross pay. Overtime pay is also included.
    */

   public double getGrossPay()
   {
      double grossPay,     // Holds the gross pay
             overtimePay;  // Holds pay for overtime

      // Determine whether the employee worked more
      // than 40 hours.
      if (hoursWorked > 40)
      {
         // Calculate regular pay for the first 40 hours.
         grossPay = 40 * payRate;
         
         // Calculate overtime pay at 1.5 times the regular
         // hourly pay rate.
         overtimePay = (hoursWorked - 40) * (payRate * 1.5);
         
         // Add the overtime pay to the regular pay.
         grossPay += overtimePay;
      }
      else
      {
         // No overtime worked. 
         grossPay = payRate * hoursWorked;
      }

      return grossPay;
   }
}


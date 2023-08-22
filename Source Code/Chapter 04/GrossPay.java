import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program uses the Payroll class to
 * calculate an employee's gross pay.
 */

public class GrossPay
{
   public static void main(String[] args)
   {
      double hours,  // To hold hours worked
             rate;   // To hold the hourly pay rate

      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);
      
      // Create a Payroll object.
      Payroll employee = new Payroll();

      // Get the number of hours worked.
      System.out.print("How many hours did the " +
                       "employee work? ");
      hours = keyboard.nextDouble();

      // Get the hourly pay rate.
      System.out.print("What is the employee's " +
                       "hourly pay rate? ");
      rate = keyboard.nextDouble();

      // Store the data.
      employee.setHoursWorked(hours);
      employee.setPayRate(rate);

      // Display the gross pay.
      System.out.println("The employee's gross pay " +
                         "is $" + employee.getGrossPay());
      }
}

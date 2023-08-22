import java.util.Scanner;

/**
 * This program stores in an array the hours worked by
 * five employees who all make the same hourly wage.
 */

public class PayArray
{
   public static void main(String[] args)
   {
      final int NUM_EMPLOYEES = 5; // Number of employees
      double payRate,              // Hourly pay rate
             grossPay;             // Gross pay
      
      // Create an array for employee hours.
      int[] hours = new int[NUM_EMPLOYEES];
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      System.out.println("Enter the hours worked by " +
                         NUM_EMPLOYEES + " employees who " +
                         "all earn the same hourly rate.");

      // Get each employee's hours worked.
      for (int index = 0; index < NUM_EMPLOYEES; index++)
      {
         System.out.print( "Employee #" + (index + 1) + ": ");
         hours[index] = keyboard.nextInt();
      }

      // Get the hourly pay rate.
      System.out.print("Enter each employee's hourly rate: ");
      payRate = keyboard.nextDouble();
      
      // Display each employee's gross pay.
      System.out.println( "Gross pay for each employee:");
      for (int index = 0; index < NUM_EMPLOYEES; index++)
      {
         grossPay = hours[index] * payRate;
         System.out.printf("Employee #%d: $%,.2f\n", 
                           (index + 1), grossPay);
      }
   }
}

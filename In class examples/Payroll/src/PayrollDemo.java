import java.util.Scanner;
import java.text.DecimalFormat;

/**
 * Chapter 7
 * Programming Challenge 2: Payroll Class
 * This program demonstrates the Payroll class.
 */

public class PayrollDemo
{
   public static void main(String[] args)
   {
      int hours;        // Hours worked
      double payRate;   // Hourly pay rate

      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Create a Payroll object named pr

      
      // Get the hours and pay rate for each employee.
      for (int i = 0; i < pr.NUM_EMPLOYEES; i++)
      {
         // Get the hours worked.
         System.out.print("Enter the hours worked by employee " +
                          "number " + pr.getEmployeeIdAt(i) +
                          ": ");
         hours = keyboard.nextInt();
         
         // Validate hours worked using while hours < 0
       
         
         // Get the hourly pay rate from user

         
         // Validate pay rate using a while payRate < 6
      
         
         // Store the data in the pr object.

      }
      
      // Create a DecimalFormat object to format output.
      DecimalFormat dollar = new DecimalFormat("#,##0.00");
      
      // Display the payroll data for each employee using a for loop 
    
   }
}

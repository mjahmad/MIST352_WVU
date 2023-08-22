import java.util.Scanner;
import java.text.DecimalFormat;

/**
 * This program demonstrates parallel arrays.
 */

public class ParallelArrays
{
   public static void main(String [] args)
   {
      final int NUM_EMPLOYEES = 3;
      int[] hours = new int[NUM_EMPLOYEES];
      double[] payRates = new double[NUM_EMPLOYEES];

      // Get the hours worked by each employee.
      getPayData(hours, payRates);

      // Display each employee's gross pay.
      displayGrossPay(hours, payRates);
   }

	/**
	 * The getPayData method accepts as arguments arrays   
     * for employees' hours and pay rates. The user enters 
     * values for these arrays.
	 */

   private static void getPayData(int[] hours, double[] payRates)
   {
		// Create a Scanner object for keyboard input.
		Scanner keyboard = new Scanner(System.in);
		
		// Get each employee's hours worked and pay rate.
      for (int i = 0; i < hours.length; i++)
      {
         // Get the hours worked for an this employee.
         System.out.print("Enter the hours worked by " +
                          "employee #" + (i + 1) +
                          ": ");
         hours[i] = keyboard.nextInt();

         // Get the hourly pay rate for this employee.
         System.out.print("Enter the hourly pay rate for " +
                          "employee #" + (i + 1) +
                          ": ");
         payRates[i] = keyboard.nextDouble();
      }
   }

	/**
	 * The displayGrossPay method accepts as arguments    
     * arrays for employees' hours and pay rates. The     
     * method uses these arrays to calculate and display  
     * each employee's gross pay.
	 */

   private static void displayGrossPay(int [] hours,
                                       double [] payRates)
   {
      double grossPay; // To hold gross pay
		
		// Create a DecimalFormat object.
      DecimalFormat dollar = new DecimalFormat("#,##0.00");

		// Display each employee's gross pay.
      for (int i = 0; i < hours.length; i++)
      {
         // Calculate the gross pay.
         grossPay = hours[i] * payRates[i];

         // Display the gross pay.
         System.out.println("The gross pay for " +
                            "employee #" + (i + 1) +
                            " is $" +
                            dollar.format(grossPay));
      }
   }
}

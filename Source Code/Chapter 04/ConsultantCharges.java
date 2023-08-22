import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program demonstrates the conditional operator.
 */

public class ConsultantCharges
{
   public static void main(String [] args)
   {
      double hours,    // To hold the hours worked
             charges;  // To hold the charges

      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);

      // Get the number of hours worked.
      System.out.print("How many hours were worked? ");
      hours = keyboard.nextDouble();

      // Make sure hours is at least 5.
      hours = hours < 5 ? 5 : hours;

      // Calculate and display the charges.
      charges = 50.0 * hours;
      System.out.println("The charges are $" + charges);
   }
}

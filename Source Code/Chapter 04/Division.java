import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program demonstrates the if-else statement.
 */

public class Division
{
   public static void main(String [] args)
   {
      int number1, number2;  // Two numbers
      double quotient;       // The quotient of two numbers

      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);

      // Get two numbers from the user.
      System.out.print("Enter an integer: ");
      number1 = keyboard.nextInt();
      System.out.print("Enter another integer: ");
      number2 = keyboard.nextInt();
      
      // Determine whether division by zero will occur.
      if (number2 == 0)
      {
         // Error - division by zero.
         System.out.println("Division by zero is not possible.");
         System.out.println("Please run the program again and ");
         System.out.println("enter a number other than zero.");
      }
      else
      {
         // Perform the division and display the quotient.
         quotient = (double) number1 / number2;
         System.out.print("The quotient of " + number1);
         System.out.print(" divided by " + number2);
         System.out.println(" is " + quotient);
      }
   }
}

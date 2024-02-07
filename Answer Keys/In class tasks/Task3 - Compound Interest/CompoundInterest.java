import java.util.Scanner;

/**
 * Chapter 2
 * Compound Interest problem
 */
 
public class CompoundInterest
{
   public static void main(String[] args)
   {
      // Variables
      double amount,             // Amount in the account
             principal,          // Principal originally deposited
             rate,               // Annual interest rate
             compounding,        // Number of times interest is compounded per year
             years;              // Number of years interest is compounded
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Get the necessary input.
      System.out.print("What is the original principal? ");
      principal = keyboard.nextDouble();
      System.out.print("What is the annual interest rate? ");
      rate = keyboard.nextDouble();
      System.out.print("How many times per year is interest compounded? ");
      compounding = keyboard.nextDouble();
      System.out.print("For how many years will interest be compounded? ");
      years = keyboard.nextDouble();
      
      // Move the decimal point in the interest rate.
      rate = rate / 100.0;
      
      // Calculate the ending balance.
      amount = principal * Math.pow((1 + rate / compounding), (compounding * years));
      
      // Display the result.
      System.out.printf("After %.0f years you will have $%.2f.\n", years, amount);
   }
}

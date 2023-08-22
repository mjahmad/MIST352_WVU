import java.util.Scanner;

/**
 * This program calculates a running total.
 */

public class TotalSales
{
   public static void main(String[] args)
   {
      int days;          // The number of days
      double sales;      // A day's sales amount
      double totalSales; // Accumulator
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Get the number of days.
      System.out.print("For how many days do you have " +
                       "sales amounts? ");
      days = keyboard.nextInt();

      // Set the accumulator to 0.
      totalSales = 0.0;

      // Get the sales amounts and calculate 
      // a running total.
      for (int count = 1; count <= days; count++)
      {
         System.out.print("Enter the sales for day " +
                          count + ": ");
         sales = keyboard.nextDouble();
         totalSales += sales;   // Add sales to total.
      }

      // Display the total sales.
      System.out.printf("The total sales are $%,.2f\n", totalSales);
   }
}


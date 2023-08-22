import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program demonstrates the logical ! operator.
 */

public class LogicalNot
{
   public static void main(String[] args)
   {
      double income;  // Annual income
      int years;      // Years on the job

      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);

      // Get the annual income.
      System.out.print("What is your annual income? ");
      income = keyboard.nextDouble();
      
      // Get the number of years on the current job.
      System.out.print("For how many years have you "
                       + "worked on your current job? ");
      years = keyboard.nextInt();

      // Determine whether the user qualifies.
      if (!(income >= 35000 || years > 5))
      {
         System.out.println("You must earn at least $35000 "
                         + "or have been employed for more");
         System.out.println("than 5 years to qualify.");
      }    
      else
         System.out.println("You qualify for the loan.");
   }
}

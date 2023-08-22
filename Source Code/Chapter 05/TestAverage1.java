import java.util.Scanner;

/**
 * This program demonstrates a user-controlled loop.
 */

public class TestAverage1
{
   public static void main(String[] args)
   {
      String input;                   // To hold keyboard input
      double score1, score2, score3;  // Three test scores
      double average;                 // Average test score
      char repeat;                    // Holds 'y' or 'n'
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      System.out.println("This program calculates the average " +
                         "of three test scores.");

      do
      {
         // Get the three test scores.
         System.out.print("Enter score #1: ");
         score1 = keyboard.nextDouble();
         System.out.print("Enter score #2: ");
         score2 = keyboard.nextDouble();
         System.out.print("Enter score #3: ");
         score3 = keyboard.nextDouble();

         // Calculate and print the average test score.
         average = (score1 + score2 + score3) / 3.0;
         System.out.println("The average is " + average);
         System.out.println();

         // Does the user want to average another set?
         System.out.println("Would you like to average " +
                            "another set of test scores?");
         System.out.print("Enter Y for yes or N for no: ");
         input = keyboard.next();     // Read a string.
         repeat = input.charAt(0);    // Get the first char.

      } while (repeat == 'Y' || repeat == 'y');
   }
}
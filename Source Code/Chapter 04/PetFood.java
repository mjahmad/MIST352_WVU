import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program demonstrates a switch statement. 
 */

public class PetFood
{
   public static void main(String[] args)
   {
      String input;    // To hold keyboard input
      char feedGrade;  // To hold the feed grade
   
      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);

      // Get the desired pet food grade.
      System.out.println("Our pet food is available in " +
                         "three grades:");
      System.out.print("A, B, and C. Which do you want " +
                       "pricing for? ");
      input = keyboard.nextLine();
      feedGrade = input.charAt(0);  // Get the first char.

      // Determine the grade that was entered.
      switch(feedGrade)
      {
         case 'a':
         case 'A':
            System.out.println("30 cents per lb.");
            break;
         case 'b':
         case 'B':
            System.out.println("20 cents per lb.");
            break;
         case 'c':
         case 'C':
            System.out.println("15 cents per lb.");
            break;
         default:
            System.out.println("Invalid choice.");
      }
   }
}

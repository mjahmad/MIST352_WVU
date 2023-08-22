import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program demonstrates a switch statement
 * without any break statements.  
 */

public class NoBreaks
{
   public static void main(String[] args)
   {
      String input; // To hold keyboard input
      char choice;  // To store the user's choice

      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);

      // Ask the user to enter A, B, or C.
      System.out.print("Enter A, B, or C: ");
      input = keyboard.nextLine();
      choice = input.charAt(0);  // Get the first char
      
      // Determine which character the user entered.
      switch (choice)
      {
         case 'A':
            System.out.println("You entered A.");
         case 'B':
            System.out.println("You entered B.");
         case 'C':
            System.out.println("You entered C.");
         default:
            System.out.println("That's not A, B, or C!");
      }
   }
}

// This program demonstrates how to read a single
// character as input from the keyboard.

import java.util.Scanner;  // Needed for the Scanner class

public class YesNoQuestion
{
   public static void main(String[] args)
   {
      String input;  // To hold a line of input
      char answer;   // To hold a single character
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Ask the user a question.
      System.out.print("Are you having fun? (Y=yes, N=no) ");
      input = keyboard.nextLine();  // Get a line of input.
      answer = input.charAt(0);     // Get the first character.

      // Show the answer.
      System.out.println("You answered: " + answer);
   }
}

import java.util.Scanner;

/**
 * This program demonstrates some of the Character class's 
 * character testing methods.  
 */

public class CharacterTest
{
   public static void main(String[] args)
   {
      String inputLine;    // A line of input
      char inputChar;      // A character

      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Get a character from the user.
      System.out.print("Enter a character: ");
      inputLine = keyboard.nextLine();
      inputChar = inputLine.charAt(0);
      
      // Test the character.
      if (Character.isLetter(inputChar))
         System.out.println("Letter");

      if (Character.isDigit(inputChar))
         System.out.println("Digit");

      if (Character.isLowerCase(inputChar))
         System.out.println("Lowercase letter");

      if (Character.isUpperCase(inputChar))
         System.out.println("Uppercase letter");

      if (Character.isSpaceChar(inputChar))
         System.out.println("Space");

      if (Character.isWhitespace(inputChar))
         System.out.println("Whitespace");
   }
}

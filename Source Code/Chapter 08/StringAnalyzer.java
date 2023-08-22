import java.util.Scanner;

/**
 * This program displays the number of letters, digits, and  
 * whitespace characters in a string.
 */

public class StringAnalyzer
{
   public static void main(String[] args)
   {
      String str;          // To hold the input as a string
      char[] array;        // To hold the input as an array
      int letters = 0,     // Total number of alphabetic letters
          digits = 0,      // Total number of digits
          whitespaces = 0; // Total number of whitespace characters

      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get a string from the user.
      System.out.print("Enter a string: ");
      str = keyboard.nextLine();

      // Convert the string to a char array.
      array = str.toCharArray();

      // Analyze the characters.
      for (int i = 0; i < array.length; i++)
      {
         if (Character.isLetter(array[i]))
            letters++;
         else if (Character.isDigit(array[i]))
            digits++;
         else if (Character.isWhitespace(array[i]))
            whitespaces++;
      }

      // Display the results.
      System.out.println("That string contains " +
                         letters + " letters, " +
                         digits + " digits, and " +
                         whitespaces +
                         " whitespace characters.");
   }
}


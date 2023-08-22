import java.util.Scanner;

/**
 * This program tests a customer number to determine
 * whether it is in the proper format.
 */

public class CustomerNumber
{
   public static void main(String[] args)
   {
      String customer;  // To hold a customer number
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      System.out.println("Enter a customer number in " +
                         "the form LLLNNNN");
      System.out.print("(LLL = letters and NNNN " +
                       "= numbers): ");

      // Get a customer number from the user.
      customer = keyboard.nextLine();
      
      // Determine whether it is valid.
      if (isValid(customer))
      {
         System.out.println("That's a valid customer " +
                            "number.");
      }
      else
      {
         System.out.println("That is not the proper " +
                            "format.");
         System.out.println("Here is an example: " +
                            "ABC1234");
      }
   }

   /**
    * The isValid method accepts a String as its argument 
    * and tests its contents for a valid customer number.
    */

   private static boolean isValid(String custNumber)
   {
      boolean goodSoFar = true;  // Flag
      int index = 0;             // Loop control variable

      // Is the string the correct length?
      if (custNumber.length() != 7)
         goodSoFar = false;

      // Test the first three characters for letters.
      while (goodSoFar && index < 3)
      {
         if (!Character.isLetter(custNumber.charAt(index)))
            goodSoFar = false;
         index++;
      }

      // Test the last four characters for digits.
      while (goodSoFar && index < 7)
      {
         if (!Character.isDigit(custNumber.charAt(index)))
            goodSoFar = false;
         index++;
      }

      // Return the results
      return goodSoFar;
   }
}



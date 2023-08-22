import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program compares two String objects using
 * the compareTo method.
 */

public class StringCompareTo
{
   public static void main(String[] args)
   {
      String name1, name2;  // To hold two names

      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);

      // Get a name.
      System.out.print("Enter a name: ");
      name1 = keyboard.nextLine();
      
      // Get another name.
      System.out.print("Enter another name: ");
      name2 = keyboard.nextLine();

      // Compare the names.
      if (name1.compareTo(name2) < 0)
      {
         System.out.println(name1 + " is less than " + name2);
      }
      else if (name1.compareTo(name2) == 0)
      {
         System.out.println(name1 + " is equal to " + name2);
      }
      else if (name1.compareTo(name2) > 0)
      {
         System.out.println(name1 + " is greater than " + name2);
      }
   }
}

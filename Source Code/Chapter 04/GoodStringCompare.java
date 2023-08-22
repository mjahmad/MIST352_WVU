import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program correctly compares two String objects using
 * the equals method. 
 */

public class GoodStringCompare
{
   public static void main(String[] args)
   {
      String name1, name2, name3; // Three names

      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);

      // Get a name.
      System.out.print("Enter a name: ");
      name1 = keyboard.nextLine();
      
      // Get a second name.
      System.out.print("Enter a second name: ");
      name2 = keyboard.nextLine();

      // Get a third name.
      System.out.print("Enter a third name: ");
      name3 = keyboard.nextLine();

      // Compare name1 and name2
      if (name1.equals(name2))
      {
         System.out.println(name1 + " and " + name2 +
                            " are the same.");
      }
      else
      {
         System.out.println(name1 + " and " + name2 +
                            " are NOT the same.");
      }

      // Compare name1 and name3
      if (name1.equals(name3))
      {
         System.out.println(name1 + " and " + name3 +
                            " are the same.");
      }
      else
      {
         System.out.println(name1 + " and " + name3 +
                            " are NOT the same.");
      }
   }
}

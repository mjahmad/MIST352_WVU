import java.util.Scanner;

/**
 * This program demonstrates the binary search method in    
 * the ArrayTools class.
 */

public class BinarySearchDemo
{
   public static void main(String[] args)
   {
      int result,       // Result of the search
          searchValue;  // Value to search for
      String again;     // Indicates whether to search again
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // The values in the following array are sorted
      // in ascending order.
      int numbers[] = {101, 142, 147, 189, 199, 207, 222,
                       234, 289, 296, 310, 319, 388, 394,
                       417, 429, 447, 521, 536, 600};

      do
      {
         // Get a value to search for.
         System.out.print("Enter a value to search for: ");
         searchValue = keyboard.nextInt();

         // Search for the value
         result = ArrayTools.binarySearch(numbers, searchValue);

         // Display the results.
         if (result == -1)
            System.out.println(searchValue + " was not found.");
         else
         {
            System.out.println(searchValue + " was found at " +
                               "element " + result);
         }

         // Consume the remaining newline.
         keyboard.nextLine();

         // Does the user want to search again?
         System.out.print("Do you want to search again? (Y or N): ");
         again = keyboard.nextLine();
         
      } while (again.charAt(0) == 'y' || again.charAt(0) == 'Y');
   }
}




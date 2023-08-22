import java.util.Scanner;

/**
 *  This demonstrates the recursive binary search method.
 */

public class RecursiveBinarySearch
{
   public static void main(String [] args)
   {
      // The values in the following array are sorted
      // in ascending order.
      int numbers[] = {101, 142, 147, 189, 199, 207, 222,
                       234, 289, 296, 310, 319, 388, 394,
                       417, 429, 447, 521, 536, 600};
                 
      int result;       // Result of the search
      int searchValue;  // Value to search for
      String again;     // User input
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      do
      {
         // Get a value to search for.
         System.out.print("Enter a value to search for: ");
         searchValue = keyboard.nextInt();

         // Search for the value
         result = binarySearch(numbers, 0,
                      (numbers.length - 1), searchValue);

         // Display the results.
         if (result == -1)
         {
            System.out.println(searchValue +
                               " was not found.");
         }
         else
         {
            System.out.println(searchValue + 
                               " was found at " +
                               "element " + result);
         }

         // Consume the remaining newline.
         keyboard.nextLine();

         // Does the user want to search again?
         System.out.print("Do you want to search again? " +
                          "(Y or N): ");
         again = keyboard.nextLine();
         
      } while (again.charAt(0) == 'y' || again.charAt(0) == 'Y');
   }

   /**
    *  The binarySearch method performs a binary search on an
    *  integer array. The array is searched for the number passed
    *  to value. If the number is found, its array subscript is
    *  returned. Otherwise, -1 is returned indicating the value was
    *  not found in the array.
    */

   public static int binarySearch(int[] array, int first, int last,
                      int value)
   {
      int middle;    // Mid-point of search
      
      // Test for the base case where the value is not found.
      if (first > last)
         return -1;
       
      // Calculate the middle position.
      middle = (first + last) / 2;
       
      // Search for the value.
      if (array[middle] == value)
         return middle;
      else if (array[middle] < value)
         return binarySearch(array, middle + 1, last, value);
      else
         return binarySearch(array, first, middle - 1, value);
   }
}
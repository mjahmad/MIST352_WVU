/**
 * This class's sequentialSearch method searches an
 * int array for a specified value.
 */

public class SearchArray
{
   /**
    * The sequentialSearch method searches array for
    * value. If value is found in array, the element's
    * subscript is returned. Otherwise, -1 is returned.
    */

   public static int sequentialSearch(int[] array, int value)
   {
      int index,      // Loop control variable
          element;    // Element the value is found at
      boolean found;  // Flag indicating search results

      // Element 0 is the starting point of the search.
      index = 0;

      // Store the default values for element and found.
      element = -1;
      found = false;

      // Search the array.
      while (!found && index < array.length)
      {
         // Does this element have the value?
         if (array[index] == value)
         {
            found = true;     // Indicate the value is found.
            element = index;  // Save the subscript of the value.
         }
         
         // Increment index so we can look at the next element.
         index++;
      }

      // Return either the subscript of the value (if found)
      // or -1 to indicate the value was not foumd.
      return element;
   }
}

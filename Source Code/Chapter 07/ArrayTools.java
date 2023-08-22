/**
 * This class has methods for performing the selection sort 
 * and the binary search on integer arrays.
 */

public class ArrayTools
{

	/**
	 * The selectionSort method performs a selection sort on an     
     * integer array. The array is sorted in ascending order.
	 */

   public static void selectionSort(int[] array)
   {
      int startScan, index, minIndex, minValue;

      for (startScan = 0; startScan < (array.length-1); startScan++)
      {
         minIndex = startScan;
         minValue = array[startScan];
         for(index = startScan + 1; index < array.length; index++)
         {
            if (array[index] < minValue)
            {
               minValue = array[index];
               minIndex = index;
            }
         }
         array[minIndex] = array[startScan];
         array[startScan] = minValue;
      }
   }


	/**
	 * The binarySearch method performs a binary search on an       
     * integer array. The array is searched for the number passed   
     * to value. If the number is found, its array subscript is     
     * returned. Otherwise, -1 is returned indicating the value was 
     * not found in the array.
	 */

   public static int binarySearch(int[] array, int value)
   {
      int first,       // First array element
          last,        // Last array element
          middle,      // Mid point of search
          position;    // Position of search value
      boolean found;   // Flag

      // Set the inital values.
      first = 0;
      last = array.length - 1;
      position = -1;
      found = false;

      // Search for the value.
      while (!found && first <= last)
      {
         middle = (first + last) / 2;    // Calculate mid point
         if (array[middle] == value)     // If value is found at mid
         {
            found = true;
            position = middle;
         }
         else if (array[middle] > value) // If value is in lower half
            last = middle - 1;
         else
            first = middle + 1;          // If value is in upper half
      }

      // Return the position of the item, or -1
      // if it was not found.
      return position;
   }
}

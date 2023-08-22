/**
 * This program demonstrates the selectionSort method
 * in the ArrayTools class. 
 */

public class SelectionSortDemo
{
   public static void main(String[] arg)
   {
      // Create an array of unsorted values.
      int[] values = {5, 7, 2, 8, 9, 1};

      // Display the unsorted array.
      System.out.println("The unsorted values are:");
      for (int index = 0; index < values.length; index++)
         System.out.print(values[index] + " ");
      System.out.println();

      // Sort the array.
      ArrayTools.selectionSort(values);

      // Display the sorted array.
      System.out.println("The sorted values are:");
      for (int index = 0; index < values.length; index++)
         System.out.print(values[index] + " ");
   }
}

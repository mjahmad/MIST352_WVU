/**
 * This program demonstrates how to copy an array.
 */

public class CopyArray
{
   public static void main(String[] args)
   {
      final int ARRAY_SIZE = 5;  // Sizes of the arrays.
      int[] array1 = { 2, 4, 6, 8, 10};
      int[] array2 = new int[ARRAY_SIZE];
      
      // Make array 2 reference a copy of array1.
      for (int index = 0; index < array1.length; index++)
         array2[index] = array1[index];

      // Change one of the elements using array1.
      array1[0] = 200;

      // Change one of the elements using array2.
      array2[4] = 1000;

      // Display all the elements using array1
      System.out.println("The contents of array1:");
      for (int value : array1)
         System.out.print(value + " ");
      System.out.println();

      // Display all the elements using array2
      System.out.println("The contents of array2:");
      for (int value : array2)
         System.out.print(value + " ");
      System.out.println();
   }
}

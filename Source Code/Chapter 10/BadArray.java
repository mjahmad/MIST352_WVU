/**
 *  This program causes an error and crashes. 
 */

public class BadArray
{
   public static void main(String[] args)
   {
      // Create an array with three elements.
      int[] numbers = { 1, 2, 3 };

      // Attempt to read beyond the bounds
      // of the array.
      for (int index = 0; index <= 3; index++)
         System.out.println(numbers[index]);
   }
}

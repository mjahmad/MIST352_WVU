/**
 * This class demonstrates methods that accept a 
 * two-dimensional array as an argument.
 */

public class Pass2Darray
{
   public static void main(String[] args)
   {
      // Create a 2D array of integers.
      int[][] numbers = { { 1,  2,  3,  4  },
                          { 5,  6,  7,  8  },
                          { 9, 10, 11, 12  } };

      System.out.println("Here are the values in " +
                         "the array.");
                         
      // Pass the numbers array to the showArray method.
      // This will display the array's contents.
      showArray(numbers);

      // Display the sum of the array's values.
      // Note the call to the arraySum method, with the
      // array being passed as an argument.
      System.out.println("The sum of the values is " +
                         arraySum(numbers));
   }

   /**
    * The showArray method accepts a two-dimensional 
    * int array and displays its contents. 
    */

   private static void showArray(int[][] array)
   {
      for (int row = 0; row < array.length; row++)
      {
         for (int col = 0; col < array[row].length; col++)
            System.out.print(array[row][col] + " ");
         System.out.println();
      }
   }

   /**
    * The arraySum method accepts a two-dimensional  
    * int array and returns the sum of its contents.
    */

   private static int arraySum(int[][] array)
   {
      int total = 0;   // Accumulator

      for (int row = 0; row < array.length; row++)
      {
         for (int col = 0; col < array[row].length; col++)
            total += array[row][col];
      }

      return total;
   }
}
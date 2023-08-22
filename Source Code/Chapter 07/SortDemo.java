import java.util.Arrays;

/**
 * This program demonstrates the Arrays.sort method.
 */

public class SortDemo
{
     public static void main(String [] args)
     {
          int [] numbers = { 9, 2, 7, 12, 1 };

          // Display the array elements unsorted.
          for (int i = 0; i < numbers.length; i++)
               System.out.print(numbers[i] + " ");
          System.out.println();

          // Sort the array.
          Arrays.sort(numbers);

          // Display the array elements sorted.
          for (int i = 0; i < numbers.length; i++)
               System.out.print(numbers[i] + " ");
          System.out.println();
     }
}


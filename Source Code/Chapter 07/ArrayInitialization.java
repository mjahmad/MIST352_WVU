/**
 * This program shows an array being initialized.
 */

public class ArrayInitialization
{
   public static void main(String[] args)
   {
      final int MONTHS = 12;  // Number of months
      
      // Create and initialize an array.
      int[] days = { 31, 28, 31, 30, 31, 30,
                     31, 31, 30, 31, 30, 31 };

      // Display the days in each month.
      for (int index = 0; index < MONTHS; index++)
      {
         System.out.println("Month " + (index + 1) +
                            " has " + days[index] + " days.");
      }
   }
}

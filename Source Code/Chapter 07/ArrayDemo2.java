import java.util.Scanner;

/**
 * This program shows an array being processed with loops.
 */

public class ArrayDemo2
{
   public static void main(String[] args)
   {
      final int NUM_EMPLOYEES = 3; // Number of employees
      
      // Create an array to hold employee hours.
      int[] hours = new int[NUM_EMPLOYEES];

      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      System.out.println("Enter the hours worked by " +
                         NUM_EMPLOYEES + " employees.");

      // Cycle through the array, getting each
      // employee's hours.
      for (int i = 0; i < NUM_EMPLOYEES; i++)
      {
         System.out.print("Employee " + (i + 1) + ": ");
         hours[i] = keyboard.nextInt();
      }

      // Cycle through the array displaying each element.
      System.out.println("The hours you entered are:");
      for (int i = 0; i < NUM_EMPLOYEES; i++)
         System.out.println(hours[i]);
   }
}

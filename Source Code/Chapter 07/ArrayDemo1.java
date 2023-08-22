import java.util.Scanner;

/**
 * This program shows values being read into an array's
 * elements and then displayed.
 */

public class ArrayDemo1
{
   public static void main(String[] args)
   {
      final int NUM_EMPLOYEES = 3;  // Number of employees
      
      // Create an array to hold employee hours.
      int[] hours = new int[NUM_EMPLOYEES];
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      System.out.println("Enter the hours worked by " +
                         NUM_EMPLOYEES + " employees.");

      // Get employee 1's hours.
      System.out.print("Employee 1: ");
      hours[0] = keyboard.nextInt();

      // Get employee 2's hours.
      System.out.print("Employee 2: ");
      hours[1] = keyboard.nextInt();

      // Get employee 3's hours.
      System.out.print("Employee 3: ");
      hours[2] = keyboard.nextInt();

      // Display the values in the array.
      System.out.println("The hours you entered are:");
      System.out.println(hours[0]);
      System.out.println(hours[1]);
      System.out.println(hours[2]);
   }
}

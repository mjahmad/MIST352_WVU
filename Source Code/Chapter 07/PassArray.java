import java.util.Scanner;

/**
 * This program demonstrates passing an array as an   
 * argument to a method.
 */

public class PassArray
{
   public static void main(String[] args)
   {
      final int ARRAY_SIZE = 4;   // Size of the array
      
      // Create an array.
      int[] numbers = new int[ARRAY_SIZE];

      // Pass the array to the getValues method.
      getValues(numbers);
      
      System.out.println("Here are the numbers " +
                         "that you entered:");
                         
      // Pass the array to the showArray method.
      showArray(numbers);
   }

   /**
    * The getValues method accepts an array as its 
    * argument. The user is asked to enter a value 
    * for each element.
    */

   private static void getValues(int[] array)
   {
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      System.out.println("Enter a series of " +
                         array.length + " numbers.");

      // Read values into the array.
      for (int index = 0; index < array.length; index++)
      {
         System.out.print("Number " + (index + 1) + ": ");
         array[index] = keyboard.nextInt();
      }
   }

   /**
    * The showArray method accepts an array as    
    * an argument displays its contents.  
    */

   public static void showArray(int[] array)
   {
      // Display the array elements.
      for (int value : array)
         System.out.print(value + " ");
   }
}

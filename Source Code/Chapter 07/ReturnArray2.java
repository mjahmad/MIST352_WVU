import java.util.Scanner;

/**
 * This program demonstrates the version of the    
 * getArray method where an argument specifies the 
 * size of the array and the user enters values    
 * for the elements. 
 */

public class ReturnArray2
{
   public static void main(String[] args)
   {
		final int ARRAY_SIZE = 5;  // Elements in the array.
      double[] values;           // To reference an array.

      // Let values reference the array returned
      // from the getArray method.
      values = getArray(ARRAY_SIZE);
      
      // Display the values in the array.
      for (int index = 0; index < values.length; index++)
         System.out.println(values[index]);
   }

	/**
	 * The getArray method returns a reference to 
     * an array of doubles. 
	 */

	public static double[] getArray(int size)
	{
   	// Create an array of the specified size.
   	double[] array = new double[size];

   	// Create a Scanner object for keyboard input.
   	Scanner keyboard = new Scanner(System.in);

   	System.out.println("Enter a series of "
                      	 + array.length + " numbers.");

   	// Get values from the user for the array.
   	for (int index = 0; index < array.length; index++)
   	{
      	System.out.print("Number " + (index + 1) + ": ");
      	array[index] = keyboard.nextInt();
   	}

   	// Return the array.
   	return array;
	}
}

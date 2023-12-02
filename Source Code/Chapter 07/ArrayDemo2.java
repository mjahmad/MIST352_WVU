import java.util.Scanner;

/**
 * This program shows an array being processed with loops.
 */

public class ArrayDemo2
{
   public static void main(String[] args)
   {
      final int NUM_EMPLOYEES = 6; // Number of employees
      
      // Create an array to hold employee hours.
      int[] hours = new int[NUM_EMPLOYEES];

      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      System.out.println("Enter the hours worked by " +
                         NUM_EMPLOYEES + " employees.");

      int intSum=0, intAvg=0;
      int intCounter=0;
      while(intCounter < hours.length)
      {
    	  System.out.print("Employee " + (intCounter + 1) + ": ");
          hours[intCounter] = keyboard.nextInt();
    	  intCounter++;
      }
      
      for (int intCounterX=0; intCounterX <hours.length; intCounterX++ )
      {
    	  intSum += hours[intCounterX];
      }
	  System.out.print("\nTotal No. Of hours " + intSum);
	  intAvg = intSum / hours.length;
	  System.out.print("\nThe average " + intAvg);
	  
	  
	  
	 



//      
//      // Cycle through the array, getting each
//      // employee's hours.
//      for (int i = 0; i < NUM_EMPLOYEES; i++)
//      {
//         System.out.print("Employee " + (i + 1) + ": ");
//         hours[i] = keyboard.nextInt();
//      }

      
      // Cycle through the array displaying each element.
      System.out.println("\nThe hours you entered are:");
      for (int i = 0; i < NUM_EMPLOYEES; i++)
         System.out.println(hours[i]);
      
      for(int val : hours)
	  {
	  	System.out.println("The next value is " +
	                       val);
	  } 
   }
}

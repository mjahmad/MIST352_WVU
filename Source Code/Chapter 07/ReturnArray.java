/**
 * This program demonstrates how a reference to an
 * array can be returned from a method.
 */

public class ReturnArray
{
   public static void main(String[] args)
   {
      double[] values;

      // Let values reference the array returned
      // from the getArray method.
      values = getArray();
      
      // Display the values in the array.
      for (double num : values)
         System.out.println(num);
   }

   /**
    * The getArray method returns a reference to 
    * an array of doubles.
    */

   public static double[] getArray()
   {
      double[] array = { 1.2, 2.3, 4.5, 6.7, 8.9 };
      return array;
   }
}

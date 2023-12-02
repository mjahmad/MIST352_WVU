/**
 * This program uses an invalid subscript with an array.
 */

public class InvalidSubscript
{
   public static void main(String[] args)
   {
      // Create an array with three elements.
      //int[] values = new int[90];
      int[] values = {0,1,2,3,4};
      String[] names= {"ALi","Ashley"};

      for(int intCounter=0; intCounter<names.length;intCounter++)
      {
    	  System.out.printf("Item %s\n", names[intCounter]);
    	  
      }
      
      
      
      System.out.println("I will attempt to store four " +
                         "numbers in a 3-element array.");
//
//      for (int index = 0; index <= values.length-1; index++)
//      {
//         System.out.println("Now processing element " + (index+1));
//         values[index] = 10;
//      }
   }
}

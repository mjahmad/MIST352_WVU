/**
 * This program demonstrates the toUpperCase method
 * being called from the elements of a String array.
 */

public class StringArrayMethods
{
   public static void main(String[] args)
   {
      // Create an array of Strings.
      String[] names = { "Bill", "Susan", 
                         "Steven", "Jean" };

      // Display each string in the names array
      // in uppercase.
      for (int index = 0; index < names.length; index++)
         System.out.println(names[index].toUpperCase());
   }
}

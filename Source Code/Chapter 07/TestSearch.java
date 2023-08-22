/**
 * This program demonstrates the SearchArray class's 
 * sequentialSearch method. 
 */

public class TestSearch
{
   public static void main(String[] args)
   {
      int results;  // Results of the search
      
      // Create an array of values.
      int[] tests = { 87, 75, 98, 100, 82 };
      
      // Search the array for the value 100.
      results = SearchArray.sequentialSearch(tests, 100);

      // Determine whether 100 was found in the array.
      if (results == -1)
      {
         // -1 indicates the value was not found.
         System.out.println("You did not earn 100 " +
                            "on any test.");
      }
      else
      {
         // results holds the subscript of the value 100.
         System.out.println("You earned 100 on " +
                            "test " + (results + 1));
      }
   }
}

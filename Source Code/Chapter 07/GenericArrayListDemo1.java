import java.util.ArrayList;   // Needed for the ArrayList class

/**
 *  This program demonstrates how a ArrayList can be used
 *  as a generic data type.
 */

public class GenericArrayListDemo1
{
   public static void main(String[] args)
   {
      // Create an ArrayList to hold some names.
      // Specify that the ArrayList can hold Strings only.
      ArrayList<String> nameList = new ArrayList<String>();
      
      // Add some names to the ArrayList.
      nameList.add("James");
      nameList.add("Catherine");
      nameList.add("Bill");
      
      // Display the size of the ArrayList.
      System.out.println("The ArrayList has " +
                         nameList.size() +
                         " objects stored in it.");

      // Now display the items in nameList.
      for (int index = 0; index < nameList.size(); index++)
         System.out.println(nameList.get(index));
   }
}
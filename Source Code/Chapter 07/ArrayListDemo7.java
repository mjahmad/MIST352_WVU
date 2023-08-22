import java.util.ArrayList;   // Needed for the ArrayList class

/**
 * This program demonstrates how a ArrayList can hold a
 * mixture of object types. 
 */

public class ArrayListDemo7
{
   public static void main(String[] args)
   {
      // Create a listor to hold some names.
      ArrayList list = new ArrayList();
      
      // Add a variety of objects to the ArrayList.
      list.add(new InventoryItem("Bolts", 150)); // Add an InventoryItem object
      list.add("Java is fun!");                  // Add a String object
      list.add(new Rectangle(20, 10));           // Add a Rectangle object
      
      // Now get references to each of the objects
      // in the ArrayList. Note that the correct cast operator
      // is required for each statement.
      InventoryItem item = (InventoryItem)list.get(0);
      String str = (String)list.get(1);
      Rectangle rect = (Rectangle)list.get(2);
   }
}
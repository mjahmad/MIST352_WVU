import java.util.ArrayList;   // Needed for the ArrayList class

/**
 * This program demonstrates how to use a cast operator
 * with the ArrayList class's get method.
 */

public class ArrayListDemo6
{
   public static void main(String[] args)
   {
      // Create an ArrayList to hold InventoryItem objects.
      ArrayList<InventoryItem> list = new ArrayList<InventoryItem>();
      
      // Add three InventoryItem objects to the ArrayList.
      list.add(new InventoryItem("Nuts", 100));
      list.add(new InventoryItem("Bolts", 150));
      list.add(new InventoryItem("Washers", 75));
      
      // Display each item.
      for (int index = 0; index < list.size(); index++)
      {
         InventoryItem item = (InventoryItem)list.get(index);
         System.out.println("Item at index " + index +
                            "\nDescription: " + item.getDescription() +
                            "\nUnits: " + item.getUnits());
      }      
   }
}
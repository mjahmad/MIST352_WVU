import java.util.ArrayList;   // Needed for the ArrayList class

/**
 * This program demonstrates how a ArrayList can be used  
 * as a generic data type.
 */

public class GenericArrayListDemo2
{
   public static void main(String[] args)
   {
      // Create a listor to hold InventoryItem objects.
      ArrayList<InventoryItem> list = 
                    new ArrayList<InventoryItem>();
      
      // Add three InventoryItem objects to the ArrayList.
      list.add(new InventoryItem("Nuts", 100));
      list.add(new InventoryItem("Bolts", 150));
      list.add(new InventoryItem("Washers", 75));
      
      // Display each item.
      for (int index = 0; index < list.size(); index++)
      {
         InventoryItem item = list.get(index);
         System.out.println("Item at index " + index +
                            "\nDescription: " + item.getDescription() +
                            "\nUnits: " + item.getUnits());
      }      
   }
}
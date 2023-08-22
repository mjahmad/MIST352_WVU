import java.util.ArrayList;   // Needed for the ArrayList class

/**
 * This program demonstrates how a ArrayList can be used   
 * as a generic data type, and how the enhanced for     
 * can be used to iterate over a ArrayList's contents.
 */

public class GenericArrayListDemo3
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
      for (InventoryItem item : list)
      {
         System.out.println("Description: " + item.getDescription() +
                            "\nUnits: " + item.getUnits());
      }      
   }
}
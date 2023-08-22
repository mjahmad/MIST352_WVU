/**
 * This program passes an object as an argument.
 */

public class PassObject
{
   public static void main(String[] args)
   {
      // Create an InventoryItem object.
      InventoryItem item = new InventoryItem("Wrench", 20);

      // Pass the object to the DisplayItem method.
      displayItem(item);
   }

   /**
    * The following method accepts an InventoryItem
    * object as an argument and displays its contents.
    */

   public static void displayItem(InventoryItem i)
   {
      System.out.println("Description: " + i.getDescription());
      System.out.println("Units: " + i.getUnits());
   }
}

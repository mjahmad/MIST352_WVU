/**
 * This program passes an object as an argument.   
 * The object is modified by the receiving method.
 */

public class PassObject2
{
   public static void main(String [] args)
   {
      // Create an InventoryItem object.
      InventoryItem item = new InventoryItem("Wrench", 20);

      // Display the object's contents.
      System.out.println("The contents of item are:");
      System.out.println("Description: " +
                         item.getDescription() +
                         "  Units: " + item.getUnits());

      // Pass the object to the ChangeItem method.
      changeItem(item);

      // Display the object's contents again.
      System.out.println();
      System.out.println("Now the contents of item are:");
      System.out.println("Description: " + 
                         item.getDescription() +
                         "  Units: " + item.getUnits());
   }

   /**
    * The following method accepts an InventoryItem    
    * object as an argument and changes its contents.
    */

   public static void changeItem(InventoryItem i)
   {
      i.setDescription("Hammer");
      i.setUnits(5);
   }
}

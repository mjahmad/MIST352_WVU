/**
 * This program demonstrates the InventoryItem class's 
 * three constructors. 
 */

public class InventoryDemo
{
   public static void main(String[] args)
   {
      // Variables to reference 3 instances of
      // the InventoryItem class.
      InventoryItem item1, item2, item3;

      // Instantiate item1 and use the 
      // no-arg constructor.
      item1 = new InventoryItem();
      System.out.println("Item 1:");
      System.out.println("Description: " +
                         item1.getDescription());
      System.out.println("Units: " + item1.getUnits());
      System.out.println();


      // Instantiate item2 and use the 
      // second constructor.
      item2 = new InventoryItem("Wrench");
      System.out.println("Item 2:");
      System.out.println("Description: " +
                         item2.getDescription());
      System.out.println("Units: " + item2.getUnits());
      System.out.println();

      // Instantiate item3 and use the 
      // third constructor.
      item3 = new InventoryItem("Hammer", 20);
      System.out.println("Item 3:");
      System.out.println("Description: " +
                         item3.getDescription());
      System.out.println("Units: " + item3.getUnits());
   }
}

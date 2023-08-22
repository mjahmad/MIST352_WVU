/**
 * This program demonstrates a method that accepts
 * a variable number of arguments (varargs).
 */

public class VarargsDemo2
{
   public static void main(String[] args)
   {
      int total;  // To hold the total units
      
      // Create an InventoryItem object with 10 units.
      InventoryItem item1 = new InventoryItem("Soap", 10);
      
      // Create an InventoryItem object with 20 units.
      InventoryItem item2 = new InventoryItem("Shampoo", 20);

      // Create an InventoryItem object with 30 units.
      InventoryItem item3 = new InventoryItem("Toothpaste", 30);
      
      // Call the method with one argument.
      total = totalUnits(item1);
      System.out.println("Total: " + total);
      
      // Call the method with two arguments.
      total = totalUnits(item1, item2);
      System.out.println("Total: " + total);
      
      // Call the method with three arguments.
      total = totalUnits(item1, item2, item3);
      System.out.println("Total: " + total);
   }
   
   /**
    * The totalUnits method takes a variable number
    * of InventoryItem objects and returns the total
    * of their units.
    */
   
   public static int totalUnits(InventoryItem... items)
   {
      int total = 0;  // Accumulator
      
      // Add all the values in the numbers array.
      for (InventoryItem itemObject : items)
         total += itemObject.getUnits();
      
      // Return the total.
      return total;
   }
}
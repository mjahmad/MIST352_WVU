/**
 *  This program demonstrates how the InventoryItem class
 *  throws exceptions.
 */

public class InventoryDemo
{
   public static void main(String[] args)
   {
      InventoryItem item;

      // Try to assign an empty string to the
      // description field.
      try
      {
         item = new InventoryItem("");
      }
      catch (IllegalArgumentException e)
      {
         System.out.println(e.getMessage());
      }

      // Again, try to assign an empty string to
      // the description field.
      try
      {
         item = new InventoryItem("", 5);
      }
      catch (IllegalArgumentException e)
      {
         System.out.println(e.getMessage());
      }

      // Try to assign a negative number to the
      // units field.
      try
      {
         item = new InventoryItem("Wrench", -1);
      }
      catch (IllegalArgumentException e)
      {
         System.out.println(e.getMessage());
      }
   }
}

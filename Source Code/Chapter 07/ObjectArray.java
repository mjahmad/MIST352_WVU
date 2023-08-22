import java.util.Scanner;

/**
 * This program works with an array of InventoryItem objects.
 */

public class ObjectArray
{
   public static void main(String[] args)
   {
      final int NUM_ITEMS = 3;   // Number of items
      
      // Create an InventoryItem array.
      InventoryItem[] inventory = new InventoryItem[NUM_ITEMS];

      // Call the getItems method to get data for each element.
      getItems(inventory);

      System.out.println("You entered the following:");

      // Display the data that the user entered.
      for (int index = 0; index < inventory.length; index++)
      {
         System.out.println("Item " + (index + 1));
         System.out.println("Description: " + 
                            inventory[index].getDescription());
         System.out.println("Units: " +
                            inventory[index].getUnits());
         System.out.println();
      }
   }

   /**
    * The getItems method accepts an InventoryItem array as 
    * an argument. The user enters data for each element.
    */

   private static void getItems(InventoryItem[] array)
   {
      String description;  // Item description
      int units;           // Number of units on hand
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      System.out.println("Enter data for " + array.length +
                         " inventory items.");
      
      // Get data for the array.
      for (int index = 0; index < array.length; index++)
      {
         // Get an item's description.
         System.out.print("Enter the description for " +
                          "item " + (index + 1) + ": ");
         description = keyboard.nextLine();

         // Get the number of units.
         System.out.print("Enter the units for " +
                          "item " + (index + 1) + ": ");
         units = keyboard.nextInt();
         
         // Consume the remaining newline.
         keyboard.nextLine();

         // Create an InventoryItem object initialized with
         // the data and store the object in the array.
         array[index] = new InventoryItem(description, units);
         
         // Display a blank line before going on.
         System.out.println();
      }
   }
}



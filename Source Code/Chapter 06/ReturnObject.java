import java.util.Scanner;

/**
 * This program demonstrates how a method can return 
 * a reference to an object.  
 */

public class ReturnObject
{
   public static void main(String[] args)
   {
      // Declare a variable that will be used to
      // reference an InventoryItem object.
      InventoryItem item;

      // The getData method will return a reference
      // to an InventoryItem object.
      
      item = getData();

      // Display the object's data.
      System.out.println("Here is the data you entered:");
      System.out.println("Description: " +
                         item.getDescription() +
                         "  Units: " + item.getUnits());

   }

   /**
    * The getData method gets an item's description 
    * and number of units from the user. The method 
    * returns an InventoryItem object containing    
    * the data that was entered. 
    */
   
   public static InventoryItem getData()
   {
      String desc;   // To hold the description
      int units;     // To hold the units
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get the item description.    
      System.out.print("Enter an item description: ");
      desc = keyboard.nextLine();
      
      // Get the number of units.
      System.out.print("Enter a number of units: ");
      units = keyboard.nextInt();

      // Create an InventoryItem object and return
      // a reference to it.
      return new InventoryItem(desc, units);
   }
}
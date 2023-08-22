import java.util.Scanner;
import java.io.*;

/**
 * This program serializes the objects in an array of      
 * InventoryItem2 objects.
 */

public class SerializeObjects
{
   public static void main(String[] args) throws IOException
   {
      final int NUM_ITEMS = 3;  // Number of items
      String description;       // Item description
      int units;                // Units on hand
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
          
      // Create an array to hold InventoryItem objects.
      InventoryItem2[] items =
                   new InventoryItem2[NUM_ITEMS];
      
      // Get data for the InventoryItem objects.
      System.out.println("Enter data for " + NUM_ITEMS +
                         " inventory items.");
                         
      for (int i = 0; i < items.length; i++)
      {
         // Get the item description.
         System.out.print("Enter an item description: ");
         description = keyboard.nextLine();
         
         // Get the number of units.
         System.out.print("Enter the number of units: ");
         units = keyboard.nextInt();

         // Consume the remaining newline.
         keyboard.nextLine();

         // Create an InventoryItem2 object in the array.
         items[i] = new InventoryItem2(description, units);
      }
      
      // Create the stream objects.
      FileOutputStream outStream = 
             new FileOutputStream("Objects.dat");
      ObjectOutputStream objectOutputFile = 
             new ObjectOutputStream(outStream);
      
      // Write the serialized objects to the file.
      for (int i = 0; i < items.length; i++)
      {
         objectOutputFile.writeObject(items[i]);
      }
      
      // Close the file.
      objectOutputFile.close();
      System.out.println("The serialized objects were written to the " +
                         "Objects.dat file.");
   }
}

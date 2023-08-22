import java.io.*;

/**
 * This program deserializes the objects in the Objects.dat
 * file and stores them in an array.  
 */

public class DeserializeObjects
{
   public static void main(String[] args) throws Exception
   {
      final int NUM_ITEMS = 3;  // Number of items

      // Create the stream objects.
      FileInputStream inStream = 
             new FileInputStream("Objects.dat");
      ObjectInputStream objectInputFile = 
             new ObjectInputStream(inStream);
      
      // Create an array to hold InventoryItem objects.
      InventoryItem2[] items = new InventoryItem2[NUM_ITEMS];
      
      // Read the serialized objects from the file.
      for (int i = 0; i < items.length; i++)
      {
         items[i] =
             (InventoryItem2) objectInputFile.readObject();
      }
      
      // Close the file.
      objectInputFile.close();
      
      // Display the objects.
      for (int i = 0; i < items.length; i++)
      {
         System.out.println("Item " + (i + 1));
         System.out.println("   Description: " + 
                            items[i].getDescription());
         System.out.println("   Units: " + 
                            items[i].getUnits());
      }
   }
}

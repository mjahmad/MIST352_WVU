import java.io.*;

/**
 * This class manages a random access file which contains
 * InventoryItem records.
 */

public class InventoryItemFile
{
   private final int RECORD_SIZE = 44;     // Record length
   private RandomAccessFile inventoryFile; // Random-Access file
   
	/**
	 * Constructor
	 */
   
   public InventoryItemFile(String filename)
                         throws FileNotFoundException
   {
      // Open the file for reading and writing.
      inventoryFile = new RandomAccessFile(filename, "rw");
   }
   
	/**
	 * The writeInventoryItem method writes the
     * InventoryItem argument to the file at the
     * current file pointer position.
	 */

   public void writeInventoryItem(InventoryItem item)
                                   throws IOException
   {
      // Get the item's description.
      String str = item.getDescription();
      
      // Write the description.
      if (str.length() > 20)
      {
         // If there are more than 20 characters in the
         // string, then write only the first 20 to the file.
         for (int i = 0; i < 20; i++)
            inventoryFile.writeChar(str.charAt(i));
      }
      else
      {
         // Write the description to the file.
         inventoryFile.writeChars(str);
         // Write enough spaces to pad it out
         // to 20 characters.
         for (int i = 0; i < (20 - str.length()); i++)
            inventoryFile.writeChar(' ');
      }
      
      // Write the units to the file.
      inventoryFile.writeInt(item.getUnits());
   }
   
	/**
	 * The readInventoryItem method reads and returns
     * the record at the current file pointer position.
	 */

   public InventoryItem readInventoryItem() throws IOException
   {
      // Create a char array with 20 elements.
      char[] charArray = new char[20];
      
      // Read the description, character by character,
      // from the file into the char array.
      for (int i = 0; i < 20; i++)
         charArray[i] = inventoryFile.readChar();
         
      // Store the char array in a String.
      String description = new String(charArray);
      
      // Trim any trailing spaces from the string.
      description.trim();
      
      // Read the units from the file.
      int units = inventoryFile.readInt();
      
      // Create an InventoryItem object and initialize
      // it with these values.
      InventoryItem item = new InventoryItem(description, units);
      
      // Return the object.
      return item;
   }

	/**
	 * The getByteNum method accepts a record number
     * and returns that record's starting byte number.
	 */

   private long getByteNum(long recordNum)
   {
      return RECORD_SIZE * recordNum;
   }
   
	/**
	 * The moveFilePointer method moves the file
     * to the record indicated by the argument. 
	 */

   public void moveFilePointer(long recordNum)
                            throws IOException
   {
      inventoryFile.seek(getByteNum(recordNum));
   }

	/**
	 * The getNumberOfRecords method returns the number
     * of records stored in the file.  
	 */
   
   public long getNumberOfRecords() throws IOException
   {
      return inventoryFile.length() / RECORD_SIZE;
   }
   
	/**
	 * The close method closes the file.
	 */
   
   public void close() throws IOException
   {
      inventoryFile.close();
   }
}

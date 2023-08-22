import java.util.Scanner; // Needed for Scanner
import java.io.*;         // Needed for File and IOException

/**
 *  This program reads data from a file.
 */

public class FileReadDemo2
{
   public static void main(String[] args) throws IOException
   {
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get the filename.
      System.out.print("Enter the filename: ");
      String filename = keyboard.nextLine();

      // Make sure the file exists.
      File file = new File(filename);
      if (!file.exists())
      {
         // Display an error message.
         System.out.println("The file " + filename +
                            " does not exist.");
         
         // Exit the program.
         System.exit(0);
      }
      
      // Open the file.
      Scanner inputFile = new Scanner(file);

      // Read lines from the file until no more are left.
      while (inputFile.hasNext())
      {
         // Read the next name.
         String friendName = inputFile.nextLine();

         // Display the last name read.
         System.out.println(friendName);
      }

      // Close the file.
      inputFile.close();
   }
}

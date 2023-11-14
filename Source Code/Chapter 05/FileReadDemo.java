import java.util.Scanner; // Needed for the Scanner
import java.io.*;         // Needed for the File and IOException

/**
 *  This program reads data from a file.
 */

public class FileReadDemo
{
   public static void main(String[] args) throws IOException
   {
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get the filename.
      //System.out.print("Enter the filename: ");
      String filename = "d:\\a.csv";
      
      //keyboard.nextLine();

      // Open the file.
      File theFile = new File(filename);
      Scanner inputFile = new Scanner(theFile);

      // Read lines from the file until no more are left.
      inputFile.nextLine();
      while (inputFile.hasNext())
      {
         // Read the next name.
         String friendName = inputFile.nextLine().split(",")[0];
         int LastFS = friendName.lastIndexOf("/");
         friendName = friendName.substring(LastFS+1, friendName.length());

         // Display the last name read.
         System.out.println(friendName);
      }

      // Close the file.
      inputFile.close();
   }
}

import java.util.Scanner;
import java.io.*;

/**
 * This program demonstrates reading a file using only
 * a FileReader object. 
 */

public class SimpleFileReader
{
   public static void main(String[] args)
   {
      String filename;   // The file name
      int rawData;       // To hold the character code
      char ch;           // To hold the character

      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Get the file name.
      System.out.print("Enter a file name: ");
      filename = keyboard.nextLine();

      try
      {
         // Open the file.
         FileReader reader = new FileReader(filename);

         // Read a character code from the file.
         rawData = reader.read();
         while (rawData != -1)
         {
            // Convert the code to a character.
            ch = (char) rawData;
            // Print the character.
            System.out.print(ch);
            // Get the next code from the stream.
            rawData = reader.read();
         }
      }
      catch (IOException e)
      {
         System.out.println("Error: " + e.getMessage());
      }
   }
}


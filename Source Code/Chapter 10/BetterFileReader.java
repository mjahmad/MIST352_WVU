import java.util.Scanner;
import java.io.*;

/**
 * This program demonstrates reading a file using a
 * a BufferedReader object.
 */

public class BetterFileReader
{
   public static void main(String[] args)
   {
      String filename,   // The file name
             input;      // To hold the file input
             
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get the file name.
      System.out.print("Enter a file name: ");
      filename = keyboard.nextLine();

      try
      {
         // Open the file.
         BufferedReader inputFile = 
            new BufferedReader(new FileReader(filename));

         // Read a line from the file.
         input = inputFile.readLine();
         
         // Process the file contents.
         while (input != null)
         {
            // Print the line.
            System.out.println(input);
            // Get the next line from the stream.
            input = inputFile.readLine();
         }
      }
      catch (IOException e)
      {
         System.out.println("Error: " + e.getMessage());
      }
   }
}


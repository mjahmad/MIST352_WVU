import java.io.*;

/**
 * This program demonstrates how multiple catch clauses
 * can be used to handle multiple types of exceptions. 
 */

public class ReadFile
{
     public static void main(String[] args)
     {
          FileReader reader;
          BufferedReader inputFile;
          String fileName,
                 input;

          // Get a file name from the user.
          System.out.print("Enter the name of a file: ");
          fileName = Keyboard.readString();

          // Attempt to open and read the file.
          try
          {
               // Open the file.
               reader = new FileReader(fileName);
               inputFile = new BufferedReader(reader);

               // Read and display the file's contents.
               input = inputFile.readLine();
               while (input != null)
               {
                    System.out.println(input);
                    input = inputFile.readLine();
               }

               // Close the file.
               inputFile.close();
          }
          catch (FileNotFoundException e)
          {
               System.out.println("File not found.");
          }
          catch (IOException e)
          {
               System.out.println(e.getMessage());
          }
     }
}


import java.io.*;

/**
 * This class displays the contents of a file.
 */

public class FilePrinter
{
     private FileReader reader;
     private BufferedReader inputFile;
     private String input;

     public void displayFile(String name) throws IOException
     {
          // Open the file.
          reader = new FileReader(name);
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
}

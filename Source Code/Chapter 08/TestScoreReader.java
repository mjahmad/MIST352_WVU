import java.util.Scanner; // For Scanner
import java.io.*;         // For File and IOException

/**
 *  The TestScoreReader class reads test scores as
 *  tokens from a file and calculates the average
 *  of each line of scores.
 */

public class TestScoreReader
{
   private Scanner inputFile;
   private String line;

   /**
    *  The constructor opens a file to read
    *  the grades from.
    */
   
   public TestScoreReader(String filename)
                        throws IOException
   {
      File file = new File(filename);
      inputFile = new Scanner(file);
   }
   
   /**
    *  The readNextLine method reads the next line
    *  from the file.
    */

   public boolean readNextLine() throws IOException
   {
      boolean lineRead; // Flag variable
    
      // Determine whether there is more to read.
      lineRead = inputFile.hasNext();

      // If so, read the next line. 
      if (lineRead)
        line = inputFile.nextLine();
       
      return lineRead;
   }

   /**
    *  The getAverage method calculates the average
    *  of the last set of test scores read from the file.
    */
    
   public double getAverage()
   {
      int total = 0;    // Accumulator
      double average;   // The average test score

      // Tokenize the last line read from the file.
      String[] tokens = line.split(",");
    
      // Calculate the total of the test scores.
      for (String str : tokens)
      {
         total += Integer.parseInt(str);
      }
    
      // Calculate the average of the scores.
      // Use a cast to avoid integer division.
      average = (double) total / tokens.length;
    
      // Return the average.
      return average;
   }
   
   /**
    *  The close method closes the file.
    */
   
   public void close() throws IOException
   {
      inputFile.close();
   }
}
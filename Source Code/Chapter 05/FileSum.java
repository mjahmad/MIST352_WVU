import java.util.Scanner;  // Needed for Scanner
import java.io.*;          // Needed for File and IOException

/**
 * This class reads a series of numbers from a file and 
 * accumulates their sum.  
 */

public class FileSum
{
   private double sum;   // Accumulator

   /**
    * The constructor accepts a file name as its argument. 
    * The file is opened, the numbers read from it, and    
    * their sum is stored in the sum field.
    */

   public FileSum(String filename) throws IOException
   {
      String str;  // To hold a line read from the file

      // Create the necessary objects for file input.
      File file = new File(filename);
      Scanner inputFile = new Scanner(file);

      // Initialize the accumulator.
      sum = 0.0;

      // Read all of the values from the file and
      // calculate their total.
      while (inputFile.hasNext())
      {
         // Read a value from the file.
         double number = inputFile.nextDouble();
         
         // Add the number to sum.
         sum = sum + number;
      }

      // Close the file.
      inputFile.close();
   }

   /**
    * The getSum method returns the value in the sum field.
    */

   public double getSum()
   {
       return sum;
   }
}

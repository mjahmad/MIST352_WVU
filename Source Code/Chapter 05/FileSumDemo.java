import java.io.*;  // Required for IOException

/**
 * This program demonstrates the FileSum class.
 */

public class FileSumDemo
{
   public static void main(String[] args) throws IOException
   {
      // Create an instance of the FileSum class.
      FileSum fs = new FileSum("Numbers.txt");
      
      // Display the sum of the values in Numbers.txt.
      System.out.println("The sum of the numbers in " +
                         "Numbers.txt is " +
                         fs.getSum());
   }
}
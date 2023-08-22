import java.io.*;

/**
 * This class demonstrates a partially-filled array. 
 * It reads up to 100 numbers from a file into an    
 * array and calculates their average.
 */

public class SeriesAverage
{
     private int[] numbers;
     private int maxSubscript;

	/**
	 * The constructor accepts a file name as its  
     * argument. It calls the readFile method to   
     * read the contents of the file into the      
     * numbers array.
	 */

     public SeriesAverage(String filename) throws IOException
     {
          // Set maxSubscript at zero.
          maxSubscript = 0;

          // Create a 100-element array.
          numbers = new int[100];

          // Read the file.
          readFile(filename);
     }

	/**
	 * The readFile method accepts a file name as  
     * its argument. It opens the file and reads   
     * a series of numbers into the numbers array.
	 */

     private void readFile(String filename) throws IOException
     {
          String str;   // To hold file input.

          // Open the file.
          FileReader freader = new FileReader(filename);
          BufferedReader inputFile = 
               new BufferedReader(freader);

          // Read the file contents into the array.
          str = inputFile.readLine();
          while (str != null && maxSubscript < 100)
          {
               numbers[maxSubscript] = Integer.parseInt(str);
               maxSubscript++;
          }

          // Close the file.
          inputFile.close();
     }

	/**
	 * The getAverage method returns the average   
     * the values in the number array.
	 */

     public double getAverage()
     {
          double total = 0;    // Initialize accumulator
          double average;      // Will hold the average

          for (int i = 0; i <= maxSubscript; i++)
               total += numbers[i];

          average = total / (maxSubscript + 1);
          return average;
     }
}

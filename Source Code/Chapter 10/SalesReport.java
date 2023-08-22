import java.io.*;   // For File class and FileNotFoundException
import java.util.*; // For Scanner and InputMismatchException

/**
 *  This program demonstrates how multiple exceptions can
 *  be caught with one try statement.
 */

public class SalesReport
{
   public static void main(String[] args)
   {
      String filename = "SalesData.txt"; // File name
      int months = 0;                    // Month counter
      double oneMonth;                   // One month's sales
      double totalSales = 0.0;           // Total sales
      double averageSales;               // Average sales

      try
      {
         // Open the file.
         File file = new File(filename);
         Scanner inputFile = new Scanner(file);
         
         // Process the contents of the file.
         while (inputFile.hasNext())
         {
            // Get a month's sales amount.
            oneMonth = inputFile.nextDouble();
            
            // Accumulate the amount.
            totalSales += oneMonth;
            
            // Increment the month counter
            months++;
         }

         // Close the file.
         inputFile.close();

         // Calculate the average.
         averageSales = totalSales / months;

         // Display the results.
         System.out.printf("Number of months: %s\n", months);
         System.out.printf("Total Sales: $%,.2f\n", totalSales);
         System.out.printf("Average Sales: $%,.2f\n", averageSales);
      }
      catch(FileNotFoundException e)
      {
         // The file was not found.
         System.out.println("The file " + filename +
                            " does not exist.");
      }
      catch(InputMismatchException e)
      {
         // Thrown by the Scanner class's nextDouble
         // method when a nonnumeric value is found.
         System.out.println("Nonnumeric data " +
                            "found in the file:" +
                            e.getMessage());
      }
   }
}

/**
 * This class keeps the sales figures for a number of    
 * days in an array and provides methods for getting     
 * the total and average sales, and the highest and      
 * lowest amounts of sales.
 */

public class SalesData
{
   private double[] sales; // References the sales data

   /**
    * The constructor accepts an array as an argument. 
    * The elements in the argument array are copied    
    * to the sales array.
    */

   public SalesData(double[] s)
   {
      // Create a new array the same length as s.
      sales = new double[s.length];
      
      // Copy the values in s to sales.
      for (int index = 0; index < s.length; index++)
         sales[index] = s[index];
   }

   /**
    * The getTotal method returns the total of the     
    * elements in the sales array.
    */

   public double getTotal()
   {
      double total = 0.0;   // Accumulator

      // Add up all the values in the sales array.
      for (double value : sales)
         total += value;

      // Return the total.
      return total;
   }

   /**
    * The getAverage method returns the average of the 
    * elements in the sales array. 
    */

   public double getAverage()
   {
      return getTotal() / sales.length;
   }

   /**
    * The getHighest method returns the highest value  
    * stored in the sales array.
    */

   public double getHighest()
   {
      // Store the first value in the sales array in
      // the variable highest.
      double highest = sales[0];

      // Search the array for the highest value.
      for (int index = 1; index < sales.length; index++)
      {
         if (sales[index] > highest)
            highest = sales[index];
      }

      // Return the highest value.
      return highest;
   }

   /**
    * The getLowest method returns the lowest value    
    * stored in the sales array.
    */

   public double getLowest()
   {
      // Store the first value in the sales array in
      // the variable lowest.
      double lowest = sales[0];

      // Search the array for the lowest value.
      for (int index = 1; index < sales.length; index++)
      {
         if (sales[index] < lowest)
            lowest = sales[index];
      }

      // Return the lowest value.
      return lowest;
   }
}

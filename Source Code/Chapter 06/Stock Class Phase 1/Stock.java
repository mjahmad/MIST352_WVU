/**
 * The Stock class holds data about a stock. 
 */

public class Stock
{
   private String symbol;     // Trading symbol of stock
   private double sharePrice; // Current price per share

   /**
    * The constructor accepts arguments for the     
    * stock's trading symbol and share price.
    */

   public Stock(String sym, double price)
   {
      symbol = sym;
      sharePrice = price;
   }
   
   /**
    * getSymbol method 
    */
   
   public String getSymbol()
   {
      return symbol;
   }
   
   /**
    * getSharePrice method
    */
   
   public double getSharePrice()
   {
      return sharePrice;
   }

   /**
    * toString method
    */
   
   public String toString()
   {
      // Create a string describing the stock.
      String str = "Trading symbol: " + symbol +
                   "\nShare price: " + sharePrice;
      
      // Return the string.
      return str;
   }
}
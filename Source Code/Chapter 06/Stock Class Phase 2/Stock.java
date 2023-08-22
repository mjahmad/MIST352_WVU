/**
 * The Stock class holds data about a stock.         
 * This version of the class has an equals method.
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

	/**
	 * equals method
	 */

   public boolean equals(Stock object2)
   {
      boolean status;
      
      // Determine whether this object's symbol and
      // sharePrice fields are equal to object2's
      // symbol and sharePrice fields.
      if (symbol.equals(object2.symbol) &&
          sharePrice == object2.sharePrice)
         status = true;  // Yes, the objects are equal.
      else
         status = false; // No, the objects are not equal.
      
      // Return the value in status.
      return status;
   }
}

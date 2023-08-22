/**
 * The StockPurchase class represents a stock purchase.
 */

public class StockPurchase
{
   private Stock stock;  // The stock that was purchased
   private int shares;   // Number of shares owned

   /**
    * The constructor accepts arguments for the      
    * stock and number of shares. 
    */

   public StockPurchase(Stock stockObject, int numShares)
   {
      // Create a copy of the object referenced by
      // stockObject.
      stock = new Stock(stockObject);
      shares = numShares;
   }
   
   /**
    * getStock method
    */
   
   public Stock getStock()
   {
      // Return a copy of the object referenced by stock.
      return new Stock(stock);
   }
   
   /**
    * getShares method
    */
   
   public int getShares()
   {
      return shares;
   }

   /**
    * The getCost method returns the cost of the     
    * stock purchase.
    */
   
   public double getCost()
   {
      return shares * stock.getSharePrice();
   }
}

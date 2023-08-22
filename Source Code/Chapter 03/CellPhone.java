/**
 *  The CellPhone class represents a cell phone.
 */

public class CellPhone
{
   // Fields
   private String manufact;    // Manufacturer
   private String model;       // Model
   private double retailPrice; // Retail price
   
   /**
    *  The constructor accepts arguments for
    *  the phone's manufacturer, model number,
    *  and retail price.
    */
   
   public CellPhone(String man, String mod, double price)
   {
      manufact = man;
      model = mod;
      retailPrice = price;
   }
   
   /**
    *  The setManufact method accepts an argument for
    *  the phone's manufacturer name.
    */
   
   public void setManufact(String man)
   {
      manufact = man;
   }

   /**
    *  The setModelNumber method accepts an argument
    *  for the phone's model number.
    */
      
   public void setMod(String mod)
   {
      model = mod;
   }
   
   /**
    *  The setRetailPrice method accepts an argument
    *  for the phone's retail price.
    */
      
   public void setRetailPrice(double price)
   {
      retailPrice = price;
   }

   /**
    * The getManufact method returns the name of
    * the phone's manufacturer.
    */
   
   public String getManufact()
   {
      return manufact;
   }
   
   /**
    *  The getModel method returns the phone's
    *  model number.
    */
   
   public String getModel()
   {
      return model;
   }
   
   /**
    *  The getRetailPrice method returns the
    *  phone's retail price.
    */
   
   public double getRetailPrice()
   {
      return retailPrice;
   }
}
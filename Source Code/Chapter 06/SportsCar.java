/**
 * SportsCar class
 */

public class SportsCar
{
   private CarType make;    // The car's make
   private CarColor color;  // The car's color
   private double price;    // The car's price
   
   /**
    * The constructor accepts arguments for the      
    * car's make, color, and price.
    */
   
   public SportsCar(CarType aMake, CarColor aColor,
                    double aPrice)
   {
      make = aMake;
      color = aColor;
      price = aPrice;
   }

   /**
    * getMake method 
    */
   
   public CarType getMake()
   {
      return make;
   }

   /**
    * getColor method
    */
   
   public CarColor getColor()
   {
      return color;
   }
   
   /**
    * getPrice method
    */
   
   public double getPrice()
   {
      return price;
   }
   
   /**
    *  toString method 
    */
   
   public String toString()
   {
      // Create a string representing the object.
      String str = String.format("Make: %s\n" +
                                 "Color: %s\n" +
                                 "Price: $%,.2f",
                                 make, color, price);      
      // Return the string.
      return str;
   }
}
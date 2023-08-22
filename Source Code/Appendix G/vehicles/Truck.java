package vehicles;

/**
 * This class is in the vehicles package. 
 */

public class Truck
{
   private double mpg;  // Fuel economy in miles-per-gallon
   private double tons; // Hauling capacity in tons

   /**
    * Constructor
    */

   public Truck(double mpg, double tons)
   {
      this.mpg = mpg;
      this.tons = tons;
   }

   /**
    * toString method
    */

   public String toString()
   {
      return "Fuel economy: " + mpg + " miles per gallon"
           + "\nHauling capacity: " + tons + " tons";
   }
}
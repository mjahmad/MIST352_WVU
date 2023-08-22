package vehicles;

/**
 * This class is in the vehicles package.          
 */

public class Car
{
   private int passengers;   // Number of passengers
   private double topSpeed;  // Top speed in miles per hour

   /**
    *  Constructor                                
    */

   public Car(int passengers, int topSpeed)
   {
      this.passengers = passengers;
      this.topSpeed = topSpeed;
   }

   /**
    *  toString method
    */

   public String toString()
   {
      return "Passengers: " + passengers
           + "\nTop Speed: " + topSpeed + " miles per hour";
   }
}

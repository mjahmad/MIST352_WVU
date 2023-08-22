/**
 * This class demonstrates static methods.
 */

public class Metric
{
   /**
    * The milesToKilometers method converts miles      
    * to kilometers. A distance in miles should be     
    * passed into the miles parameter. The method      
    * returns the equivalent distance in kilometers.
    */

   public static double milesToKilometers(double miles)
   {
      return miles * 1.609;
   }

   /**
    * The kilometersToMiles method converts kilometers 
    * to miles. A distance in kilometers should be     
    * passed into the kilometers parameter. The method 
    * returns the equivalent distance in miles.
    */

   public static double kilometersToMiles(double kilometers)
   {
      return kilometers / 1.609;
   }
}
/**
 * The SpeedConverter class converts speeds
 * in KPH (kilometers per hour) to MPH (miles
 * per hour).
 */
 
public class SpeedConverter
{
   // Factor to convert MPH to KPH
   final double CONVERSION_FACTOR = 0.6214;
   
   /**
    * The getMPH method accepts a speed in
    * KPH as an argument, and returns that
    * speed converted to MPH.
    */
    
   public double getMPH(double kph)
   {
      return kph * CONVERSION_FACTOR;
   }
}
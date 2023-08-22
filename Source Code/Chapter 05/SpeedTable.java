/**
 *  This program displays a table of speeds in
 *  kph converted to mph.
 */

public class SpeedTable
{
   public static void main(String[] args)
   {
      // Constants
      final int STARTING_KPH = 60; // Starting speed
      final int MAX_KPH = 130;     // Maximum speed
      final int INCREMENT = 10;    // Speed increment
      
      // Variables
      int kph;       // To hold the speed in kph
      double mph;    // To hold the speed in mph
      
      // Create an instance of the SpeedConverter class.
      SpeedConverter converter = new SpeedConverter();
      
      // Display the table headings.
      System.out.println("KPH\t\tMPH");
      System.out.println("----------------");
      
      // Display the speeds.
      for (kph = STARTING_KPH; kph <= MAX_KPH; kph += INCREMENT)
      {
         // Get the mph.
         mph = converter.getMPH(kph);
         
         // Display the speeds in kph and mph.
         System.out.printf("%d\t\t%.1f\n", kph, mph);
      }
   }
}
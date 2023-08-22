import java.util.Scanner;

/**
 * This program demonstrates the Metric class.
 */

public class MetricDemo
{
   public static void main(String[] args)
   {
      double miles,  // A distance in miles
             kilos;  // A distance in kilometers
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Get a distance in miles.
      System.out.print("Enter a distance in miles: ");
      miles = keyboard.nextDouble();

      // Convert the distance to kilometers.
      kilos = Metric.milesToKilometers(miles);
      System.out.printf("%.2f miles equals %.2f kilometers.\n",
                        miles, kilos);

      // Get a distance in kilometers.
      System.out.print("Enter a distance in kilometers: ");
      kilos = keyboard.nextDouble();

      // Convert the distance to kilometers.
      miles = Metric.kilometersToMiles(kilos);
      System.out.printf("%.2f kilometers equals %.2f miles.\n",
                        kilos, miles);
   }
}

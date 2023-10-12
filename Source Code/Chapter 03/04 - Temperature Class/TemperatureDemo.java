import java.util.Scanner;

/**
 * Chapter 3
 * Programming Challenge 4: Temperature Class
 * This program demonstrates the Temperature class. 
 */
 
public class TemperatureDemo
{
   public static void main(String[] args)
   {
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get the Fahrenheit temperature.
      System.out.print("Enter the Fahrenheit temperature: ");
      
      // Create an instance of the Temperature class.
      Temperature temperature = new Temperature(keyboard.nextDouble());
      
      // Display the temperature in Celsius and Kelvin.
      System.out.printf("Celsius: %.2f\n", temperature.getCelsius());
      System.out.printf("Kelvin: %.2f\n", temperature.getKelvin());
   }     
}
import java.util.Scanner;
import java.text.DecimalFormat;

/**
 * This program demonstrates the Character class's  
 * toUpperCase method. 
 */

public class CircleArea
{
   public static void main(String[] args)
   {
      double radius,    // To hold a radius
             area;      // To hold an area
      String inputLine; // To hold a line of input
      char choice;      // To hold the user's choice
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Create a DecimalFormat object for output formatting.
      DecimalFormat formatter = new DecimalFormat("0.00");
      
      // Process the data for one or more circles.
      do
      {
         // Get the circle's radius.
         System.out.print("Enter the circle's radius: ");
         radius = keyboard.nextDouble();

         // Calculate and display the area.
         area = Math.PI * radius * radius;
         System.out.println("The area is " + 
                            formatter.format(area));

         // Repeat this?
         System.out.print("Do you want to do this " +
                          "again? (Y or N) ");
         keyboard.nextLine(); // Consume the remaining newline.
         inputLine = keyboard.nextLine();
         choice = inputLine.charAt(0); // Get the first char.

      } while (Character.toUpperCase(choice) == 'Y');
   }
}

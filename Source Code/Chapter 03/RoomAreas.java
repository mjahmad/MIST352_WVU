import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program creates three instances of the
 * Rectangle class. 
 */

public class RoomAreas
{
   public static void main(String[] args)
   {
      double number,     // To hold numeric input
             totalArea;  // The total area of all rooms

      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Create three Rectangle objects.
      Rectangle kitchen = new Rectangle();
      Rectangle bedroom = new Rectangle();
      Rectangle den = new Rectangle();

      // Get and store the dimensions of the kitchen.
      System.out.print("What is the kitchen's length? ");
      number = keyboard.nextDouble();
      kitchen.setLength(number);
      System.out.print("What is the kitchen's width? ");
      number = keyboard.nextDouble();
      kitchen.setWidth(number);

      // Get and store the dimensions of the bedroom.
      System.out.print("What is the bedroom's length? ");
      number = keyboard.nextDouble();
      bedroom.setLength(number);
      System.out.print("What is the bedroom's width? ");
      number = keyboard.nextDouble();
      bedroom.setWidth(number);

      // Get and store the dimensions of the den.
      System.out.print("What is the den's length? ");
      number = keyboard.nextDouble();
      den.setLength(number);
      System.out.print("What is the den's width? ");
      number = keyboard.nextDouble();
      den.setWidth(number);

      // Calculate the total area of the rooms.
      totalArea = kitchen.getArea() + bedroom.getArea()
                  + den.getArea();

      // Display the total area of the rooms.
      System.out.println("The total area of the rooms is "
                         + totalArea);
   }
}

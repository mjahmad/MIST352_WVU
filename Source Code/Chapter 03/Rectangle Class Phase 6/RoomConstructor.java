import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program creates three instances of the Rectangle
 * class and passes arguments to the constructor.
 */

public class RoomConstructor
{
   public static void main(String [] args)
   {
      double roomLength,   // To hold a room's length
             roomWidth,    // To hold a room's width
             totalArea;    // To hold the total area
             
      // Declare Rectangle variables to reference
      // objects for the kitchen, bedroom, and den.
      Rectangle kitchen, bedroom, den;

      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Get and store the dimensions of the kitchen.
      System.out.print("What is the kitchen's length? ");
      roomLength = keyboard.nextDouble();
      System.out.print("What is the kitchen's width? ");
      roomWidth = keyboard.nextDouble();
      kitchen = new Rectangle(roomLength, roomWidth);

      // Get and store the dimensions of the bedroom.
      System.out.print("What is the bedroom's length? ");
      roomLength = keyboard.nextDouble();
      System.out.print("What is the bedroom's width? ");
      roomWidth = keyboard.nextDouble();
      bedroom = new Rectangle(roomLength, roomWidth);

      // Get and store the dimensions of the den.
      System.out.print("What is the den's length? ");
      roomLength = keyboard.nextDouble();
      System.out.print("What is the den's width? ");
      roomWidth = keyboard.nextDouble();
      den = new Rectangle(roomLength, roomWidth);

      // Calculate the total area of the rooms.
      totalArea = kitchen.getArea() + bedroom.getArea() +
                  den.getArea();

      // Display the total area of the rooms.
      System.out.println("The total area of the rooms is " +
                         totalArea);
   }
}

/**
 * This program demonstrates the Rectangle
 * class's getPerimeter method, which uses
 * a local variable.
 */

public class LawnSize
{
     public static void main(String [] args)
     {
          Rectangle lawn = new Rectangle();
          double length, width;

          // Get the lawn's length.
          System.out.print("What is the length of your "
                           + "lawn, in feet? ");
          length = Keyboard.readDouble();
          lawn.setLength(length);

          // Get the lawn's width.
          System.out.print("What is the width of your "
                           + "lawn, in feet? ");
          width = Keyboard.readDouble();
          lawn.setWidth(width);

          // Display the length around the lawn.
          System.out.println("It is " + lawn.getPerimeter()
                             + " feet around your lawn.");
     }
}

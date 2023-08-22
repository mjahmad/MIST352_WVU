/**
 * This program demonstrates the Rectangle class's
 * setLength, setWidth, getLength, getWidth, and
 * getArea methods.
 */

public class RectangleDemo
{
   public static void main(String[] args)
   {
      // Create a Rectangle object.
      Rectangle box = new Rectangle();

      // Set the length to 10 and width to 20.
      box.setLength(10.0);
      box.setWidth(20.0);
      
      // Display the length, width, and area.
      System.out.println("The box's length is " +
                         box.getLength());
      System.out.println("The box's width is " +
                         box.getWidth());
      System.out.println("The box's area is " +
                         box.getArea());
   }
}

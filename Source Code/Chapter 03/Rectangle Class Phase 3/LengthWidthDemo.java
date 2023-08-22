/**
 * This program demonstrates the Rectangle class's
 * setLength, setWidth, getLength, and getWidth methods.
 */

public class LengthWidthDemo
{
   public static void main(String[] args)
   {
      Rectangle box = new Rectangle();

      box.setLength(10.0);
      box.setWidth(20.0);
      System.out.println("The box's length is " +
                         box.getLength());
      System.out.println("The box's width is " +
                         box.getWidth());
   }
}

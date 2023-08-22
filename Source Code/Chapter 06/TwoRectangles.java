/**
 * This program demonstrates both of the Rectangle
 * class's constructors.
 */

public class TwoRectangles
{
   public static void main(String[] args)
   {
      // Declare two Rectangle variables, but don't
      // create instances of the class yet.

      Rectangle box1, box2;

      // Create a Rectangle object and use the
      // first constructor.

      box1 = new Rectangle();
      System.out.println("The box1 object's length " +
                         "and width are " +
                         box1.getLength() + " and " +
                         box1.getWidth());

      // Create another Rectangle object and use
      // the second constructor.

      box2 = new Rectangle(5.0, 10.0);
      System.out.println("The box2 object's length " +
                         "and width are " +
                         box2.getLength() + " and " +
                         box2.getWidth());
   }
}

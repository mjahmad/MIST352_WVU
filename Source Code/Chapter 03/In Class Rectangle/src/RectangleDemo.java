/**
 * This program demonstrates the Rectangle class's
 * setLength method.
 */

public class RectangleDemo
{
   public static void main(String[] args)
   {
      Rectangle myBox = new Rectangle();
      myBox.setLength(9.0);
      myBox.setWidth(91.0);
      
      Rectangle yourBox = new Rectangle(10.5,5.5);

//      System.out.println("Done.");
//      System.out.println(box.ViewLength());
//      System.out.println(box.ViewWidth());
 //     System.out.println(box.calculateArea());
      myBox.viewRectangleInfo();
      yourBox.viewRectangleInfo();


   }
}


/**
 * This program demonstrates the methods in the
 * SuperClass3 and SubClass3 classes.
 */

public class ShowValueDemo
{
   public static void main(String[] args)
   {
      SubClass3 myObject = new SubClass3();

      myObject.showValue(10);       // Pass an int.
      myObject.showValue(1.2);      // Pass a double.
      myObject.showValue("Hello");  // Pass a String.
   }
}

public class SubClass3 extends SuperClass3
{
   /**
    *  This method overrides one of the superclass methods.
    */

   @Override
   public void showValue(int arg)
   {
      System.out.println("SUBCLASS: The int argument was " + arg);
   }

   /**
    *  This method overloads the superclass methods.
    */

   public void showValue(double arg)
   {
      System.out.println("SUBCLASS: The double argument was " + arg);
   }
}

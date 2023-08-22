/**
 * This program creates a FullName object, and then calls the  
 * object's getLength method before values are established for 
 * its reference fields. As a result, this program will crash.
 */

public class NameTester
{
   public static void main(String[] args)
   {
      // Create a FullName object.
      FullName name = new FullName();
      
      // Display the length of the name.
      System.out.println(name.getLength());
   }
}
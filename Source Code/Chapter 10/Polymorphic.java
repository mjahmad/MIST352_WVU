import java.io.*;

/**
 * This program demonstrates how the Integer.parseInt      
 * can be retireved from an exception object.
 */

public class Polymorphic
{
     public static void main(String[] args)
     {
         String str = "abcde";
         int number;

         try
         {
              number = Integer.parseInt(str);
         }
         catch (Exception e)
         { 
              System.out.println("Error: Cannot convert "
                                 + e.getMessage()
                                 + " to an integer.");
         }
     }
}


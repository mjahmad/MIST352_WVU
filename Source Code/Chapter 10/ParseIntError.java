/**
 *  This program demonstrates how the Integer.parseInt
 *  method throws an exception.   
 */

public class ParseIntError
{
   public static void main(String[] args)
   {
      String str = "abcde";
      int number;

      try
      {
         // Try to convert str to an int.
         number = Integer.parseInt(str);
      }
      catch (NumberFormatException e)
      { 
         System.out.println("Conversion error: " +
                            e.getMessage());
      }
   }
}
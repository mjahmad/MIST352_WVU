import java.text.DecimalFormat; // Needed for DecimalFormat

/**
 * This program demonstrates the DecimalFormat class.
 */

public class Format4
{
   public static void main(String[] args)
   {
      double number1 = 0.12,
             number2 = 0.05;
             
      // Create a DecimalFormat object.    
      DecimalFormat formatter = new DecimalFormat("#0%");

      // Format and display the variables.    
      System.out.println(formatter.format(number1));
      System.out.println(formatter.format(number2));
   }
}

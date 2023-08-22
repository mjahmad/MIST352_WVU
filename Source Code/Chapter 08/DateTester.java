/**
 * This program demonstrates the DateComponent class.
 */

public class DateTester
{
   public static void main(String[] args)
   {
      // Create a string containing a date.
      String date = "10/23/2011";
      
      // Create a DateComponent object, initialized
      // with the date.
      DateComponent dc = new DateComponent(date);

      // Display the components of the date.
      System.out.println("Here's the date: " + date);
      System.out.println("The month is " + dc.getMonth());
      System.out.println("The day is " + dc.getDay());
      System.out.println("The year is " + dc.getYear());
   }
}

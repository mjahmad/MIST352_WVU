import java.util.StringTokenizer;

/**
 * The DateComponent class extracts the month, day, and
 * year from a string containing a date.
 */

public class DateComponent
{
   private String month, // To hold a month
                  day,   // To hold a day
                  year;  // To hold a year

   /**
    * The constructor accepts a string containing a date  
    * in the form MONTH/DAY/YEAR. It extracts the month,  
    * day, and year from the string.
    */

   public DateComponent(String dateStr)
   {
      // Create a StringTokenizer object. The string to
      // tokenize is dateStr, and "/" is the delimiter.
      StringTokenizer strTokenizer = 
                 new StringTokenizer(dateStr, "/");

      // Get the first token, which is the month.
      month = strTokenizer.nextToken();
      
      // Get the next token, which is the day.
      day = strTokenizer.nextToken();
      
      // Get the next token, which is the year.
      year = strTokenizer.nextToken();      
   }

   /**
    * The getMonth method returns the month field. 
    */

   public String getMonth()
   {
      return month;
   }

   /**
    * The getDay method returns the day field.
    */

   public String getDay()
   {
      return day;
   }

   /**
    * The getYear method returns the year field.
    */

   public String getYear()
   {
      return year;
   }
}
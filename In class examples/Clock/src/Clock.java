import java.text.DecimalFormat;

/**
 * This program uses nested loops to simulate 
 * a clock.
 */

public class Clock
{
   public static void main(String[] args)
   {
      DecimalFormat fmt = new DecimalFormat("00");

      for (int hours = 1; hours <= 2; hours++)
      {
          for (int minutes = 0; minutes <= 59; minutes++)
          {
             for (int seconds = 0; seconds <= 59; seconds++)
             {
                System.out.print(fmt.format(hours) + ":"); 
                System.out.print(fmt.format(minutes) + ":"); 
                System.out.println(fmt.format(seconds));
              }
          }
       }
   }
}

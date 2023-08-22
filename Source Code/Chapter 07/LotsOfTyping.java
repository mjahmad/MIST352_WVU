/**
 * This program shows initial values being assigned 
 * to the individual elements of an array.
 */

public class LotsOfTyping
{
     public static void main(String[] args)
     {
          int[] days = new int[12];

          days[0] = 31;  // January
          days[1] = 28;  // February
          days[2] = 31;  // March
          days[3] = 30;  // April
          days[4] = 31;  // May
          days[5] = 30;  // June
          days[6] = 31;  // July
          days[7] = 31;  // August
          days[8] = 30;  // September
          days[9] = 31;  // October
          days[10] = 30; // November
          days[11] = 31; // December

          for (int i = 0; i < 12; i++)
          {
               System.out.println("Month " + (i + 1) + " has "
                                  + days[i] + " days.");
          }
     }
}

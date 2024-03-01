import java.text.DecimalFormat;

/**
 * This program uses nested loops to simulate 
 * a clock.
 */

public class Clock
{
   public static void main(String[] args)
   {
	   for (int intHours=0; intHours<=12; intHours++)
	   {
		   System.out.println("================================");

		   //System.out.println("hours\t"+intHours);
		   System.out.println("================================");

		   for (int intMinutes =0; intMinutes <60; intMinutes++)
		   {
			   //System.out.println("minutes\t"+intMinutes);
			   
			   for (int intSeconds=0;intSeconds<60;intSeconds++)
			   {
				   //System.out.println("second\t"+intSeconds);
				   
				   System.out.printf("\n%d:%d:%d\n",intHours,intMinutes,intSeconds);

				   
			   }
			   

		   }
		   
	   }
	   
	   
	   
	   
	   

     
   }
}

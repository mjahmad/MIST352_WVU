import java.util.Scanner;

/**
 * This program uses the Pay class to determine an   
 * employee's weekly pay. It can process hourly paid 
 * or salaried employees.
 */

public class WeeklyPay
{
   public static void main(String[] args)
   {
      String selection;  // The user's selection, H or S
      int hours;         // The number of hours worked
      double hourlyRate; // The hourly pay rate
      double yearly;     // The yearly salary
      
      // Create a Sanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Determine whether the employee is hourly paid or salaried.
      System.out.println("Do you want to calculate the " +
                         "weekly salary of an hourly-paid");
      System.out.println("or a salaried employee?");
      System.out.print("Enter H for hourly or S for salaried: ");
      selection = keyboard.nextLine();

      // Determine and display the weekly pay.
      switch(selection.charAt(0))
      {
         case 'H':
         case 'h': 
            System.out.print("How many hours were worked? ");
            hours = keyboard.nextInt();
            System.out.print("What is the hourly pay rate? ");
            hourlyRate = keyboard.nextDouble();
            System.out.printf("The weekly gross pay is $%,.2f\n",
                              Pay.getWeeklyPay(hours, hourlyRate));
            break;

         case 'S':
         case 's': 
            System.out.print("What is the annual salary? ");
            yearly = keyboard.nextDouble();
            System.out.printf("The weekly gross pay is $%,.2f\n",
                              Pay.getWeeklyPay(yearly));
            break;

         default:
            System.out.println("Invalid selection.");
      }
   }
}

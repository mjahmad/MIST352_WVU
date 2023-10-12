import java.util.Scanner;

/**
 * Chapter 3
 * Programming Challenge 6: Payroll Class
 * This program demonstrates the Payroll class. 
 */

public class PayrollDemo
{
   public static void main(String[] args)
   {
      // Variables for input
      String name;         // An employee's name
      int id;              // An employee's ID number
      double payRate;      // An employee's pay rate
      double hoursWorked;  // The number of hours worked
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get the employee's name.
      System.out.print("Enter the employee's name: ");
      name = keyboard.nextLine();
      
      // Get the employee's ID number.
      System.out.print("Enter the employee's ID number: ");
      id = keyboard.nextInt();

      // Get the employee's pay rate.
      System.out.print("Enter the employee's hourly pay rate: ");
      payRate = keyboard.nextDouble();
      
      // Get the number of hours worked by the employee.
      System.out.print("Enter the number of hours worked " +
                       " by the employee: ");
      hoursWorked = keyboard.nextDouble();

      // Create a Payroll object and store the data in it.
      Payroll worker = new Payroll(name, id);
      worker.setPayRate(payRate);
      worker.setHoursWorked(hoursWorked);
      
      // Display the employee's payroll data.
      System.out.println("\nEmployee Payroll Data");
      System.out.println("Name: " + worker.getName());
      System.out.println("ID Number: " + worker.getIdNumber());
      System.out.println("Hourly pay rate: " + worker.getPayRate());
      System.out.println("Hours worked: " + worker.getHoursWorked());
      System.out.println("Gross pay: $" + worker.getGrossPay());
   }
}


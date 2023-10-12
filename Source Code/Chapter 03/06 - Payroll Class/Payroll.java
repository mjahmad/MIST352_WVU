/**
 * Chapter 3
 * Programming Challenge 6: Payroll Class
 * The Payroll class stores payroll data. 
 */

public class Payroll
{
   private String name;          // Employee name
   private int idNumber;         // ID number
   private double payRate;       // Hourly pay rate
   private double hoursWorked;   // Number of hours worked

   /**
    * The constructor initializes an object with the
    * employee's name and ID number.
    */

   public Payroll(String n, int i)
   {
      name = n;
      idNumber = i;
   }

   /**
    * The setName sets the employee's name.
    */

   public void setName(String n)
   {
      name = n;
   }

   /**
    * The setIdNumber sets the employee's ID number.
    */
   
   public void setIdNumber(int i)
   {
      idNumber = i;
   }

   /**
    * The setPayRate sets the employee's pay rate.
    */
   
   public void setPayRate(double p)
   {
      payRate = p;
   }

   /**
    * The setHoursWorked sets the number of hours worked.
    */

   public void setHoursWorked(double h)
   {
      hoursWorked = h;
   }

   /**
    * The getName returns the employee's name.
    */

   public String getName()
   {
      return name;
   }

   /**
    * The getIdNumber returns the employee's ID number.
    */
   
   public int getIdNumber()
   {
      return idNumber;
   }

   /**
    * The getPayRate returns the employee's pay rate.
    */

   public double getPayRate()
   {
      return payRate;
   }

   /**
    * The getHoursWorked returns the hours worked by the
    * employee.
    */


   public double getHoursWorked()
   {
      return hoursWorked;
   }

   /**
    * The getGrossPay returns the employee's gross pay.
    */

   public double getGrossPay()
   {
      return hoursWorked * payRate;
   }
}

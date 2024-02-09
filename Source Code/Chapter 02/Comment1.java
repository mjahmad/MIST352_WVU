// PROGRAM: Comment1.java
// Written by Herbert Dorfmann
// This program calculates company payroll
// Last modification: 8/30/2005

public class Comment1
{
   public static void main(String[] args)       
   {
      double payRate =0.1;         // Holds the hourly pay rate
      double hours=10;           // Holds the hours worked
      int employeeNumber =101;     // Holds the employee number
      String name="MJ";
      
      
      System.out.println("The payrate is "+payRate + " The hours is"+hours +" emp numnber is "+employeeNumber);

      System.out.printf("The name is %s The payrate is %.2f The hours is %.2f emp numnber is %d",name,payRate,hours,employeeNumber);
      // The Remainder of This Program is Omitted.
   }
}


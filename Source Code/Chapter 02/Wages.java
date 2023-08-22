// This program calculates hourly wages plus overtime.

public class Wages
{
   public static void main(String[] args)       
   {
      double regularWages,       // Regular wages.
             basePay = 25,       // Base pay rate. 
             regularHours = 40,  // Hours worked less overtime.
             overtimeWages,      // Overtime wages
             overtimePay = 37.5, // Overtime pay rate
             overtimeHours = 10, // Overtime hours worked
             totalWages;         // Total wages
   
      // Calculate the regular wages.
      regularWages = basePay * regularHours;
      
      // Calculate the overtime wages.
      overtimeWages = overtimePay * overtimeHours;
      
      // Calculate the total wages.
      totalWages = regularWages + overtimeWages;
      
      // Display the total wages.
      System.out.print("Wages for this week are $");
      System.out.println(totalWages);
   }
}  

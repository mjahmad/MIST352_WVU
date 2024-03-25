/**
 * Chapter 3
 * Programming Challenge 1: Employee Class
 * This program demonstrates the Employee class.
 */

public class EmployeeDemo
{
   public static void main(String[] args)
   {
      // Create the first employee. Use the
      // no-arg constructor.
      Employee employee1 = new Employee();
      employee1.setName("Susan Meyers");
      employee1.setIdNumber(47899);
      employee1.setDepartment("Accounting");
      employee1.setPosition("Vice President");
      
      // Create the second employee. Use the
      // constructor that accepts arguments for
      // all  of the fields.
      Employee employee2 = new Employee("Mark Jones", 39119,
                                        "IT", "Programmer");

      // Create the third employee. Use the constructor
      // that accepts the name and ID number.
      Employee employee3 = new Employee("Joy Rogers", 81774);
      employee3.setDepartment("Manufacturing");
      employee3.setPosition("Engineer");
   
      employee1.displayEmployeeInfo();
      employee2.displayEmployeeInfo();
      employee3.displayEmployeeInfo();

   }
   
}


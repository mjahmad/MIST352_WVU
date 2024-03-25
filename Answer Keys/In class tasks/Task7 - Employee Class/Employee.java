import javax.swing.JOptionPane;

/**
 * Chapter 3
 * Programming Challenge 1: Employee Class
 * The Employee class stores data about an employee.
 */

public class Employee
{
   // Fields
   private String name;       // Employee's name
   private int idNumber;      // ID number
   private String department; // Employee's department
   private String position;   // Job title
   
   /**
    * This constructor initializes the name, 
    * department, and position fields with an
    * empty string, and the idNum field with 0.
    */
   
   public Employee()
   {
      name = "";
      idNumber = 0;
      department = "";
      position = "";
   }

   /**
    * This constructor initializes the name, idNum
    * department, and position fields.
    */
   
   public Employee(String n, int id,
                   String dept, String pos)
   {
      name = n;
      idNumber = id;
      department = dept;
      position = pos;
   }

   /**
    * This constructor initializes the name and idNum
    * fields. The department and position fields are
    * initialized with an empty string.
    */
   
   public Employee(String n, int id)
   {
      name = n;
      idNumber = id;
      department = "";
      position = "";
   }

   /**
    * The setName method accepts an argument
    * which is stored in the name field.
    */

   public void setName(String n)
   {
      name = n;
   }

   /**
    * The setIdNumber method accepts an argument
    * which is stored in the idNumber field.
    */

   public void setIdNumber(int num)
   {
      idNumber = num;
   }  

   /**
    * The setDepartment method accepts an argument
    * which is stored in the department field.
    */

   public void setDepartment(String d)
   {
      department = d;
   }
   
   /**
    * The setPosition method accepts an argument
    * which is stored in the position field
    */

   public void setPosition(String p)
   {
      position = p;
   }
   
   /**
    * The getName method returns the value in
    * the name field.
    */

   public String getName()
   {
      return name;
   }

   /**
    * The getIdNumber method returns the value in
    * the idNumber field.
    */

   public int getIdNumber()
   {
      return idNumber;
   }

   /**
    * The getDepartment method returns the value in
    * the department field.
    */

   public String getDepartment()
   {
      return department;
   }
   
   /**
    * The getPosition method returns the value in
    * the position field.
    */

   public String getPosition()
   {
      return position;
   }
   
   /**
    * The displayEmployeeMethod prints out the employee info as a GUI.
    */
   public void displayEmployeeInfo()
   {
	   String strEmployeeData = String.format("The employee %s has ID %d is a %s in the %s department.", this.name,this.idNumber, this.position, this.department);
	   JOptionPane.showMessageDialog(null, strEmployeeData);
   }
   
}

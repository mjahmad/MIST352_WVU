/**
 * This class stores information about an instructor.
 */

public class Instructor
{
   private String lastName,     // Last name   
                  firstName,    // First name
                  officeNumber; // Office number

   /**
    * This constructor accepts arguments for the   
    * last name, first name, and office number.
    */

   public Instructor(String lname, String fname,
                     String office)
   {
      lastName = lname;
      firstName = fname;
      officeNumber = office;
   }

   /**
    * Copy constructor
    */
   
   public Instructor(Instructor object2)
   {
      lastName = object2.lastName;
      firstName = object2.firstName;
      officeNumber = object2.officeNumber;
   }

   /**
    * The set method sets each field. 
    */
   
   public void set(String lname, String fname,
                   String office)
   {
      lastName = lname;
      firstName = fname;
      officeNumber = office;
   }
   
   /**
    * The toString method returns a string containing 
    * the instructor information.
    */

   public String toString()
   {
      // Create a string representing the object.
      String str = "Last Name: " + lastName +
                   "\nFirst Name: " + firstName +
                   "\nOffice Number: " + officeNumber;

      // Return the string.
      return str;
   }
}
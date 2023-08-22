/**
 *  The Student class is an abstract class that holds general  
 *  data about a student. Classes representing specific types
 *  of students should inherit from this class.
 */

public abstract class Student
{
   private String name;      // Student name
   private String idNumber;  // Student ID
   private int yearAdmitted; // Year student was admitted

   /**
    *  The Constructor accepts as arguments the student's
    *  name, ID number, and the year admitted.
    */

   public Student(String n, String id, int year)
   {
      name = n;
      idNumber = id;
      yearAdmitted = year;
   }

   /**
    *  toString method 
    */

   public String toString()
   {
      String str;

      str = "Name: " + name +
            "\nID Number: " + idNumber +
            "\nYear Admitted: " + yearAdmitted;

      return str;
   }

   /**
    *  The getRemainingHours method is abstract.   
    *  It must be overridden in a subclass. 
    */

   public abstract int getRemainingHours();
}

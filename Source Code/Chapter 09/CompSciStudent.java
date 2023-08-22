/**
 *  This class holds data for a computer science student.
 */

public class CompSciStudent extends Student
{
   // Constants for the math, computer science and
   // general education hours required for graduation.
   private final int MATH_HOURS = 20,
                     CS_HOURS = 40,
                     GEN_ED_HOURS = 60;

   private int mathHours,  // Math hours taken
               csHours,    // Comp. sci. hours taken
               genEdHours; // General ed hours taken

   /**
    *  The Constructor accepts as arguments the student's    
    *  name, ID number, and the year admitted.
    */

   public CompSciStudent(String n, String id, int year)
   {
      super(n, id, year);
   }

   /**
    *  The setMathHours method accepts a value for 
    *  the number of math hours taken.             
    */

   public void setMathHours(int math)
   {
      mathHours = math;
   }

   /**
    *  The setCsHours method accepts a value for   
    *  the number of computer science hours taken.
    */

   public void setCsHours(int cs)
   {
      csHours = cs;
   }

   /**
    *  The setGenEdHours method accepts a value for 
    *  the number of general education hours taken.
    */

   public void setGenEdHours(int genEd)
   {
      genEdHours = genEd;
   }

   /**
    *  toString method 
    */

   @Override
   public String toString()
   {
      String str; // To hold a string

      // Create a string representing this computer
      // science student's hours taken.
      str = super.toString() +
        "\nMajor: Computer Science" +
        "\nMath Hours Taken: " + mathHours +
        "\nComputer Science Hours Taken: " + csHours +
        "\nGeneral Ed Hours Taken: " + genEdHours;

      // Return the string.
      return str;
   }

   /**
    *  The getRemainingHours method returns the    
    *  the number of hours remaining to be taken.
    */

   @Override
   public int getRemainingHours()
   {
      int reqHours,       // Total required hours
          remainingHours; // Remaining hours

      // Calculate the total required hours.
      reqHours = MATH_HOURS + CS_HOURS + GEN_ED_HOURS;
      
      // Calculate the remaining hours.
      remainingHours = reqHours - (mathHours + csHours +
                       genEdHours);
                         
      // Return the remaining hours.
      return remainingHours;
   }
}
/**
 * This class stores information about a course.
 */

public class Course
{
   private String courseName;      // Name of the course
   private Instructor instructor;  // The instructor
   private TextBook textBook;      // The textbook
   
   /**
    * This constructor accepts arguments for the   
    * course name, instructor, and textbook.
    */

   public Course(String name, Instructor instr,
                 TextBook text)
   {
      // Assign the courseName.
      courseName = name;
      
      // Create a new Instructor object, passing
      // instr as an argument to the copy constructor.
      instructor = new Instructor(instr);

      // Create a new TextBook object, passing
      // text as an argument to the copy constructor.
      textBook = new TextBook(text);
   }

   /**
    * getName method
    */
   
   public String getName()
   {
      return courseName;
   }
   
   /**
    * getInstructor method
    */
   
   public Instructor getInstructor()
   {
      // Return a copy of the instructor object.
      return new Instructor(instructor);
   }

   /**
    * getTextBook method 
    */
   
   public TextBook getTextBook()
   {
      // Return a copy of the textBook object.
      return new TextBook(textBook);
   }
   
   /**
    * The toString method returns a string containing 
    * the course information.
    */

   public String toString()
   {
      // Create a string representing the object.
      String str = "Course name: " + courseName +
                   "\nInstructor Information:\n" +
                   instructor +
                   "\nTextbook Information:\n" +
                   textBook;

      // Return the string.
      return str;
   }
}
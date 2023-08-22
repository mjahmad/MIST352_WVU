import java.util.Scanner;

/**
 * This program demonstrates the CurvedActivity class,
 * which inherits from the GradedActivity class.
 */

public class CurvedActivityDemo
{
   public static void main(String[] args)
   {
      double score,        // Raw score
           curvePercent;   // Curve percentage
           
      // Create a Scanner object for keybaord input.
      Scanner keyboard = new Scanner(System.in);

      // Get the unadjusted exam score.
      System.out.print("Enter the student's raw " +
                       "numeric score: ");
      score = keyboard.nextDouble();

      // Get the curve percentage.
      System.out.print("Enter the curve percentage: ");
      curvePercent = keyboard.nextDouble();

      // Create a CurvedActivity object.
      CurvedActivity curvedExam =
                   new CurvedActivity(curvePercent);

      // Set the exam score.
      curvedExam.setScore(score);

      // Display the test results.
      System.out.println("The raw score is " +
                         curvedExam.getRawScore() +
                         " points.");
      System.out.println("The curved score is " +
                         curvedExam.getScore());
      System.out.println("The exam grade is " +
                         curvedExam.getGrade());
   }
}

import java.util.Scanner;

/**
 *  This program demonstrates the GradedActivity class.
 */

public class GradeDemo
{
   public static void main(String[] args)
   {
      double testScore;  // To hold a test score
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);
      
      // Create a GradedActivity object.
      GradedActivity grade = new GradedActivity();

      // Get a test score from the user.
      System.out.print("Enter a numeric test score: ");
      testScore = keyboard.nextDouble();
      
      // Set the GradedActivity object's score.
      grade.setScore(testScore);
      
      // Display the letter grade for that score.
      System.out.println("The grade for that test is "
                         + grade.getGrade());
   }
}


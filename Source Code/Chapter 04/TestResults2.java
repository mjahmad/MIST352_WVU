import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program uses the TestGrade class to determine
 * a letter grade for a numeric test score. 
 */

public class TestResults2
{
   public static void main(String[] args)
   {
      int testScore;     // To hold a test score
      char letterGrade;  // To hold a letter grade

      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);

      // Get the numeric test score.
      System.out.print("Enter your numeric test score and "
                     + "I will tell you the grade: ");
      testScore = keyboard.nextInt();

      // Create a TestGrade object with the numeric score.
      TestGrade2 test = new TestGrade2(testScore);

      // Get the letter grade.
      letterGrade = test.getLetterGrade();

      // Display the grade.
      System.out.print("Your grade is " 
		               + test.getLetterGrade());
   }
}

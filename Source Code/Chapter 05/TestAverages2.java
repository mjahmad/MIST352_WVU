import java.util.Scanner;

/**
 * This program demonstrates a user-controlled loop.
 */

public class TestAverages2
{
   public static void main(String[] args)
   {
      int numStudents;   // Number of students
      int numTests;      // Number of tests per student
      double score;      // Test score
      double total;      // Accumulator for test scores
      double average;    // Average test score
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      System.out.println("This program averages test scores.");

      // Get the number of students.
      System.out.print("How many students do you have? ");
      numStudents = keyboard.nextInt();

      // Get the number of test scores per student.
      System.out.print("How many test scores per student? ");
      numTests = keyboard.nextInt();

      // Process all the students.
      for (int student = 1; student <= numStudents; student++)
      {
         // Set the accumulator to zero.
         total = 0.0;

         // Get the test scores for a student.
         for (int test = 1; test <= numTests; test++)
         {
            System.out.print("Enter score " + test +
                             " for student " + student + ": ");
            score = keyboard.nextDouble();
            total += score;  // Add score to total.
         }

         // Calculate and display the average.
         average = total / numTests;
         System.out.println("The average score for student " +
                            student + " is " + average);
         System.out.println();
      }
   }
}
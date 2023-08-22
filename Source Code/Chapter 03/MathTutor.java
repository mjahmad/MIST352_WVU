import java.util.Random;

/**
 * This program demonstrates the Random class.
 */

public class MathTutor
{
     public static void main(String [] args)
     {
          Random randomNumbers = new Random();
          int number1, number2, sum;

          // Get two random numbers.
          number1 = randomNumbers.nextInt(100);
          number2 = randomNumbers.nextInt(100);

          // Display an addition problem.
          System.out.println("What is the answer to the "
                             + "following problem?");
          System.out.println(number1 + " + " 
                             + number2 + " = ?");
          System.out.println("Press Enter to see the answer.");

          // Wait for the user to press the Enter key.
          Keyboard.readLine();

          // Calculate and display the answer.
          sum = number1 + number2;
          System.out.println("The answer is " + sum);
     }
}

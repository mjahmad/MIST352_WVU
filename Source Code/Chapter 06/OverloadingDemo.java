import java.util.Scanner;

/**
 * This program uses the MyMath class to
 * demonstrate overloaded methods. 
 */

public class OverloadingDemo
{
   public static void main(String[] args)
   {
      int iNumber;
      double dNumber;
      
      // Create a Sanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get an integer and display its square.
      System.out.print("Enter an integer: ");
      iNumber = keyboard.nextInt();
      System.out.println("That number's square is " +
                         MyMath.square(iNumber));
                   
      // Get a double and display its square.
      System.out.print("Enter a double: ");
      dNumber = keyboard.nextDouble();
      System.out.println("That number's square is " +
                         MyMath.square(dNumber));
   }
}


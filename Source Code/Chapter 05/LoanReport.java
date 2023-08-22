import java.util.Scanner;
import java.io.*;

/**
 * This program displays a loan amortization report.
 */

public class LoanReport
{
   public static void main(String [] args)
                           throws IOException
   {
      double loan;         // Loan amount
      double interestRate; // Annual interest rate
      int years;           // Years of the loan
      String again;        // Should the loop repeat?
      
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      do
      {
         // Get the loan amount.
         System.out.print("Loan amount: ");
         loan = keyboard.nextDouble();

         // Validate the loan amount.
         // (No negative amounts.)
         while (loan < 0)
         {
            System.out.println("Invalid amount.");
            System.out.print("Loan amount: ");
            loan = keyboard.nextDouble();
         }

         // Get the annual interest rate.
         System.out.print("Annual interest rate: ");
         interestRate = keyboard.nextDouble();
         
         // Validate the interest rate
         // (No negative amounts.)
         while (interestRate < 0)
         {
            System.out.println("Invalid amount.");
            System.out.print("Annual interest rate: ");
            interestRate = keyboard.nextDouble();
         }

         // Get the years of the loan.
         System.out.print("Years of Loan: ");
         years = keyboard.nextInt();

         // Validate the number of years.
         // (No negative amounts.)
         while (years< 0)
         {
            System.out.println("Invalid amount.");
            System.out.print("Years of loan: ");
            years= keyboard.nextInt();
         }

         // Create and initialize an Amortization object.
         Amortization am = 
             new Amortization(loan, interestRate, years);

         // Save the report.
         am.saveReport("LoanAmortization.txt");
         System.out.println("Report saved to the file "
                      + "LoanAmortization.txt.");

         // Do another report?
         System.out.print("Would you like to run another "
                        + "report? Enter Y for yes or "
                        + "N for no: ");
         keyboard.nextLine();  // Consume the remaining newline.
         again = keyboard.nextLine();
         
      } while (again.charAt(0) == 'Y' || again.charAt(0) == 'y');
   }
}

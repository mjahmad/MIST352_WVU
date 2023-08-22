import java.io.*;
import java.text.DecimalFormat;

/**
 * A class for storing loan information and printing an
 * amortization report.
 */

public class Amortization
{
   private double loanAmount;   // Loan Amount
   private double interestRate; // Annual Interest Rate
   private double loanBalance;  // Monthly Balance
   private double term;         // Payment Term
   private double payment;      // Monthly Payment
   private int loanYears;       // Years of Loan

	/**
	 * The constructor uses three parameters: loan,
     * which is the loan amount, rate, which is the
     * annual interest rate, and years, which is the
     * number of years of the loan. These values are
     * stored in the corresponding fields. The private
     * CalcPayment method is then called.
	 */

   public Amortization(double loan, double rate, int years)
   {
      loanAmount = loan;
      loanBalance = loan;
      interestRate = rate;
      loanYears = years;
      CalcPayment();
   }

	/**
	 * The calcPayment method is used to calculate the
     * monthly payment amount. The result is stored in the
     * payment field.
	 */

   private void CalcPayment()
   {
      // Calculate value of Term
      term = 
        Math.pow((1+interestRate/12.0), 12.0 * loanYears);

      // Calculate monthly payment
      payment = 
        (loanAmount * interestRate/12.0 * term) / (term - 1);
   }

	/**
	 * The getNumberOfPayments method returns the number of
     * loan payments.
	 */

   public int getNumberOfPayments()
   {
      return 12 * loanYears;
   }

	/**
	 * The saveReport method saves the amortization report to 
     * the file named by the filename argument.
	 */

   public void saveReport(String filename) throws IOException
   {
      double monthlyInterest; // The monthly interest rate
      double principal;       // The amount of principal
      
      // Create a DecimalFormat object for output formatting.
      DecimalFormat dollar = new DecimalFormat("#,##0.00");
      
      // Create objects necessary for file output.
      FileWriter fwriter = new FileWriter(filename);
      PrintWriter outputFile = new PrintWriter(fwriter);

      // Print monthly payment amount.
      outputFile.println("Monthly Payment: $"
                   + dollar.format(payment));

      // Print the report header.
      outputFile.println("Month\tInterest\tPrincipal\tBalance");
      outputFile.println("-----------------------------------"
                       + "--------------");

      // Display the amortization table.
      for (int month = 1; month <= getNumberOfPayments(); month++)
      {
         // Calculate monthly interest.
         monthlyInterest = interestRate / 12.0 * loanBalance;

         if (month != getNumberOfPayments())
         {
            // Calculate payment applied to principal
            principal = payment - monthlyInterest;
         }
         else    // This is the last month.
         {
            principal = loanBalance;
            payment = loanBalance + monthlyInterest;
         }

         // Calculate the new loan balance.
         loanBalance -= principal;

         // Display a line of data.
         outputFile.println(month
                      + "\t" 
                      + dollar.format(monthlyInterest)
                      + "\t\t"
                      + dollar.format(principal)
                      + "\t\t"
                      + dollar.format(loanBalance));
      }

      // Close the file.
      outputFile.close();
   }

	/**
	 * The getLoanAmount method returns the loan amount.
	 */

   public double getLoanAmount()
   {
      return loanAmount;
   }

	/**
	 * The getInterestRate method returns the interest rate.
	 */

   public double getInterestRate()
   {
      return interestRate;
   }

	/**
	 * The getLoanYears method returns the years of the loan.
	 */

   public int getLoanYears()
   {
      return loanYears;
   }
}


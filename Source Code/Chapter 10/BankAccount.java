/**
 * BankAccount class
 * This class simulates a bank account.
 */

public class BankAccount
{
   private double balance;      // Account balance
   private double interestRate; // Interest rate
   private double interest;     // Interest earned

	/**
	 * The constructor initializes the balance
     * and interestRatet fields with the values
     * passed to startBalance and intRate. The
     * interest field is assigned 0.0.
	 */

   public BankAccount(double startBalance,
                      double intRate) throws NegativeStartingBalance,
                        NegativeInterestRate
   {
      if (startBalance < 0)
         throw new NegativeStartingBalance(startBalance);
      if (intRate < 0)
         throw new NegativeInterestRate(intRate);

      balance = startBalance;
      interestRate = intRate;
      interest = 0.0;
   }

	/**
	 * The deposit method adds the parameter
     * amount to the balance field.
	 */

   public void deposit(double amount)
   {
      balance = balance + amount;
   }

	/**
	 * The withdraw method subtracts the
     * parameter amount from the balance
     * field.
	 */

   public void withdraw(double amount)
   {
      balance = balance - amount;
   }

	/**
	 * The addInterest method adds the
     * interest for the month to balance.
	 */

   public void addInterest()
   {
      interest = balance * interestRate;
      balance = balance + interest;
   }


	/**
	 * The getBalance method returns the    
     * value in the balance field.
	 */

   public double getBalance()
   {
      return balance;
   }

	/**
	 * The getInterest method returns the    
     * value in the interest field.   
	 */

   public double getInterest()
   {
      return interest;
   }
}

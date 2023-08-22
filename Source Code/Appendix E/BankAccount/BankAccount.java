/**
 * This class simulates a bank account. It keeps the account
 * balance and adds periodic interest.
 * @author Herbert Dorfmann
 * @version 1.0
 */

public class BankAccount
{
   private double balance;      // Account balance
   private double interestRate; // Interest rate
   private double interest;     // Interest earned

   /**
    * The constructor initializes the balance
    * and interestRate fields. 
    * @param startBalance The starting balance
    * @param intRate The interest rate
    */

   public BankAccount(double startBalance,
                      double intRate)
   {
      balance = startBalance;
      interestRate = intRate;
      interest = 0.0;
   }

   /**
    * The deposit method adds an amount to 
    * the balance field.
    * @param amount The amount to add
    */

   public void deposit(double amount)
   {
      balance = balance + amount;
   }

   /**
    * The withdraw method subtracts an amount
    * from the balance field.
    * @param amount The amount to subtract
    */

   public void withdraw(double amount)
   {
      balance = balance - amount;
   }

   /**
    * The addInterest method adds the interest
    * for the month to the balance field.
    */

   public void addInterest()
   {
      interest = balance * interestRate;
      balance = balance + interest;
   }

   /**
    * The getBalance method returns the balance.
    * @return The value in the balance field
    */

   public double getBalance()
   {
      return balance;
   }

   /**
    * The getInterest method returns the interest
    * earned for the period.
    * @return The value in the interest field
    */

   public double getInterest()
   {
      return interest;
   }
}

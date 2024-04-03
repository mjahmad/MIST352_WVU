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
    * and interestRate fields with the values
    * passed to startBalance and intRate. The
    * interest field is assigned 0.0. 
    */

   public BankAccount(double startBalance,
                      double intRate)
   {
      this.balance = startBalance;
      this.interestRate = intRate;
      this.interest  = 0.0;
   }

   /**
    * The deposit method adds the parameter
    * amount to the balance field. 
    */

   public void deposit(double amount)
   {
      balance += amount;
   }

   /**
    * The withdraw method subtracts the
    * parameter amount from the balance
    * field.
    */

   public void withdraw(double amount)
   {
      balance -= amount;
   }

   /**
    * The addInterest method adds the
    * interest for the month to the balance field.
    */

   public void addInterest()
   {
      interest = balance * interestRate;
      balance += interest;
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

/**
 *  NegativeStartingBalance exceptions are thrown by
 *  the BankAccount class when a negative starting
 *  balance is passed to the constructor.
 */

public class NegativeStartingBalance extends Exception
{
   /**
    *  No-arg constructor
    */

   public NegativeStartingBalance()
   {
      super("Error: Negative starting balance");
   }

   /**
    *  The following constructor accepts the amount
    *  that was given as the starting balance.
    */

   public NegativeStartingBalance(double amount)
   {
      super("Error: Negative starting balance: " +
            amount);
   }
}
// This program has variables of several of the integer types.

public class IntegerVariables
{
   public static void main(String[] args)
   {  
      int checking;  // Declare an int variable named checking.
      byte miles;    // Declare a byte variable named miles.
      short minutes; // Declare a short variable named minutes.
      long diameter; // Declare a long variable named diameter.

      checking = -20;
      miles = 105;
      minutes = 120;
      diameter = 100000;
      System.out.print("We have made a journey of " + miles);
      System.out.println(" miles.");
      System.out.println("It took us " + minutes + " minutes.");
      System.out.println("Our account balance is $" + checking);
      System.out.print("The galaxy is " + diameter +
                       " light years in diameter.");
   }
}

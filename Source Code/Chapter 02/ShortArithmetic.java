// This program attempts an arithmetic operation
// using only short values. An error will occur.

public class ShortArithmetic
{
   public static void main(String[] args)
   {
      short firstNumber = 10;
      short secondNumber = 20;
      short thirdNumber;

      // The following statement causes an error!
      thirdNumber = firstNumber + secondNumber;
      System.out.println(thirdNumber);
   }
}


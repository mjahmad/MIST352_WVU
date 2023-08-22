import java.util.Scanner;
public class CheckPoint
{
   public static void main(String[] args)
   {
      int books, coupons;
		
		Scanner keyboard = new Scanner(System.in);
  		System.out.print("How many books are being purchased? ");
      books = keyboard.nextInt();
		
      if (books < 1)
         coupons = 0;
      else if (books < 3)
         coupons = 1;
      else if (books < 5)
         coupons = 2;
      else
         coupons = 3;

      System.out.println( "Number of coupons: "
                        + coupons);
   }
}

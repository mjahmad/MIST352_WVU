import java.util.Scanner;

/**
 * This program calculates a salesperson's gross
 * pay at Hal's Computer Emporium.
 */

public class HalsCommission
{
   public static void main(String[] args)
   {
      double sales,       // To hold amount of sales
             advancePay;  // To hold advance pay
      
      // Create a Scanner object to read input.
      Scanner keyboard = new Scanner(System.in);

      System.out.println("This program will display a " +
                         "pay report for a salesperson.");
      System.out.println("Enter the following information:");

      // Ask the user for sales & Advanced Pay
      System.out.print("Amount of sales: $");
      sales = keyboard.nextDouble();
      System.out.print("Amount of advanced pay: $");
      advancePay = keyboard.nextDouble();

      // Create an instance of the SalesCommission
      // class and pass the data to the constructor.
      SalesCommission payInfo =
              new SalesCommission(sales, advancePay);

      // Display the pay report for the salesperson.
      System.out.println("\nPay Report");
      System.out.println("-------------------------");
      System.out.printf("Sales: $%,.2f\n", payInfo.getSales());
      System.out.printf("Commission rate: %.2f\n", payInfo.getRate());
      System.out.printf("Commission: $%,.2f\n", payInfo.getCommission());
      System.out.printf("Advanced pay: $%,.2f\n", payInfo.getAdvance());
      System.out.printf("Remaining pay: $%,.2f\n", payInfo.getPay());
   }
}


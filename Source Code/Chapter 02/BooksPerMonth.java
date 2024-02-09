// This program demonstrates how a cast operator can be used
// to prevent integer division.
import java.util.Scanner;

public class BooksPerMonth
{
   public static void main(String[] args)
   {
	  Scanner scnUserInput = new Scanner (System.in);  
	  
	  System.out.println("Hello, how many books did you read?");
      int books = scnUserInput.nextInt();         // Number of books read
      
	  System.out.println("Hello,how many months it took you to read those books?");

      int months = scnUserInput.nextInt();               // Months spent reading
      double booksPerMonth;   // Average books per month

    		  
      // Calculate the average number of books
      // read per month.
      booksPerMonth = (double) books / months;

      // Display the average.


      System.out.print("I read an average of " +
                       booksPerMonth + 
                       " books per month.");
      scnUserInput.close();
	
   }
}

// This program demonstrates how a cast operator can be used
// to prevent integer division.

public class BooksPerMonth
{
   public static void main(String[] args)
   {
      int books = 15;         // Number of books read
      int months = 6;         // Months spent reading
      double booksPerMonth;   // Average books per month

      // Calculate the average number of books
      // read per month.
      booksPerMonth = (double) books / months;

      // Display the average.
      System.out.print("I read an average of " +
                       booksPerMonth + 
                       " books per month.");
   }
}

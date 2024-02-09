// This program calculates the sale price of an
// item that is regularly priced at $59, with
// a 20 percent discount subtracted.

import java.util.Scanner;
public class Discount
{
   public static void main(String[] args)
   {
      // Variables to hold the regular price, the
      // amount of a discount, and the sale price.
      double regularPrice ;
      System.out.println("Give me the regular price");
      Scanner scnUser = new Scanner (System.in);
      regularPrice = scnUser.nextDouble();
      double discount;
      double salePrice;
      char midInitial;
      System.out.println("Give me a character");

  
      midInitial = (scnUser.next()).charAt(0);      
      System.out.println(midInitial);


      // Calculate the amount of a 20% discount.
      discount = regularPrice * 0.2;
      
      // Calculate the sale price by subtracting
      // the discount from the regular price.
      salePrice = regularPrice - discount;
      
      // Display the results.


System.out.println("Regular price: $" + regularPrice);
      System.out.println("Discount amount $" + discount);
      System.out.println("Sale price: $" + salePrice);
      
   }
}
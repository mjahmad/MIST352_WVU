import java.util.Scanner;  // Needed for the Scanner class

/**
 * This program demonstrates the if statement.
 */

public class AverageScore 
{
   public static void main(String[] args)
   {
      double score1 =99,   // Score #1
             score2=-1,   // Score #2
             score3=90,   // Score #3
             average;  // Average score
      
      
      if (!(score1 > 0 && score1 < 101))
      {
    	

        	System.out.println("option 1");    
      }
      else if (!(score2 > 0 && score2 < 101))
      {
    	  
      }
      else if (!(score3 > 0 && score3 < 101))
      {
    	  average = (score1+score2+score3)/3;

        System.out.println(average);  
   	 
      }
      else
      {
    	  System.out.println("Ivalid");
      }
      
      


      
      
//      if (score1>0 && score1<101)
//      {
//          if (score2>0 && score2<101)
//          {
//              if (score3>0 && score3<101)
//              {
//            	  average = (score1+score2+score3)/3;
//            	  System.out.println("Averag is\t"+average);
//            	  
//              }
//              else
//              {
//            	  System.out.println("Score3 is not valid");
//
//              }
//              
//              
//          }
//          else
//          {
//        	  System.out.println("Score2 is not valid");
//
//          }
//          
//  
//      }
//      else
//      {
//    	  System.out.println("Score1 is not valid");
//
//      }
//      
//
//      // Create a Scanner object to read input.
//      Scanner keyboard = new Scanner(System.in);
//
//      System.out.println("This program averages " +
//                         "3 test scores.");
//      
//      // Get the first score.
//      System.out.print("Enter score #1: ");
//      score1 = keyboard.nextDouble();
////      if (score1<0 || score1>100)
////      {      System.out.print("Grade is incorrect its either less than 0 or greater than 100 ");
////      }
//      
//      // Get the second score.
//      System.out.print("Enter score #2: ");
//     score2 = keyboard.nextDouble ();
////     if (score2<0 || score2>100)
////     {      System.out.print("Grade is incorrect its either less than 0 or greater than 100 ");
////     }
//      
//      // Get the third score.
//      System.out.print("Enter score #3: ");
//      score3 = keyboard.nextDouble ();
////      if (score3<0 || score3>100)
////      {      System.out.print("Grade is incorrect its either less than 0 or greater than 100 ");
////      }
//      
//      if(score1 > 0 && score1<100 &&score2>0 &&score2<100 &&score3>0 && score3<100)
//      
//      {
//	      // Calculate and display the average score.
//	      average = (score1 + score2 + score3) / 3.0;
//	      System.out.println("The average is " + average);
//	      
//	      // If the average is higher than 95, congratulate
//	      // the user.
//	      
//	      if (average>=90)
//	      {
//	    	  System.out.println("Your grade is A");
//	      }
//	      else if (average >=80)
//	      {
//	    	  System.out.println("Your grade is B");
//	      }
//	      else if (average >=70)
//	      {
//	    	  System.out.println("Your grade is C");
//	      }
//	
//	      else if (average >=60)
//	      {
//	    	  System.out.println("Your grade is D");
//	      }
//	      else
//	      {
//	    	  System.out.println("Your grade is F");
//	
//	      }
//	      
//      }
//      else
//      {	      System.out.println("Invalid Input");
//      }
//            
//          	 
      
   }
} 
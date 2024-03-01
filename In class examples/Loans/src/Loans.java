/**
 * 
 */

/**
 * 
 */
import java.util.Scanner;

public class Loans {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub


		Scanner scnUserInput = new Scanner (System.in);
		System.out.println("Hello, what is your income");
		double dblIncome = scnUserInput.nextDouble();
		
		System.out.println("Provide number of years of experience");
		int intExperience = scnUserInput.nextInt();
		
		if(dblIncome>=100000 && intExperience >=10)
		{
			System.out.println("You are qualified becuase your income is "+dblIncome + "and your experiecne is "+intExperience);
			System.out.printf("You are qualified becuase your income is %d and your experiecne is %f",intExperience,intExperience);

		}
		else 
		{
		System.out.println("You are qualified");
		}
		
		
		
//		if(dblIncome>=100000)
//		{
//			if(intExperience >=10)
//			{
//				System.out.println("You are qualified");
//
//			}
//			
//			else
//			{
//				System.out.println("You make ok money,"
//						+ " but you do not have enough experiecen");
//
//			}
//		}
//		else
//		{
//			System.out.println("You are not qualified");
//		}
			
		}
		
	}



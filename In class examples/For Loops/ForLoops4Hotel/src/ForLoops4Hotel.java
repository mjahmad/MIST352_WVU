/**
 * 
 */

/**
 * 
 */
import java.util.Scanner;

public class ForLoops4Hotel {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		//Track the number of floors
		int intFloors=0;
		
		//Scanner for user input
		Scanner scnUserInput = new Scanner(System.in);
		
		//Message asking for input
		System.out.println("How many floors does the hotel have?");
		
		//Ask use for No. of floors
		intFloors = scnUserInput.nextInt();
		
		//As long as the user enter 0 or less floors, keep asking for correct number of floors
		while(intFloors<=0)
		{
			System.out.println("Invalid. Enter 1 or more");
			//Re-Accept input from user
			intFloors = scnUserInput.nextInt();


		}
		
		scnUserInput.close();
		

	}

}

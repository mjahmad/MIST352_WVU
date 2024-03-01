/**This program will keep asking the user to provide the capitol of WV until the user provides it
 * 
 */

/**
 * 
 */
import java.util.Scanner;

public class ForLoopGame {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub

		///Store the capitol in this variable
		String strCapitolOFWV="Charleston";
		
		//Scanner for user input
		Scanner scnUserInput = new Scanner(System.in);
		// Ask the question
		System.out.print("What is the state of WV?");
		
		//As long as the input is not equal to Charleston (case ignored), keep asking.
		while(!scnUserInput.next().equalsIgnoreCase(strCapitolOFWV))
		{
			System.out.print("What is the state of WV?");

		}
		System.out.print("Good job");

		

	}

}

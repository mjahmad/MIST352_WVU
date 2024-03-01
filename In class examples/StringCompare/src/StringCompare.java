/**
 * 
 */

/**
 * 
 */
import java.util.Scanner;

public class StringCompare {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub


		Scanner scnUser = new Scanner(System.in);
		String str1 =scnUser.next();
		String str2 =scnUser.next();

		if (str1.equalsIgnoreCase(str2))
		{
			System.out.println("yes");
		}
		else
		{
			System.out.println("no");

		}
		

	}

}

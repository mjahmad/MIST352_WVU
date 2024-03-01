/**A program that prints out even and odd numbers between 1-100
 * Also, it prints out the number of even numbers and odd numbers found
 * 
 */

/**
 * 
 */
public class OddEvenNumbers {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		//Three variables, one for the whiloe loop and the two to keep track of the numbers of even/ odd numbers
		int intLimit=0, intNoOfEven=0, intNoOfOdd=0;
		
		//While loop that iterates through all numbers between 1 - 100
		while(intLimit<=100)
		{
			//Even numbers: if the number modulus 2 is Zero
			if (intLimit%2==0) {
				System.out.printf("%d - Even\n", intLimit);
				intNoOfEven++;;
			}
			else //otherwise, the number is odd
			{
				System.out.printf("%d - Odd\n", intLimit);
				intNoOfOdd++;

			}
			//Move on to the next number
			intLimit++;
				
		}
		System.out.printf("Between 0 and %d:\nTotal number of Even numbers is: %d\n Total number of Odd numbers is: %d", intLimit,intNoOfEven,intNoOfOdd);

		
	}

}

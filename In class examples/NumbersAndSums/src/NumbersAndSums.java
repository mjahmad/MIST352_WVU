/**
 * A program that prints out the numbers between 1 - 100, and for each number, it sum all numbers between 0 and that number
 * This uses two for loops you can still do it using only one loop.
 */

/**
 * 
 */
public class NumbersAndSums {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int intSum=0;
		
		for (int intCounter1=1; intCounter1<=100; intCounter1++)
		{
			for (int intCounter2 = intCounter1; intCounter2>=0; intCounter2--)
			{
				intSum+=intCounter2;
				
			}
			System.out.printf("%d - %d\n", intCounter1, intSum);
			intSum=0;
			
		}
		

	}

}

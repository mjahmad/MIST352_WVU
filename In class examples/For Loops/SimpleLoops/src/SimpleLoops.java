/**Three different ways to printout number between 1-00
 * Using for loops, while loop, and do-while
 * 
 */

/**
 * 
 */
public class SimpleLoops {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		//Using for loop
		System.out.println("Printout number between 1-00 using for loops" );

		for(int intForCounter=0; intForCounter<=100;intForCounter++)
			System.out.println(intForCounter);
		
		System.out.println("Printout number between 1-00 using for whole loops" );
		
		int intWhileCounter=0;
		while(intWhileCounter<=100) {
			System.out.println(intWhileCounter);
			intWhileCounter++;
		}
		
		System.out.println("Printout number between 1-00 using do-while" );
		
		int intDoCounter=0;
		do {			
			System.out.println(intDoCounter);
			intDoCounter++;

			
		}while(intDoCounter<=100);

			
		


	}

}

/**
 * 
 */

/**
 * Examples on how to use and create One Dimensional Arrays
 */
import java.util.Random;

public class OneDArray {

	/**
	 * @param args
	 */
	@SuppressWarnings("null")
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		//Will use this to generate random numbers
		Random rand = new Random();
		//Declare an array of integers that holds 5 values
		int[] intArray1  = new int[5];
		
		//Declare without providing size
		int [] intArray2  = {12, 21, 30, 14, -5};
		
		//Declare arrays of Strings
		String [] strArrayOfNames = new String[10];		
		String [] strArrayOfClasses = new String[10];

		//Add data to intArray1
		intArray1[0]=10;

		intArray1[1]=11;

		intArray1[2]=-9;

		intArray1[3]=30;
		intArray1[4]=90;
		int intMin = intArray1[0];

		//Printout everything in the Aray1
		System.out.printf("Contents of intArray1\n");

		for (int intCounter=0; intCounter < intArray1.length; intCounter++)
		{
			if (intArray1[intCounter]<intMin)
			{
				 intMin = intArray1[intCounter];
			}
			
		}
//		
		System.out.printf("Minimum is %d\n",intMin);
//
//		System.out.printf("Contents of intArray2\n");
//	
//		//Lets verify the contents of intArray2
//		for (int intCounter=0; intCounter < intArray2.length; intCounter++)
//		{
//			System.out.printf("Value in position %d is %d\n", intCounter,intArray2[intCounter]);
//		}
//		
//		System.out.printf("==================================\n");
//
//		//Lets fill out the array of names with some data
//		strArrayOfNames[0] = "Sally Ahmad";
//		
//		strArrayOfNames[3] = "Fluffkinz Stewart";
//
//		//Lets see the contents of strArrayOfNames
//		for (int intCounter=0; intCounter < strArrayOfNames.length; intCounter++)
//		{
//			System.out.printf("Name in position %d is %s\n", intCounter,strArrayOfNames[intCounter]);
//		}
//		
//		System.out.printf("==================================\n");
//
//		//How to find the minimum value in intArray2
//		int intMin=0;
//		
//		//Visit each element, and check:
//		for (int intCounter=0; intCounter < intArray2.length; intCounter++)
//		{
//			if(intArray2[intCounter]<intMin)
//				intMin = intArray2[intCounter];
//		}
//		System.out.printf("The minimum value in the intArray2 is %d\n", intMin);
//		
//		System.out.printf("==================================\n");
//
//		//Lets us fill out the intArray2 with Random numbers
//
//		for (int intCounter=0; intCounter < intArray2.length; intCounter++)
//			{
//				intArray2[intCounter] = rand.nextInt();
//			}
//		
//		
//		// Lets printout the data in intArray2
//		for (int intCounter=0; intCounter < intArray2.length; intCounter++)
//		{
//			System.out.printf("%d\n", intArray2[intCounter]);
//		}
//		
//		System.out.printf("==================================\n");
//
//		//Lets us fill out the intArray2 with Random numbers (between 0 and 500)
//
//		for (int intCounter=0; intCounter < intArray2.length; intCounter++)
//			{
//			intArray2[intCounter] = rand.nextInt(500);
//			}
//		
//		
//		// Lets printout the data in intArray2 again
//				for (int intCounter=0; intCounter < intArray2.length; intCounter++)
//				{
//					System.out.printf("%d\n", intArray2[intCounter]);
//				}
//				
//		System.out.printf("==================================\n");
//
//		// An other cool way to printout the elements in any array
//		for (int intValue : intArray1)
//		{
//			System.out.printf("%d\n", intValue);
//
//		}
//		System.out.printf("==================================\n");
//		
//		int intCounter=10;
//		while(intCounter <=15)
//		{
//			System.out.println (++intCounter);
//		}
//
//
//		
	}

}

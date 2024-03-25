/**
 * 
 */

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * 
 */
public class ReadSplitText {

	/**
	 * @param args
	 * @throws FileNotFoundException 
	 */
	public static void main(String[] args) throws FileNotFoundException {
		// TODO Auto-generated method stub
		// Open the text file
		File myFile = new File("cars_data.txt");
		//Scanner needed to read the file
		Scanner inputFile = new Scanner(myFile); 
		
		// Skip the first line, since it has no needed data really
		String strLine = inputFile.nextLine();

		//While loop to iterate through the file
		while(inputFile.hasNext())
		{
			//Read each line in the text and store it in a String
			 strLine = inputFile.nextLine();
			//System.out.println(strLine);

			//Create a Car object from the line
			Car theCar = new Car(strLine);
			
			//Print the car info.
			theCar.printCarsInfo();
			theCar.printCarsInfoCFancy();        
				
		}
		inputFile.close();


	}

}

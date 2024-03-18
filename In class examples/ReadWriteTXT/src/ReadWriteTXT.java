/**The program Creates a new text file named Special Names. It then reads names from a text file named Names.txt
 * The program reads the names from Names.txt, if the name has any + it removes it, then writes the names to the Special Names.txt file.
 * 
 */

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;

/**
 * 
 */
public class ReadWriteTXT {

	/**
	 * @param args
	 * @throws FileNotFoundException 
	 */
	public static void main(String[] args) throws FileNotFoundException {
		// TODO Auto-generated method stub
		//Create a new text file named SpecialNames.txt
		PrintWriter outputFile = new PrintWriter("SpecialNames.txt");

		String strLine="";
		int intMyNames=0;
		//Read the file named Names.txt
		File myFile = new File("Names.txt");
		//Scanner needed to read the file
		Scanner inputFile = new Scanner(myFile); 

		//While loop to iterate through the file
		while(inputFile.hasNext())
		{
			//Read each line in the text and store it in a String
			strLine = inputFile.nextLine();
			//If the string has +, replace it with "" and make the name upper case.
			strLine = (strLine.replace("+", "")).toUpperCase();
			//Print the name to the text file
			outputFile.println(strLine);
	        
				
		}
		//Close everything
		
		inputFile.close();
		outputFile.close();
		
		outputFile.println("Cats everywhere");

		
		
		
	}

}

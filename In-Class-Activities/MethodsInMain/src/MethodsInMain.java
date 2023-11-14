import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;

/**
 * 
 */

/**
 * @author MJ
 *
 */
public class MethodsInMain {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		// Calling a a non-void method is straight forward
		DoSomething();
		
		DoSomethingElse() ;
		
	}
	/**
	 * Void method that prints out a message
	 */
	public static void DoSomething() {
		System.out.println("This is a void method in the main class");
	}
	/**
	 * Non void method that return an integer
	 * @return Integer 
	 */
	
	public static int DoSomethingElse() {

		return 1;
		
	}
	/**
	 * Method that accepts a location of at text file and prints out its data in different ways
	 * @param strFileLocation
	 */
	public static void ReadDataFromText(String strFileLocation) {
		File myData = new File (strFileLocation);
		Scanner scnReader = new Scanner (System.in);
		while (scnReader.hasNext())
		{
			String strLine = scnReader.nextLine();
			System.out.println("Printing every line as is as is");
			System.out.println(strLine);

			System.out.println("Print first element in the row, assuming data is comma seperated");
			System.out.println(strLine.split(",")[0]);
			
			System.out.println("Print second element in the row, assuming data is comma seperated");
			System.out.println(strLine.split(",")[1]);
			
		}
	}
		
		/**
		 *  Method that accepts a location of at text file and a word to find in the text
		 * @param strFileLocation: Location of text file
		 * @param strWord2Find   : Word to find in the text file
		 * @return: True if the word is found, otherwise return False
		 */
		
		public static Boolean FindSomething(String strFileLocation, String strWord2Find) {
			File myData = new File (strFileLocation);
			Scanner scnReader = new Scanner (System.in);
			while (scnReader.hasNext())
			{
				String strLine = scnReader.nextLine();
				System.out.println("Printing every line as is as is");
				if (strLine.contains(strWord2Find))
					return true;
			}
			return false;

		
		
	}
		
		public static void WriteDataToText(String strLocation) throws IOException
		{
			FileWriter fw =     new FileWriter(strLocation, true);
			PrintWriter pw = new PrintWriter(fw);
			pw.print("hi");
			pw.close();
			
			
			
			
		}

}

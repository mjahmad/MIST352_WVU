import java.io.FileNotFoundException;

/**
 * 
 */

/**
 * 
 */
public class FancyArrayDriver {

	/**
	 * @param args
	 * @throws FileNotFoundException 
	 */
	public static void main(String[] args) throws FileNotFoundException {
		// TODO Auto-generated method stub
		//Initialize a 1D array
//		int [] myArray = {10,89,66,74,65,84,12,10,-10,-9,66};
//		//Create an object of type Fancy1DArray
//				Fancy1DArray first1DArray= new Fancy1DArray(myArray);
//				System.out.println("Calling all methods for this 1D array");
//				//Printout the minimum
//				System.out.println(first1DArray.findMinimum());	
//				
//				//Printout the maximum
//				System.out.println(first1DArray.findMaximum());
//
//				//Calling the method that prints out the minimum and its index (location)
//				first1DArray.displayMinimumAndIndex() ;
//				
//				//Calling the method that prints out the maximum and its index (location)
//				first1DArray.displayMaximumAndIndex();
//				
//				//Printout the average of all elements in the array
//				System.out.println("The average is :"+first1DArray.findAverage());
//				
//				//Calling the method that finds whether a number , 1, is in the array or not
//				System.out.println(first1DArray.containsElement(1));
//
//				
//				//Now lets create a Fancy1Darray using the second constructor. We will set the size to 50
//				//Note that the constructor will fill out this array with randomly generated numbers
//				Fancy1DArray second1DArray = new Fancy1DArray(50);
//				
//				System.out.println("Calling all methods for this second 1D array");
//				//Printout the minimum
//				System.out.println(second1DArray.findMinimum());	
//				
//				//Printout the maximum
//				System.out.println(second1DArray.findMaximum());
//
//				//Calling the method that prints out the minimum and its index (location)
//				second1DArray.displayMinimumAndIndex() ;
//				
//				//Calling the method that prints out the maximum and its index (location)
//				second1DArray.displayMaximumAndIndex();
//				
//				//Printout the average of all elements in the array
//				System.out.println("The average is :"+second1DArray.findAverage());
//				
//				//Calling the method that finds whether a number , 1, is in the array or not
//				System.out.println(second1DArray.containsElement(1));
//
//
//		System.out.println("============================================");
//		System.out.println("The 2D array");
//		
//		//Initialize a 2D arrays 
//		int[][] my2Darray = {
//			    {1, 2, 3, 4, 5}, // Row 1
//			    {6, 7, 8, 9, 10}, // Row 2
//			    {11, 12, 13, 14, 15}, // Row 3
//			    {16, 17, 18, 19, 20} // Row 4
//			};
//
//		
//		//Create an object of type Fancy2DArray
//				Fancy2DArray first2DArray= new Fancy2DArray(my2Darray);
//				System.out.println("Calling all methods for this 1D array");
//				//Printout the minimum
//				System.out.println(first2DArray.findMinimum());	
//				
//				//Printout the maximum
//				System.out.println(first2DArray.findMaximum());
//
//				//Calling the method that prints out the minimum and its index (location)
//				first2DArray.displayMinimumAndIndex() ;
//				
//				//Calling the method that prints out the maximum and its index (location)
//				first2DArray.displayMaximumAndIndex();
//				
//				//Printout the average of all elements in the array
//				System.out.println("The average is :"+first2DArray.findAverage());
//				
//				//Calling the method that finds whether a number , 1, is in the array or not
//				System.out.println(first2DArray.containsElement(1));
//
//				
//				//Now lets create a Fancy1Darray using the second constructor. We will set the size to 10 rows and 4 columns
//				//Note that the constructor will fill out this array with randomly generated numbers
//				Fancy2DArray second2DArray = new Fancy2DArray(10,4);
//				
//				System.out.println("Calling all methods for this second 1D array");
//				//Printout the minimum
//				System.out.println(second2DArray.findMinimum());	
//				
//				//Printout the maximum
//				System.out.println(second2DArray.findMaximum());
//
//				//Calling the method that prints out the minimum and its index (location)
//				second2DArray.displayMinimumAndIndex() ;
//				
//				//Calling the method that prints out the maximum and its index (location)
//				second2DArray.displayMaximumAndIndex();
//				
//				//Printout the average of all elements in the array
//				System.out.println("The average is :"+second2DArray.findAverage());
//				
//				//Calling the method that finds whether a number , 1, is in the array or not
//				System.out.println(second2DArray.containsElement(1));
//				
//				
//				System.out.println("Create a 1D array object by reading a text file");
//
//				 TextFileToArray example1 = new TextFileToArray("src/data1.txt", 5); // Adjust path and number of lines as needed
//			     example1.printArray();
//			     
//				System.out.println("Create a 2D array object by reading a text file");
//
//			     CSVFileTo2DArray example2 = new CSVFileTo2DArray("src/data2.csv", 5, 3); // Adjust path, rows, and columns as needed
//			     example2.printArray();
//			     

				System.out.println("============================================");
				System.out.println("The 2D array from the CSV file");
				
			     CsvTo2DArray the2DArrayFromCsv = new CsvTo2DArray("src/SampleCSVData.csv");
			     

			     the2DArrayFromCsv.printData();


		
	
	}

}

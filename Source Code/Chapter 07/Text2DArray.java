import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * 
 */

/**
 * @author MJ
 *
 */
public class Text2DArray {

	/**
	 * @param args
	 * @throws FileNotFoundException 
	 */
	public static void main(String[] args) throws FileNotFoundException {
		// TODO Auto-generated method stub
		//Initialize 2 D array. We know the An1.csv has 20 rows and we are interested in only 31 columns.
		double[][] data = new double[20][31];
		//String to hold variable name of the data
		String strFileName = "Ant1.csv";
		//Instance to open the text files
		File textFile=new File(strFileName);
		//Scanner to iterate thought the file
		Scanner reader = new Scanner(textFile);
		//Iterate through the file.
		//This read the file, one line at a time
		int row=0 ,col =0;
		//Skip the first line
		reader.nextLine();
		//Read through the file
		while(reader.hasNext())
		{
			//Create 1D array for each line. In each cell, put the cell from the line.
			String[] strLine =reader.nextLine().split(",");
			//This will track the number of splited valued in the line.
			//This is one, not zero because we want to skip the first piece of data which is a string
			int intSplittedCounter=1;
			//Iterate through each line. We only need the data in each line excluding 1st
			//piece of data and we don't need the last three parts
			while(intSplittedCounter < strLine.length-3)
			{
				System.out.printf("%s ",strLine[intSplittedCounter]);
				//Set the current value int he 2-D array to this piece of data.
				data[row][col]=Double.parseDouble(strLine[intSplittedCounter]);
				//Increment by 1
				intSplittedCounter++;	
				col++;
			}
			col=0;
			System.out.printf("\n ");
			row++;
		}
		
		
		print2Darray(data);
		

	}
	/**
	 * A Method that prints out a 2-D array of doubles
	 * @param data : 2-D array f doubles
	 */
	public static void print2Darray(double[][] data)
	{
		//First for loop to control the rows
		for (int intRow=0;intRow<data.length;intRow++)
		{
			{
				//Second for loop to control the columns

				for (int intCol=0;intCol<data[intRow].length;intCol++)
				{				
					System.out.printf("++%f\t", data[intRow][intCol]);
					
				}
				System.out.printf("\n" );

			}
			
		}		
	}

}

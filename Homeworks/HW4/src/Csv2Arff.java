
/**
 * This class allows you to convert a csv file to arff file.
 * @author MJ
 *
 */
public class Csv2Arff {
	private String csvFileLocation;
	
	/**
	 * Keep as is. 
	 * Constructor.
	 * @param Location
	 */
	public Csv2Arff(String Location)
	{
		csvFileLocation=Location;
	}
	
	/**
	 * You need to code this
	 * This method accepts a name of a csv file and it writes an arff file from the csv file
	 * Writing arff file is similar to writing any .txt file. Just make sure the arff file name ends with .arff
	 * @param theLocation: The name and location of any csv file
	 */
	public void Convert2Arff(String theLocation)
	{
		System.out.println("Done =)");
			
	}
	
	/**
	 * This method should red the text file to a two dimensional array of Strings.
	 * This method should return the data given in a specific row and column in the two dimensional array
	 * @param theFile: name of the csv file to open 
	 * @param row: row number in the two dimensional array
	 * @param column: column number in the two dimensional array
	 * @return strData2Return: the data in the [column][row]
	 */
	public static String RetrieveCell(String theFile, int row, int column)
	{
		String strData2Return="";
		
		return strData2Return;
	}

}

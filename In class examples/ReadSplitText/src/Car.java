import javax.swing.JOptionPane;

/**
 * The driver program of the Car class.
 * This program reads the data from a text file, one line at a time.
 * Then, it creates an object Car for EACH LINE in the text file.
 */
public class Car {
	private String manufacturer;
	private String model;
	private int year;
	private int engine;
	
	/**
	 * Constructor that splits up each line and extracts each of the variables
	 * Sets each of the parameters to the extracted piece of info.
	 * @param line: line from the text file.
	 */
	public Car(String line)
	{
		// Take the line, split it upp based on ' and get the first value in the line
		this.manufacturer = line.split(",")[0];
				
		this.model = line.split(",")[1];

		this.year = Integer.parseInt( line.split(",")[2]);

		this.engine = Integer.parseInt(line.split(",")[3]);

	}

	/**
	 * Printout the car information to the Console
	 */
	public void printCarsInfo()
	{
		System.out.printf("Here is info %s - %s  - %d - %d\n",this.manufacturer,this.model,this.year,this.engine);
	}
	/**
	 * Printout the car info in a GUI
	 */
	public void printCarsInfoCFancy()
	{
		String strSummary = String.format("Here is info %s - %s  - %d - %d\n",this.manufacturer,this.model,this.year,this.engine);
		
		JOptionPane.showInternalMessageDialog(null, strSummary);
}
	
	

}

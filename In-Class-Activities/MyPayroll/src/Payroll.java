/**
 * 
 */

/**
 * 
 */
public class Payroll {
	private String name;
	private int idNumber;
	private double payRate;
	private double Worked;
	
	//Constructor

	public void setName (String strNameFromMain)
	{
		name = strNameFromMain;	
	}
	
	public String getName()
	{
		return name;
	}
	
	
	
	public void setID (int intIdFromMain)
	{
		idNumber = intIdFromMain;	
	}
	
	public void setPayRate (double dblRate)
	{
		payRate = dblRate;	
	}
	
	public double getPayRate()
	{
		return payRate;
	}
	
	public void setWorkedHours (double dblHours)
	{
		Worked = dblHours;	
	}
	/**
	 * 
	 */
	public void printEmplolyeeData()
	{
		System.out.printf("\nThe employee named %s has an ID %d and an hourly rate of %f", name,idNumber,payRate);
	}
	
	public void PrintSalary()
	{
		System.out.printf("\nsalary is %f", (payRate * Worked));
	}
	

	public double salary()
	{
		return(payRate * Worked);
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}

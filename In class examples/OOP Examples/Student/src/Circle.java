/**
 * 
 */

/**
 * 
 */
public class Circle {
	private double raduis;
	
	//Constructor
	public Circle(double theRaduis)
	{
		this.raduis = theRaduis;
	}
	
	
	public void setRaduis (double theRaduis)
	{
		this.raduis	 = theRaduis;
		
	}
	
	public double getRaduis ()
	{
		return this.raduis;
	}
	
	public double calculateArea()
	{
		return 3.14 * raduis * raduis;
	}
	public void printCircleInfo()
	{
		
		System.out.printf("The circle with raduis %f has an area of %f", this.raduis,calculateArea());
	}
	
	
	
	

}


public class Course {
	private String strCourseName;
	private int intMxxNumber;
	private int intCurrentEnrolled;
	
	
	
	public Course(String theCourseName)
	{
		strCourseName = theCourseName;
		
	}
	
	public Course(String theCourseName, int intMax)
	{
		intMxxNumber = intMax;
		strCourseName = theCourseName;
		
	}
	
	public Course(int intCurrent, int intMax)
	{
		intMxxNumber = intMax;
		intCurrentEnrolled = intCurrent;
		
	}
	
	public Course()
	{
		strCourseName ="";
		intMxxNumber =0;
		intCurrentEnrolled = 0;
		
	}
	
	
	
	public void setCourseName(String name)
	{
		strCourseName = name;
		
	}
	
	public void intMxxNumber(int max)
	{
		intMxxNumber = max;
		
	}
	

}

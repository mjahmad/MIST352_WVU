/**
 * 
 */

/**
 * 
 */
public class Student {
	private String name;
	private int grade1;
	private int grade2;
	private int grade3;

	/**
	 * Constructor
	 * @param theName: name of the student
	 * @param firstGrade
	 * @param secondGrade
	 * @param thirdGrade
	 */
	
	public Student (String theName, int firstGrade, int secondGrade, int thirdGrade)
	{
		this.name = theName;
		this.grade1 = firstGrade;
		this.grade2 = secondGrade;
		this.grade3 = thirdGrade;	
	}
	
	/**
	 * This method calculates the GPA given the three grades
	 * @return
	 */
	public int CalculateGPA()
	{
		int gpa = (this.grade1 + this.grade2 + this.grade3)/3;
		return gpa;
	}
	
	/**
	 * This method calculates the letter grade given the GPA.
	 * @return
	 */
	public char LetterGrade()
	{
		if ( CalculateGPA() >=90)
			return 'A';
		else if ( CalculateGPA() >=80)
			return 'B';
		else if ( CalculateGPA() >=70)
			return 'C';
		else if ( CalculateGPA() >=60)
			return 'D';
		else
			return 'F';
	}
	/**
	 * This method prints out the studnets infor and grade
	 */
	
	public void DisplayStudentInfo()
	{
		String strInfo = String.format("The stundet %s with the grades %d, %d, %d has a GPA of %d which is %c", 
				this.name,this.grade1,this.grade2, this.grade3, CalculateGPA(),LetterGrade());
		System.out.println(strInfo);
				
	}
	

}

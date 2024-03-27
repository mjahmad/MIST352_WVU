/**
 * 
 */

/**
 * 
 */
public class StudentGPA {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Student student1 = new Student("Sarah Conor",100,70,66);
		Student student2 = new Student("Ripley Smith",99,90,80);
		Student student3 = new Student("James Ahmad",40,50,50);
		student1.DisplayStudentInfo();

		student2.DisplayStudentInfo();
		student3.DisplayStudentInfo();
		
		if (student1.CalculateGPA() > student2.CalculateGPA() && student1.CalculateGPA() > student3.CalculateGPA())
			{
			System.out.println("First is :");
			
			student1.DisplayStudentInfo();
			}
		else if (student2.CalculateGPA() > student1.CalculateGPA() && student2.CalculateGPA() > student3.CalculateGPA())
		{
			System.out.println("First is :");
			
			student2.DisplayStudentInfo();
			}
		else
		{
			{
				System.out.println("First is :");
				
				student3.DisplayStudentInfo();
				}
		}
		
		


		

	}

}

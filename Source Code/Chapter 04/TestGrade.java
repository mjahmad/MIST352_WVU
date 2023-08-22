/**
 * The TestGrade class determines a letter grade
 * based on a numeric test score.
 */

public class TestGrade
{
   private int score;

   /**
    * The constructor accepts an argument
    * for the score field.
    */

   public TestGrade(int s)
   {
      score = s;
   }

   /**
    * The setScore method accepts an argument   
    * for the score field.
    */

   public void SetScore(int s)
   {
      score = s;
   }

   /**
    * The getScore method returns the score field.
    */

   public int getScore()
   {
      return score;
   }

   /**
    * The getLetterGrade returns the letter
	 * grade for the test score.
    */

   public char getLetterGrade()
   {
      char grade;

      if (score < 60)
		{
         grade = 'F';
		}
      else
		{
			if (score < 70)
			{
	         grade = 'D';
			}
	      else
			{
				if (score < 80)
				{
		         grade = 'C';
		  		}    
				else
				{
					if (score < 90)
					{
			         grade = 'B';
					}
			      else
					{ 
			         grade = 'A';
					}
				}
			}
		}

      return grade;
   }
}

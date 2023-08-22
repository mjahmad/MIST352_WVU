/**
 * This class determines the grade for a final exam.
 */

public class FinalExam extends GradedActivity
{
   private int numQuestions;  // Number of questions
   private double pointsEach; // Points for each question
   private int numMissed;     // Number of questions missed

   /**
    * The constructor accepts as arguments the number 
    * of questions on the exam and the number of      
    * questions the student missed.
    */

   public FinalExam(int questions, int missed)
   {
      double numericScore;  // To calculate the numeric score

      // Set the numQuestions and numMissed fields.
      numQuestions = questions;
      numMissed = missed;

      // Calculate the points for each question and
      // the numeric score for this exam.
      pointsEach = 100.0 / questions;
      numericScore = 100.0 - (missed * pointsEach);

      // Call the superclass's setScore method to
      // set the numeric score.
      setScore(numericScore);
   }

   /**
    * The getPointsEach method returns the pointsEach 
    * field. 
    */

   public double getPointsEach()
   {
      return pointsEach;
   }

   /**
    * The getNumMissed method returns the numMissed   
    * field.
    */

   public int getNumMissed()
   {
      return numMissed;
   }
}

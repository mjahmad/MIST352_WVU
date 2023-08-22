/**
 *  This class determines the grade for final a exam. The 
 *  numeric score is rounded up to the next whole number 
 *  if its fractional part is .5 or greater.
 */

public class FinalExam2 extends GradedActivity2
{
   private int numQuestions;  // Number of questions
   private double pointsEach; // Points for each question
   private int numMissed;     // Number of questions missed

   /**
    * The constructor accepts as arguments the number 
    * of questions on the exam and the number of      
    * questions the student missed.
    */

   public FinalExam2(int questions, int missed)
   {
      double numericScore;  // To hold the numeric score

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
      adjustScore();
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

   /**
    * The adjustScore method adjusts a numeric score. 
    * If score is within 0.5 points of the next whole 
    * number, it rounds the score up.
    */

   private void adjustScore()
   {
      double fraction;  // Fractional part of a score

      // Get the fractional part of the score.
      fraction = score - (int) score;

      // If the fractional part is .5 or greater,
      // round the score up to the next whole number.
      if (fraction >= 0.5)
         score = score + (1.0 - fraction);
   }
}
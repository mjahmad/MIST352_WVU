/**
 *  This class determines the grade for a final exam.
 */

public class FinalExam3 extends GradedActivity implements Relatable
{
   private int numQuestions;  // Number of questions
   private double pointsEach; // Points for each question
   private int numMissed;     // Questions missed

   /**
    *  The constructor sets the number of questions on the
    *  exam and the number of questions missed.
    */

   public FinalExam3(int questions, int missed)
   {
      double numericScore;  // To hold a numeric score

      // Set the numQuestions and numMissed fields.
      numQuestions = questions;
      numMissed = missed;

      // Calculate the points for each question and
      // the numeric score for this exam.
      pointsEach = 100.0 / questions;
      numericScore = 100.0 - (missed * pointsEach);

      // Call the inherited setScore method to
      // set the numeric score.
      setScore(numericScore);
   }

   /**
    *  The getPointsEach method returns the number of
    *  points each question is worth.
    */

   public double getPointsEach()
   {
      return pointsEach;
   }

   /**
    *  The getNumMissed method returns the number of 
    *  questions missed.
    */

   public int getNumMissed()
   {
      return numMissed;
   }

   /**
    *  The equals method compares the calling object
    *  to the argument object for equality.
    */

   public boolean equals(GradedActivity g)
   {
      boolean status; 

      if (this.getScore() == g.getScore())
         status = true;
      else
         status = false;

      return status;
   }

   /**
    *  The isGreater method determines whether the calling
    *  object is greater than the argument object.
    */

   public boolean isGreater(GradedActivity g)
   {
      boolean status; 

      if (this.getScore() > g.getScore())
         status = true;
      else
         status = false;

      return status;
   }

   /**
    *  The isLess method determines whether the calling
    *  object is less than the argument object.
    */

   public boolean isLess(GradedActivity g)
   {
      boolean status; 

      if (this.getScore() < g.getScore())
         status = true;
      else
         status = false;

      return status;
   }
}
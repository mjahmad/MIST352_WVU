/**
 *  This class holds a numeric score and determines
 *  whether the score is passing or failing.
 */

public class PassFailActivity extends GradedActivity
{
   private double minPassingScore;  // Minimum passing score

   /**
    * The constructor accepts the minimum passing
    * score as its argument.
    */

   public PassFailActivity(double mps)
   {
      minPassingScore = mps;
   }

   /**
    * The getGrade method returns a letter grade determined 
    * from the score field. This method overrides the getGrade
    * method in the superclass.
    */
    
   @Override
   public char getGrade()
   {
      char letterGrade; // To hold the letter grade

      if (super.getScore() >= minPassingScore)
         letterGrade = 'P';
      else
         letterGrade = 'F';

      return letterGrade;
   }
}
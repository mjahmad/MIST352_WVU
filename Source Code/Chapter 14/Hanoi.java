/**
 *  This class displays a solution to the Towers of
 *  Hanoi game. 
 */

public class Hanoi
{
   private int numDiscs;   // Number of discs
   
   /**
    *  Constructor. The argument is the number of
    *  discs to use.
    */
   
   public Hanoi(int n)
   {
      // Assign the number of discs.
      numDiscs = n;
      
      // Move the number of discs from peg 1 to peg 3
      // using peg 2 as a temporary storage location.
      moveDiscs(numDiscs, 1, 3, 2);
   }

   /**
    *  The moveDiscs method accepts the number of
    *  discs to move, the peg to move from, the peg
    *  to move to, and the temporary peg as arguments.
    *  It uses recursion to display the necesssary
    *  disc moves.
    */
   
   private void moveDiscs(int num, int fromPeg, int toPeg,
                          int tempPeg)
   {
      if (num > 0)
      {
         moveDiscs(num - 1, fromPeg, tempPeg, toPeg);
         System.out.println("Move a disc from peg " +
                            fromPeg + " to peg " + toPeg);
         moveDiscs(num - 1, tempPeg, toPeg, fromPeg);
      }
   }
}
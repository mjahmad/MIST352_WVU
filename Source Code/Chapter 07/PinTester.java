/**
 * The PinTester class is used to compare the PIN that
 * was entered by a user to the valid PIN.
 */

public class PinTester
{

	/**
	 * The compare method accepts two int arrays, which are 
     * compared. If they contain the same values, true is   
     * returned. Otherwise, false is returned. 
	 */

   public static boolean compare(int [] userPin, 
                                 int [] validPin)
   {
      int i;            // Loop control variable
      boolean isEqual;  // Flag 

      // Compare the lengths of the two arrays. If 
      // the arrays are not the same size, then they
      // are not equal.
      if (userPin.length != validPin.length)
         isEqual = false;

      else   // Compare the contents of the two arrays
      {
         i = 0;
         isEqual = true;

         while (isEqual && i < userPin.length)
         {
            if (userPin[i] != validPin[i])
               isEqual = false;
            i++;
         }
      }

      return isEqual;
   }
}


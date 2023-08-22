/**
 * This program tests the PinTester.compare method by calling it
 * several times with various arguments.
 */

public class PinTesterDemo
{
   public static void main(String [] args)
   {
      // Create some numeric arrays for testing.
      int [] pin1 = {2, 4, 1, 8, 7, 9, 0};
      int [] pin2 = {2, 4, 1, 8, 7, 9, 0};
      int [] pin3 = {2, 4, 6, 8, 7, 9, 0};
      int [] pin4 = {1, 2, 3, 4, 5, 6, 7};

      // Compare pin1 and pin2. These arrays are identical.
      if (PinTester.compare(pin1, pin2))
      {
         System.out.println("SUCCESS: pin1 and pin2 "
                          + "are the same.");
      }
      else
      {
         System.out.println("ERROR: pin1 and pin2 "
                          + "are different.");
       }

      // Compare pin1 and pin3. These arrays differ by 
      //only one element.
      if (PinTester.compare(pin1, pin3))
      {
         System.out.println("ERROR: pin1 and pin3 "
                          + "are the same.");
      }
      else
      {
         System.out.println("SUCCESS: pin1 and pin3 "
                          + "are different.");
      }

      // Compare pin1 and pin4. All of the elements in these 
      // arrays are different.
      if (PinTester.compare(pin1, pin4))
      {
         System.out.println("ERROR: pin1 and pin4 "
                          + "are the same.");
      }
      else
      {
         System.out.println("SUCCESS: pin1 and pin4 "
                          + "are different.");
      }
   }
}

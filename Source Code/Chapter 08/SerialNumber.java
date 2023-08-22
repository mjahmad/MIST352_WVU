import java.util.StringTokenizer;

/**
 * The SerialNumber class takes a software serial number in
 * the form of LLLLL-DDDD-LLLL where each L is a letter
 * and each D is a digit. The serial number has three groups
 * of characters, separated by hyphens. The class extracts
 * the three groups of characters and validates them.
 */

public class SerialNumber
{
   private String first;   // First group of characters
   private String second;  // Second group of characters
   private String third;   // Third group of characters
   private boolean valid;  // Flag indicating validity

	/**
	 * The following constructor accepts a serial number as 
     * its String argument. The argument is broken into     
     * three groups and each group is validated.       
	 */

   public SerialNumber(String sn)
   {
      // Create a StringTokenizer and initialize
      // it with a trimmed copy of sn. 
      StringTokenizer st =
             new StringTokenizer(sn.trim(), "-");

      // Tokenize and validate.
      if (st.countTokens() != 3)
         valid = false;
      else
      {
         first = st.nextToken();
         second = st.nextToken();
         third = st.nextToken();
         validate();
      }

   }

	/**
	 * The following method returns the valid field.
	 */

   public boolean isValid()
   {
       return valid;
   }

	/**
	 * The following method sets the valid field to true 
     * if the serial number is valid. Otherwise it sets  
     * valid to false.
	 */

   private void validate()
   {
      if (isFirstGroupValid() && isSecondGroupValid() && 
          isThirdGroupValid())
         valid = true;
      else
         valid = false;
   }

	/**
	 * The following method validates the first group of
     * characters. If the group is valid, it returns
     * true. Otherwise it returns false.
	 */

   private boolean isFirstGroupValid()
   {
      boolean groupGood = true;  // Flag
      int i = 0;  // Loop control variable

      // Check the length of the group.
      if (first.length() != 5)
         groupGood = false;

      // See if each character is a letter.
      while (groupGood && i < first.length())
      {
         if (!Character.isLetter(first.charAt(i)))
            groupGood = false;
         i++;
      }

      return groupGood;
   }

	/**
	 * The following method validates the second group
     * of characters. If the group is valid, it returns
     * true. Otherwise it returns false.
	 */

   private boolean isSecondGroupValid()
   {
      boolean groupGood = true; // Flag
      int i = 0; // Loop control variable

      // Check the length of the group.
      if (second.length() != 4)
         groupGood = false;

      // See if each character is a digit.
      while (groupGood && i < second.length())
      {
         if (!Character.isDigit(second.charAt(i)))
            groupGood = false;
         i++;
      }

      return groupGood;
   }

	/**
	 * The following method validates the third group of 
     * characters. If the group is valid, it returns
     * true. Otherwise it returns false.
	 */

   private boolean isThirdGroupValid()
   {
      boolean groupGood = true; // Flag
      int i = 0; // Loop control variable

      // Check the length of the group.
      if (third.length() != 4)
         groupGood = false;

      // See if each character is a letter.
      while (groupGood && i < third.length())
      {
         if (!Character.isLetter(third.charAt(i)))
            groupGood = false;
         i++;
      }

      return groupGood;
   }
}


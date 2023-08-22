/**
 * This class stores a person's first, last, and middle names.   
 * The class is dangerous because it does not prevent operations 
 * on null reference fields.
 */

public class FullName
{
   private String lastName,   // To hold a last name
                  firstName,  // To hold a first name
                  middleName; // To hold a middle name

   /**
    * The following method sets the lastName field.
    */

   public void setLastName(String str)
   {
      lastName = str;
   }

   /**
    * The following method sets the firstName field.
    */

   public void setFirstName(String str)
   {
      firstName = str;
   }

   /**
    * The following method sets the middleName field.
    */

   public void setMiddleName(String str)
   {
      middleName = str;
   }

   /**
    * The following method returns the length of the  
    * full name.
    */

   public int getLength()
   {
      return lastName.length() + firstName.length() +
             middleName.length();
   }

   /**
    * The following method returns the full name.
    */

   public String toString()
   {
      return firstName + " " + middleName + " " +
             lastName;
   }
}

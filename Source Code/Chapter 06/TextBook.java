/**
 * This class stores information about a textbook.
 */

public class TextBook
{
   private String title,     // Title of the book
                  author,    // Author's last name
                  publisher; // Name of publisher

   /**
    * This constructor accepts arguments for the   
    * title, author, and publisher.
    */

   public TextBook(String textTitle, String auth,
                   String pub)
   {
      title = textTitle;
      author = auth;
      publisher = pub;
   }

   /**
    * Copy constructor  
    */
   
   public TextBook(TextBook object2)
   {
      title = object2.title;
      author = object2.author;
      publisher = object2.publisher;
   }
   
   /**
    * The set method sets each field.
    */
   
   public void set(String textTitle, String auth,
                   String pub)
   {
      title = textTitle;
      author = auth;
      publisher = pub;
   }

   /**
    * The toString method returns a string containing 
    * the textbook information. 
    */

   public String toString()
   {
      // Create a string representing the object.
      String str = "Title: " + title +
                   "\nAuthor: " + author +
                   "\nPublisher: " + publisher;

      // Return the string.
      return str;
   }
}
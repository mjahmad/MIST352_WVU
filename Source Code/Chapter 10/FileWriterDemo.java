import java.util.Scanner;
import java.io.*;

/**
 * This program demonstrates writing to a file using a
 * a PrintWriter object.  
 */

public class FileWriterDemo
{
   public static void main(String[] args)
   {
      String filename,   // The file name
             firstName,  // To hold a first name
             middleName, // To hold a middle name
             lastName;   // To hold a last name
             
      // Create a Scanner object for keyboard input.
      Scanner keyboard = new Scanner(System.in);

      // Get the file name.
      System.out.print("Enter a file name: ");
      filename = keyboard.nextLine();

      try
      {
         // Create the file.
         PrintWriter outputFile = 
            new PrintWriter(new FileWriter(filename));

         // Get the user's first name and write it.
         System.out.print("What is your first name? ");
         firstName = keyboard.nextLine();
         outputFile.println(firstName);

         // Get the user's middle name and write it.
         System.out.print("What is your middle name? ");
         middleName = keyboard.nextLine();
         outputFile.println(middleName);

         // Get the user's last name and write it.
         System.out.print("What is your last name? ");
         lastName = keyboard.nextLine();
         outputFile.println(lastName);

         // Close the file.
         outputFile.close();
      }
      catch (IOException e)
      {
         System.out.println("Error: " + e.getMessage());
      }
   }
}


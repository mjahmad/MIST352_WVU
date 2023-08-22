import java.io.*;

/**
 * This program opens a binary file and writes a series of strings
 * using UTF-8 encoding.
 */

public class WriteUTF
{
   public static void main(String[] args) throws IOException
   {
      String names[] = { "Warren", "Becky", "Holly", "Chloe" };
      FileOutputStream fstream = new FileOutputStream("UTFnames.dat");
      DataOutputStream outputFile = new DataOutputStream(fstream);
      
      System.out.println("Writing the names to the file...");
      
      for (int i = 0; i < names.length; i++)
         outputFile.writeUTF(names[i]);
      
      System.out.println("Done.");
      outputFile.close();     
   }
}

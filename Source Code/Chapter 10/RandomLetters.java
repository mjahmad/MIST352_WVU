import java.io.*;

public class RandomLetters
{
	public static void main(String[] args) throws IOException
	{
		RandomAccessFile randomFile = new RandomAccessFile("Letters.txt", "r");
		char ch;
		
		// Move to the byte 5 from the beginning of the file.
		// This is actually the 6th byte. The first byte is
		// byte 0.
		randomFile.seek(5);
		
		// Read the character stored at this location and display it.
		ch = (char) randomFile.readByte();
		System.out.println(ch);
		
		// Move to byte 10, read the character, and display it.
		randomFile.seek(10);
		ch = (char) randomFile.readByte();
		System.out.println(ch);
		
		// Now move to byte 3, read the character, and display it.
		randomFile.seek(3);
		ch = (char) randomFile.readByte();
		System.out.println(ch);
		
		// Close the file.
		randomFile.close();
	}
}

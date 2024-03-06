/**
 * 
 */
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;
/**
 * 
 */
public class Task5 {

	/**
	 * @param args
	 * @throws FileNotFoundException 
	 */
	public static void main(String[] args) throws FileNotFoundException {
		// TODO Auto-generated method stub


		PrintWriter outPutFile = new PrintWriter("web_page.html");
		Scanner scnUserInput = new Scanner(System.in);
		System.out.println("Enter your name:\t");
		String strName = scnUserInput.nextLine();
		
		System.out.println("Describe yourself:\t");
		String strInfo = scnUserInput.nextLine();
		outPutFile.println("<html>");
		outPutFile.println("<head>");
		outPutFile.println("</head>");
		outPutFile.println("<body>");
		outPutFile.println("\t<center>");
		outPutFile.printf("\t\t<h1>%s</h1>\n",strName);
		outPutFile.println("\t</center>");
		outPutFile.println("\t<hr />");
		outPutFile.printf("\n \t %s \n",strInfo);
		outPutFile.println("\t <hr />");
		outPutFile.println("</body>");
		outPutFile.println("</html>");
		scnUserInput.close();
		outPutFile.close();

		
		

	}

}

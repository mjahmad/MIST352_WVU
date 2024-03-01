/**
 * An example on how to use GUI with switches
 */

/**
 * 
 */
import javax.swing.JOptionPane;

public class FancyGUI {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub


		int intOption =Integer.parseInt(JOptionPane.showInputDialog(null, "Hello, give me a value:"
				+ " \n 1: to show all cats \n 2: to show all dogs\n 3: send you home\n"));
		switch(intOption) 
		{
		case(1):
			int intCheck = JOptionPane.showConfirmDialog(null, "You choose 1 : Cats are: Whisper, fluffkinz, Quincy, and Stinky");
				if (intCheck==0)
				{
					System.out.println("You choose Yes");
				}
				else if (intCheck==1)
				{
					System.out.println("You choose No");
				}
				else
				{
					System.out.println("You choose cancel");
				}

			break;
		
		case(2):
			JOptionPane.showConfirmDialog(null, "You choose 2 : dogs are: Sam, Buck");
			break;
		
		case(3):
			JOptionPane.showConfirmDialog(null, "You choose 3 : yoiu can go home.");
			break;
		
		default:
			JOptionPane.showConfirmDialog(null, "Wrong option");
			break;
		}
		

	}

}

import javax.swing.JOptionPane;

/**
 *  This program demonstrates using dialogs
 *  with JOptionPane.
 */

public class PayrollDialog
{
   public static void main(String[] args)
   {
      String name,         // The user's name
             inputString;  // To hold input
      int hours;           // Hours worked
      double payRate,      // Hourly pay rate
             grossPay;     // Gross pay

      // Get the user's name.
      name = JOptionPane.showInputDialog("What is your name?");
      
      // Get the hours worked.
      inputString = JOptionPane.showInputDialog("How many hours " +
                                        "did you work this week?");
      hours = Integer.parseInt(inputString);
      
      // Get the hourly pay rate.
      inputString = JOptionPane.showInputDialog("What is your " +
                                                "hourly pay rate?");
      payRate = Double.parseDouble(inputString);
      
      // Calculate the gross pay.
      grossPay = hours * payRate;
      
      // Display the results.
      JOptionPane.showMessageDialog(null, "Hello " + name +
                        ". Your gross pay is $" + grossPay);

      // End the program.
      System.exit(0);
   }
}

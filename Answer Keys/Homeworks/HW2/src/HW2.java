/**
 * The MIST352 HW2 answer key
 * Author: MJ Ahmad
 * Date: 3/1/2024
 */
import javax.swing.JOptionPane;

public class HW2 {
    public static void main(String[] args) {
        // Welcome Message
        JOptionPane.showMessageDialog(null, "Welcome to Java Juice Bar!");

        // Juice Selection
        String juiceChoice = JOptionPane.showInputDialog("Select your base juice:\n" +
                "1. Apple - $5.00\n" +
                "2. Orange - $4.50\n" +
                "3. Mango - $6.00\n" +
                "4. Carrot - $5.50");
        int juice = Integer.parseInt(juiceChoice);
        double price = 0.0;
        String juiceName = "";
        boolean isMangoAndGinger = false; // To track if the discount condition is met

        // Switch Statement for Juice Selection
        switch (juice) {
            case 1:
                price = 5.00;
                juiceName = "Apple";
                break;
            case 2:
                price = 4.50;
                juiceName = "Orange";
                break;
            case 3:
                price = 6.00;
                juiceName = "Mango";
                break;
            case 4:
                price = 5.50;
                juiceName = "Carrot";
                break;
            default:
                JOptionPane.showMessageDialog(null, "Invalid selection. Please restart the program.");
                System.exit(0);
        }

        // Add-Ons
        int addGinger = JOptionPane.showConfirmDialog(null, "Would you like to add ginger for an extra $1.00?", "Add Ginger", JOptionPane.YES_NO_OPTION);
        if (addGinger == JOptionPane.YES_OPTION) {
            price += 1.00; // Adding price for ginger
            if (juice == 3) { // Checking if Mango is selected
                isMangoAndGinger = true;
            }
        }

        double fullPrice = price; // Full price before any discounts
        double discount = 0;
        if (isMangoAndGinger) {
            discount = 0.50; // Discount for Mango with Ginger
            price -= discount; // Applying discount
        }

        double totalBeforeTax = price; // Total before tax
        double tax = totalBeforeTax * 0.16; // Calculating tax on the discounted price
        double totalAfterTax = totalBeforeTax + tax; // Total after adding tax

        // Building the fancier final bill message
        String bill = String.format(
                "|| Final Bill ||\n" +
                "------------------------\n" +
                "Base Juice: %s - $%.2f\n" +
                "%s" +
                "------------------------\n" +
                "Full Price: $%.2f\n" +
                "Discount: -$%.2f\n" +
                "------------------------\n" +
                "Total Before Tax: $%.2f\n" +
                "Tax: $%.2f\n" +
                "------------------------\n" +
                "Total After Tax: $%.2f\n" +
                "------------------------",
                juiceName, fullPrice - (addGinger == JOptionPane.YES_OPTION ? 1.00 : 0), 
                addGinger == JOptionPane.YES_OPTION ? "Add-On: Ginger - $1.00\n------------------------\n" : "", 
                fullPrice, discount, totalBeforeTax, tax, totalAfterTax);

        JOptionPane.showMessageDialog(null, bill);
    }
}



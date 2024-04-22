import java.text.DecimalFormat;

/**
 * Chapter 6
 * Programming Challenge 3: Carpet Calculator
 * The RoomCarpet class stores information
 * about the carpeting of a room.
 */

public class RoomCarpet
{
   private RoomDimension size;   // The size of the room
   private double carpetCost;    // Carpet cost per square foot
   
   /**
    * Constructor
    */

   public RoomCarpet(RoomDimension dim, double cost)
   {
      // Make size reference a copy of the object referenced
      // by the dim argument.
      size = new RoomDimension(dim.getLength(), dim.getWidth());
      
      // Assign the cost.
      carpetCost = cost;
   }
   
   /**
    * getTotalCost method
    */

   public double getTotalCost()
   {
      // Return the total cost.
      return carpetCost * size.getArea();
   }

   /**
    * toString method
    */
   
   public String toString()
   {
      // Create a DecimalFormat object to format output.
      DecimalFormat dollar = new DecimalFormat("#,##0.00");
      
      // Create a String with the object state.
      String str = "Room dimensions:\n" +
                   size + "\nCarpet cost: $" +
                   dollar.format(getTotalCost());
      
      // Return the String
      return str;
   }
}

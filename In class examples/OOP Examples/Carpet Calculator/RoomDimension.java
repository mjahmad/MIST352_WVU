/**
 * Chapter 6
 * Programming Challenge 3: Carpet Calculator
 * The RoomDimension class stores information
 * about the dimensions of a room.
 */

public class RoomDimension
{
   private double length;     // Room length
   private double width;      // Room width

   /**
    * Constructor
    */
   
   public RoomDimension(double len, double w)
   {
      length = len;
      width = w;
   }
   
   /**
    * getLength method
    */

   public double getLength()
   {
      return length;
   }

   /**
    * getWidth method
    */

   public double getWidth()
   {
      return width;
   }

   /**
    * getArea method
    */

   public double getArea()
   {
      return length * width;
   }

   /**
    * toString method
    */

   public String toString()
   {
      String str = "Length: " + length +
                   "  Width: " + width +
                   "  Area: " + getArea();
      return str;
   }
}

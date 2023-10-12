/**
 * Rectangle class, We worked on this in class.
 * Under Construction!
 */

public class Rectangle
{
   private double length;
   private double width;
   private double area;

   /**
    * The setLength method accepts an argument
    * that is stored in the length field.
    */

   //Constructor1
   //Meaning: Allow users to create Rectangle by 
   //providing Length and Width upon creation (Line 14 in RectangleDemo)
   
   
   public Rectangle (double theLength, double theWidth)
   {
	   length = theLength;
	   width = theWidth;
	   area = length * width;
   }
   
   //Constructor2
   //Meaning: Allow users to create Rectangle without providing Length or Width.
   // See line 10 in RectangleDemo

   public Rectangle ()
   {
	   
	   area = length * width;
   }
   
   public void setArea()
   {
	   area = length * width;
   }
   
   public void setLength(double len)
   {
      length = len;
   }
   
   public double ViewLength()
   {
	   return length;
   }
   

   public void setWidth(double wid)
   {
      width = wid;
   }
   
   public double ViewWidth()
   {
	   return width;
   }

   
   public void viewRectangleInfo()
   {
	   System.out.printf("The rectangle with width %f and "
	   		+ "length %f has an area of %f\n",width,length,area);
   }
   
   
   
   
}

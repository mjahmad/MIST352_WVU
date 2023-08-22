/**
 *  This class holds data about a cube.
 */

public class Cube extends Rectangle
{
   private double height;  // The height of the cube

   /**
    *  The constructor accepts the cube's length,  
    *  width, and height as arguments.   
    */

   public Cube(double len, double w, double h)
   {
      // Call the superclass constructor to
      // initialize length and width.
      super(len, w);
      
      // Initialize height.
      height = h;
   }

   /**
    *  The getHeight method returns the height     
    *  field. 
    */

   public double getHeight()
   {
      return height;
   }

   /**
    *  The getSurfaceArea method returns the       
    *  cube's surface area. 
    */

   public double getSurfaceArea()
   {
      return getArea() * 6;
   }

   /**
    *  The getVolume method returns the volume of 
    *  the cube.
    */

   public double getVolume()
   {
      return getArea() * height;
   }
}
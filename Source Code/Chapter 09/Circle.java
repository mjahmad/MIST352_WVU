public class Circle extends Shape
{
     private double radius;

     public void setRadius(double r)
     {
          radius = r;
          setArea(Math.PI * r * r);
     }

     public double getRadius()
     {
          return radius;
     }
};

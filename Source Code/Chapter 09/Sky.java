public class Sky extends Ground
{
     public Sky()
     {
          System.out.println("You are in the sky.");
     }

     public Sky(String skyColor)
     {
          super("green");
          System.out.println("The sky is " + skyColor);
     }
}

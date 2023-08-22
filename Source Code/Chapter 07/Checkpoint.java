public class CheckPoint
{
     public static void main(String [] args)
     {
          int[] values = new int[5];

          for (int count = 0; count < 5; count++)
               values[count] = count + 1;

          for (int count = 0; count < 5; count++)
               System.out.println(values[count]);
     }
}

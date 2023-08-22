/**
 *  DvdMovie class 
 */

public class DvdMovie implements RetailItem
{
   private String title;       // The DVD's title
   private int runningTime;    // Running time in minutes
   private double retailPrice; // The DVD's retail price
   
   /**
    *  Constructor
    */

   public DvdMovie(String dvdTitle, int runTime, double dvdPrice)
   {
      title = dvdTitle;
      runningTime = runTime;
      retailPrice = dvdPrice;
   }
   
   /**
    *  getTitle method
    */

   public String getTitle()
   {
      return title;
   }
   
   /**
    *  getRunningTime method  
    */

   public int getRunningTime()
   {
      return runningTime;
   }

   /**
    *  getRetailPrice method (Required by the RetailItem  
    *  interface)
    */

   public double getRetailPrice()
   {
      return retailPrice;
   }
}
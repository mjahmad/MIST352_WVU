/**
 *  Compact Disc class
 */

public class CompactDisc implements RetailItem
{
   private String title;       // The CD's title
   private String artist;      // The CD's artist
   private double retailPrice; // The CD's retail price
   
   /**
    *  Constructor
    */

   public CompactDisc(String cdTitle, String cdArtist, double cdPrice)
   {
      title = cdTitle;
      artist = cdArtist;
      retailPrice = cdPrice;
   }
   
   /**
    *  getTitle method
    */

   public String getTitle()
   {
      return title;
   }
   
   /**
    *  getArtist method 
    */

   public String getArtist()
   {
      return artist;
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
import java.io.Serializable;

/**
 * This class throws an IllegalArgumentException when an
 * empty string is passed as a description, or 0 is
 * passed as the number of units.
 */

public class InventoryItem2 implements Serializable
{
   private String description;
   private int units;

	/**
	 * No-arg constructor
	 */

   public InventoryItem2()
   {
      description = "";
      units = 0;
   }

	/**
	 * The following constructor accepts a
     * String argument which is assigned to the
     * description field.
	 */

   public InventoryItem2(String d)
   {
      if (d.equals(""))
      {
         throw new IllegalArgumentException("Description is an empty string.");
      }

      description = d;
      units = 0;
   }

	/**
	 * The following constructor accepts a
     * String argument which is assigned to the
     * description field, and an int argument
     * which is assigned to the units field. 
	 */

   public InventoryItem2(String d, int u)
   {
      if (d.equals(""))
      {
         throw new IllegalArgumentException("Description is an empty string.");
      }
      if (u < 0)
         throw new IllegalArgumentException("Units is 0.");

      description = d;
      units = u;
   }

	/**
	 * The setDescription method assigns its
     * argument to the description field. 
	 */
   
   public void setDescription(String d)
   {
      if (d.equals(""))
      {
         throw new IllegalArgumentException("Description is an empty string.");
      }

      description = d;
   }

	/**
	 * The setUnits method assigns its argument
	 * to the units field. 
	 */

   public void setUnits(int u)
   {
      if (u < 0)
         throw new IllegalArgumentException("Units is 0.");

      units = u;
   }

	/**
	 * The getDescription method returns the
     * value in the description field.
	 */

   public String getDescription()
   {
      return description;
   }

	/**
	 * The getUnits method returns the value in
     * the units field. 
	 */

   public int getUnits()
   {
      return units;
   }
}

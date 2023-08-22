/**
 * This class calculates a salesperson's gross
 * pay based on the amount of sales.
 */

public class SalesCommission
{
   private double sales,      // Monthly sales
                  rate,       // rate of commission
                  commission, // Amount of commission
                  advance,    // advanced pay
                  pay;        // Amount to pay


   /**
    * The constructor uses two parameters to accept
    * arguments: s and a. The value in s is assigned to
    * the sales field and the value in a is assigned to
    * the advance field. The calculatePay method is called.
    */

   public SalesCommission(double s, double a)
   {
      sales = s;
      advance = a;
      calculatePay();
   }

   /**
    * The setRate method sets the rate of commission,
    * based on the amount of sales. This method is called 
    * from the calculatePay method.
    */
   
   private void setRate()
   {
      if (sales < 10000)
         rate = 0.05;
      else if (sales < 15000)
         rate = 0.1;
      else if (sales < 18000)
         rate = 0.12;
      else if (sales < 22000)
         rate = 0.14;
      else
         rate = 0.16;
   }

   /**
    * The calculatePay method calculates the salesperson's
    * commission and amount of actual pay.
    */

   private void calculatePay()
   {
      setRate();
      commission = sales * rate;
      pay = commission - advance;
   }

   /**
    * The getPay method returns the pay field.
    */

   public double getPay()
   {
      return pay;
   }

   /**
    * The getCommission method returns the commission field.
    */

   public double getCommission()
   {
      return commission;
   }

   /**
    * The getRate method returns the rate field.
    */

   public double getRate()
   {
      return rate;
   }

   /**
    * The getAdvance method returns the advance field. 
    */

   public double getAdvance()
   {
      return advance;
   }

   /**
    * The getSales method returns the sales field. 
    */

   public double getSales()
   {
      return sales;
   }
}


/**
 * Chapter 3
 * Programming Challenge 4: Temperature Class
 * The Temperature class holds a temperature in 
 * Fahrenheit and provide methods to get the 
 * temperature in Fahrenheit, Celsius, and Kelvin. 
 */
 
public class Temperature
{
   // Fields
   private double ftemp;   // Fahrenheit temperature
   
   /**
    * The constructor accepts a Fahrenheit temperature
    * and stores it in the ftemp field.
    */
   
   public Temperature(double f)
   {
      ftemp = f;
   }
   
   /**
    * The setFahrenheit method accepts a Fahrenheit 
    * temperature and stores it in the ftemp field.
    */
   
   public void setFahrenheit(double f)
   {
      ftemp = f;
   }   
   
   /**
    * The getFahrenheit method returns the value
    * of the ftemp field as a Fahrenheit temperature.
    */
   
   public double getFahrenheit()
   {
      return ftemp;
   }   
   
   /**
    * The getCelsius method returns the converted value
    * of the ftemp field as a Celsius temperature.
    */
   
   public double getCelsius()
   {
      return (5.0 / 9.0) * (ftemp - 32.0);
   }     
   
   /**
    * The getKelvin method returns the converted value
    * of the ftemp field as a Kelvin temperature.
    */
   
   public double getKelvin()
   {
      return ((5.0 / 9.0) * (ftemp - 32.0)) + 273.0;
   }      
}
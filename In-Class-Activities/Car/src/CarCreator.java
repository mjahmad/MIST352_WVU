/**
 * 
 */

/**
 * @author MJ
 *
 */
public class CarCreator {

	   public static void main(String[] args) {
	        // Create a Car object
	        Car myCar = new Car("Toyota", "Camry", 2020, 25000.0);
	        Car oldCar = new Car();


	        // Display car information
	        myCar.displayInfo();
	        oldCar.displayInfo();
	    }

}

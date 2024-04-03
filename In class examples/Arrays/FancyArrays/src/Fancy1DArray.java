/**
 * This class creates a fancy one dimensional array that has several useful methods
 */
import java.util.Random;

/**
 * 
 */
public class Fancy1DArray {
    private int[] intArray;
    
  /**
   * Constructor 1: This assigns the array passed as a parameter to the instance variable of the object in Java. 
   * @param theArray : The array passed and created from the main method
   */
	public Fancy1DArray(int[] theArray)
	{
        this.intArray = theArray;
	}
	
	/**
	 * Constructor 2: This fills up the array with random numbers. The number of elements is passed from main
	 * @param size: the size of the array passed from the main method.
	 */
	public Fancy1DArray(int size)
	{
		this.intArray = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++) {
        	this.intArray [i] = random.nextInt(100); // Generate random numbers between 0 and 99


}
        

	}
	
	/**
	 * This method finds the minimum value in the array
	 * @return : the minimum value
	 */
	public int findMinimum() {
        int min = intArray[0];
        for (int i = 1; i < intArray.length; i++) {
            if (intArray[i] < min) {
                min = intArray[i];
            }
        }
        return min;
    }

	/**
	 * This method finds the maximum value in the array
	 * @return : the maximum value
	 */
    public int findMaximum() {
        int max = intArray[0];
        for (int i = 1; i < intArray.length; i++) {
            if (intArray[i] > max) {
                max = intArray[i];
            }
        }
        return max;
    }

    /**
	 * This method prints out the minimum value and its index in the array
	 * @return : the minimum value
	 */
    public void displayMinimumAndIndex() {
        int min = intArray[0];
        int index = 0;
        for (int i = 1; i < intArray.length; i++) {
            if (intArray[i] < min) {
                min = intArray[i];
                index = i;
            }
        }
        System.out.println("Minimum: " + min + ", Index: " + index);
    }

    /**
	 * This method prints out the maximum value and its index in the array
	 * @return : the maximum value
	 */
    public void displayMaximumAndIndex() {
        int max = intArray[0];
        int index = 0;
        for (int i = 1; i < intArray.length; i++) {
            if (intArray[i] > max) {
                max = intArray[i];
                index = i;
            }
        }
        System.out.println("Maximum: " + max + ", Index: " + index);
    }
    
    /**
	 * This method calculates the average value of all elements in the array
	 * @return : the average value
	 */

    public double findAverage() {
        int sum = 0;
        for (int j : intArray) {
            sum += j;
        }
        return sum / (double) intArray.length;
    }

    /**
     * This method decides whether a given value is in the array or not
     * @param element : the value from the main to find
     * @return: True if found, False if not found
     */
    public boolean containsElement(int element) {
        for (int j : intArray) {
            if (j == element) {
                return true;
            }
        }
        return false;
    }


	
	/**
	 * A method printout the elements of the array
	 */
	public void printArray() {
        for (int value : this.intArray) {
            System.out.print(value + " ");
        }
        System.out.println();
    }
	


}

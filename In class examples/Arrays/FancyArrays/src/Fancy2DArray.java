import java.util.Random;

/**
 * This class creates a fancy two-dimensional array that has several useful methods.
 */
public class Fancy2DArray {
    private int[][] intArray;

    /**
     * Constructor 1: Assigns a 2D array passed as a parameter to the instance variable of the object.
     * 
     * @param theArray The 2D array passed and created from the main method.
     */
    public Fancy2DArray(int[][] theArray) {
        this.intArray = theArray;
    }

    /**
     * Constructor 2: Fills up the 2D array with random numbers. The dimensions of the array are passed from main.
     * 
     * @param rows The number of rows in the 2D array.
     * @param cols The number of columns in the 2D array.
     */
    public Fancy2DArray(int rows, int cols) {
        this.intArray = new int[rows][cols];
        Random random = new Random();
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                this.intArray[i][j] = random.nextInt(100); // Generate random numbers between 0 and 99
            }
        }
    }

    /**
     * Finds the minimum value in the 2D array.
     * 
     * @return The minimum value.
     */
    public int findMinimum() {
        int min = intArray[0][0];
        for (int i = 0; i < intArray.length; i++) {
            for (int j = 0; j < intArray[i].length; j++) {
                if (intArray[i][j] < min) {
                    min = intArray[i][j];
                }
            }
        }
        return min;
    }

    /**
     * Finds the maximum value in the 2D array.
     * 
     * @return The maximum value.
     */
    public int findMaximum() {
        int max = intArray[0][0];
        for (int i = 0; i < intArray.length; i++) {
            for (int j = 0; j < intArray[i].length; j++) {
                if (intArray[i][j] > max) {
                    max = intArray[i][j];
                }
            }
        }
        return max;
    }

    /**
     * Prints out the minimum value and its position in the 2D array.
     */
    public void displayMinimumAndIndex() {
        int min = intArray[0][0];
        int rowIndex = 0, colIndex = 0;
        for (int i = 0; i < intArray.length; i++) {
            for (int j = 0; j < intArray[i].length; j++) {
                if (intArray[i][j] < min) {
                    min = intArray[i][j];
                    rowIndex = i;
                    colIndex = j;
                }
            }
        }
        System.out.println("Minimum: " + min + ", Row Index: " + rowIndex + ", Column Index: " + colIndex);
    }

    /**
     * Prints out the maximum value and its position in the 2D array.
     */
    public void displayMaximumAndIndex() {
        int max = intArray[0][0];
        int rowIndex = 0, colIndex = 0;
        for (int i = 0; i < intArray.length; i++) {
            for (int j = 0; j < intArray[i].length; j++) {
                if (intArray[i][j] > max) {
                    max = intArray[i][j];
                    rowIndex = i;
                    colIndex = j;
                }
            }
        }
        System.out.println("Maximum: " + max + ", Row Index: " + rowIndex + ", Column Index: " + colIndex);
    }

    /**
     * Calculates the average value of all elements in the 2D array.
     * 
     * @return The average value.
     */
    public double findAverage() {
        double sum = 0;
        int count = 0;
        for (int i = 0; i < intArray.length; i++) {
            for (int j = 0; j < intArray[i].length; j++) {
                sum += intArray[i][j];
                count++;
            }
        }
        return sum / count;
    }

    /**
     * Determines whether a given value is present in the 2D array.
     * 
     * @param element The value to find in the array.
     * @return True if found, false otherwise.
     */
    public boolean containsElement(int element) {
        for (int i = 0; i < intArray.length; i++) {
            for (int j = 0; j < intArray[i].length; j++) {
                if (intArray[i][j] == element) {
                    return true;
                }
            }
        }
        return false;
    }

    /**
     * Prints out the elements of the 2D array.
     */
    public void printArray() {
        for (int i = 0; i < intArray.length; i++) {
            for (int j = 0; j < intArray[i].length; j++) {
                System.out.print(intArray[i][j] + " ");
            }
            System.out.println();
        }
    }
    
    
}

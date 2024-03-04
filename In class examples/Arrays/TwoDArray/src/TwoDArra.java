/**
 * 
 */

/**
 * 
 * Examples of how to use Two Dimensional Arrays
 */
public class TwoDArra {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub

		// Creating and initializing a 2D array of integers
		// This creates a 2D array of int that has 6 elements arranged in 3 rows and 2 columns
		  int[][] intArray = {
		            {1, 2},
		            {3, 4},
		            {5, 6}
		        };

        
     // Accessing elements
        System.out.println("Element at intArray[0][0]: " + intArray[0][0]); // Outputs 1
        System.out.println("Element at intArray[0][1]: " + intArray[0][1]); // Outputs 2
        System.out.println("Element at intArray[2][1]: " + intArray[2][1]); // Outputs 6

     // Print the 2D array
        for (int intRow = 0; intRow < intArray.length; intRow++) {
            for (int intCol = 0; intCol < intArray[intRow].length; intCol++) {
                System.out.print(intArray[intRow][intCol] + " ");
            }
            System.out.println(); // Move to the next line after printing each row
        }
        
        
        
        // Create and initialize a 2D array of strings
        String[][] stringArray = {
            {"Hello", "World", "!"},
            {"Java", "2D", "Array"}
        };

        // Print the 2D array
        for (String[] row : stringArray) {
            for (String element : row) {
                System.out.print(element + " -- ");
            }
            System.out.println(); // Move to the next line after printing each row
        }
        
        
     // Create and initialize a 2D array of characters
        char[][] charArray = {
            {'A', 'B', 'C'},
            {'D', 'E', 'F'},
            {'G', 'H', 'I'},
            {'J', 'K', 'L'}
        };

        // Print the 2D array
        for (char[] row : charArray) {
            for (char element : row) {
                System.out.print(element + " ");
            }
            System.out.println(); // Move to the next line after printing each row
        }
       
     // Example 2D square array
        int[][] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        System.out.println("Primary Diagonal:");
        for (int i = 0; i < matrix.length; i++) {
            // Print primary diagonal (top-left to bottom-right)
            System.out.print(matrix[i][i] + " ");
        }

        System.out.println("\nSecondary Diagonal:");
        for (int i = 0; i < matrix.length; i++) {
            // Print secondary diagonal (top-right to bottom-left)
            System.out.print(matrix[i][matrix.length - 1 - i] + " ");
        }
        
        

	}
	

}

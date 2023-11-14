import java.util.Scanner;

/**
 * 
 */

/**
 * @author MJ
 *
 */
public class NestedLoopsExamples {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner userInput = new Scanner (System.in);
		System.out.println("How many rows do you want to print?");
		int numberOfRows = userInput.nextInt();
	
		 System.out.println("Triangle using nested for loops:");
	     printTriangleWithForLoops(numberOfRows);

	     System.out.println("\nTriangle using nested while loops:");
	     printTriangleWithWhileLoops(numberOfRows);

	     System.out.println("\nTriangle using nested do-while loops:");
	     printTriangleWithDoWhileLoops(numberOfRows);

	     System.out.println("\nTriangle using mixed nested loops:");
	     printTriangleWithMixedLoops(numberOfRows);
	     
	     
	  

			    
			  }
	/**
	 * Prints stars in a cool formation
	 * @param rows : number of rows to print
	 */
	public static void PrintStars(int rows)
	{
		
	    // outer loop
	    for (int i = 1; i <= rows; ++i) {

	      // inner loop to print the numbers
	      for (int j = 1; j <= i; ++j) {
	        System.out.print("*" + " ");
	      }
	      System.out.println("");
	    }
	}
	
	/**
	 * Prints out the even days in weeks
	 */
	public static void PrintWeekDays()
	{
		int weeks = 3;
	    int days = 7;

	    // outer loop
	    for(int i = 1; i <= weeks; ++i) {
	      System.out.println("Week: " + i);

	      // inner loop
	      for(int j = 1; j <= days; ++j) {
	        
	        // continue inside the inner loop
	        if(j % 2 != 0) {
	          continue;
	        }
	        System.out.println("  Days: " + j);
	      }
	}
	}	
	
	
	    /**
	     * Uses nested for loops to print a right-angled triangle of stars.
	     * @param rows the number of rows in the triangle
	     */
	public static void printTriangleWithForLoops(int rows) {
	        for (int i = 0; i < rows; i++) {
	            for (int j = 0; j <= i; j++) {
	                System.out.print("* ");
	            }
	            System.out.println();
	        }
	    }

	    /**
	     * Uses nested while loops to print a right-angled triangle of stars.
	     * @param rows the number of rows in the triangle
	     */
	public static void printTriangleWithWhileLoops(int rows) {
	        int i = 0;
	        while (i < rows) {
	            int j = 0;
	            while (j <= i) {
	                System.out.print("* ");
	                j++;
	            }
	            System.out.println();
	            i++;
	        }
	    }

	    /**
	     * Uses nested do-while loops to print a right-angled triangle of stars.
	     * @param rows the number of rows in the triangle
	     */
	public static void printTriangleWithDoWhileLoops(int rows) {
	        int i = 0;
	        do {
	            int j = 0;
	            do {
	                if (i < rows) {  // Checking condition as do-while executes at least once
	                    System.out.print("* ");
	                }
	                j++;
	            } while (j <= i);
	            System.out.println();
	            i++;
	        } while (i < rows);
	    }

	    /**
	     * Uses a combination of for, while, and do-while loops to print a right-angled triangle of stars.
	     * @param rows the number of rows in the triangle
	     */
	public static void printTriangleWithMixedLoops(int rows) {
	        for (int i = 0; i < rows; i++) {
	            int j = 0;
	            while (j <= i) {
	                int k = 0;
	                do {
	                    if (k == 0) {  // Print only once per iteration of while loop
	                        System.out.print("* ");
	                    }
	                    k++;
	                } while (k <= j);
	                j++;
	            }
	            System.out.println();
	        }
	    }
	    


	        /**
	         * Generates a magic square of a given size.
	         * @param n the size of the magic square (must be an odd number)
	         * @return a 2D array representing the magic square
	         */
	 public static int[][] generateMagicSquare(int n) {
	            if (n % 2 == 0) {
	                throw new IllegalArgumentException("Size must be an odd number.");
	            }

	            int[][] magicSquare = new int[n][n];

	            int number = 1;
	            int row = 0;
	            int column = n / 2;
	            int curr_row, curr_col;
	            while (number <= n * n) {
	                magicSquare[row][column] = number;
	                number++;
	                curr_row = row;
	                curr_col = column;
	                row -= 1;
	                column += 1;

	                if (row == -1) {
	                    row = n - 1;
	                }
	                if (column == n) {
	                    column = 0;
	                }
	                if (magicSquare[row][column] != 0) {
	                    row = curr_row + 1;
	                    column = curr_col;
	                    if (row == -1) {
	                        row = n - 1;
	                    }
	                }
	            }

	            return magicSquare;
	        }

	        /**
	         * Prints the magic square.
	         * @param magicSquare the magic square to be printed
	         */
	 public static void printMagicSquare(int[][] magicSquare) {
	            for (int i = 0; i < magicSquare.length; i++) {
	                for (int j = 0; j < magicSquare.length; j++) {
	                    System.out.print(magicSquare[i][j] + "\t");
	                }
	                System.out.println();
	            }
	        }

	       
	           
	        }
	    


	    
	      

	

	

	



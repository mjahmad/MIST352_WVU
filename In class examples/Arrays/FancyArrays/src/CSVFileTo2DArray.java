import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * This class reads the contents of a CSV file into a 2D array.
 * Each line in the CSV file represents a row in the 2D array, and each value, separated by commas,
 * represents a column within that row.
 */
public class CSVFileTo2DArray {
    private String[][] data;

    /**
     * Reads the contents of a CSV file into a 2D array.
     * 
     * @param filePath The path to the CSV file.
     * @param numberOfRows The number of rows expected in the CSV file.
     * @param numberOfColumns The number of columns expected in the CSV file.
     */
    public CSVFileTo2DArray(String filePath, int numberOfRows, int numberOfColumns) {
        this.data = new String[numberOfRows][numberOfColumns];
        try {
            File file = new File(filePath);
            Scanner scanner = new Scanner(file);
            int row = 0;
            while (scanner.hasNextLine() && row < numberOfRows) {
                String[] lineData = scanner.nextLine().split(",");
                for (int col = 0; col < numberOfColumns && col < lineData.length; col++) {
                    data[row][col] = lineData[col];
                }
                row++;
            }
            scanner.close();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred while reading the file.");
            e.printStackTrace();
        }
    }

    /**
     * Prints the contents of the 2D array to the console.
     */
    public void printArray() {
        for (int i = 0; i < data.length; i++) {
            for (int j = 0; j < data[i].length; j++) {
                System.out.print(data[i][j] + " ");
            }
            System.out.println();
        }
    }

 
}

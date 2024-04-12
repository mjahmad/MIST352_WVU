import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * A class that reads data from a CSV file into a 2-dimensional array.
 * The data can then be accessed and manipulated by instances of this class.
 */
public class CsvTo2DArray {

    private String[][] data; // Stores the CSV data

    /**
     * Constructor that initializes the CSVData object by loading data from a CSV file.
     *
     * @param fileLocation The path to the CSV file.
     * @throws FileNotFoundException If the file at the specified location does not exist.
     */
    public CsvTo2DArray(String fileLocation) throws FileNotFoundException {
        loadCSV(fileLocation);
    }

    /**
     * Loads data from a CSV file into a 2-dimensional array.
     *
     * @param fileLocation The path to the CSV file.
     * @throws FileNotFoundException If the file at the specified location does not exist.
     */
    private void loadCSV(String fileLocation) throws FileNotFoundException {
        File file = new File(fileLocation);
        Scanner rowScanner = new Scanner(file);

        // First determine the number of rows and columns
        int rows = 0;
        int columns = -1;
        while (rowScanner.hasNextLine()) {
            rows++;
            String line = rowScanner.nextLine();
            try (Scanner columnScanner = new Scanner(line)) {
                columnScanner.useDelimiter(",");
                int currentColumnCount = 0;
                while (columnScanner.hasNext()) {
                    currentColumnCount++;
                    columnScanner.next();
                }
                if (columns == -1) {
                    columns = currentColumnCount; // Set the number of columns based on the first row
                }
            }
        }
        rowScanner.close();

        // Initialize the data array
        data = new String[rows][columns];

        // Populate the 2-D array with CSV data
        Scanner fileScanner = new Scanner(new File(fileLocation));
        int row = 0;
        while (fileScanner.hasNextLine()) {
            String line = fileScanner.nextLine();
            Scanner columnScanner = new Scanner(line);
            columnScanner.useDelimiter(",");
            int col = 0;
            while (columnScanner.hasNext()) {
                data[row][col] = columnScanner.next();
                col++;
            }
            row++;
            columnScanner.close();
        }
        fileScanner.close();
    }

    /**
     * Prints the CSV data stored in the 2-dimensional array.
     */
    public void printData() {
        for (String[] row : data) {
            for (String cell : row) {
                System.out.print(cell + " ");
            }
            System.out.println();
        }
    }
}

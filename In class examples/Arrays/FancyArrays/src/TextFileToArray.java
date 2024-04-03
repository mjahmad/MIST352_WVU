import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * This class reads the contents of a text file into an array.
 * Each line in the text file is expected to be a separate entry in the array.
 */
public class TextFileToArray {
    private String[] data;

    /**
     * Reads the contents of a text file into an array.
     * 
     * @param filePath The path to the text file.
     * @param numberOfLines The number of lines (entries) expected in the text file.
     */
    public TextFileToArray(String filePath, int numberOfLines) {
        this.data = new String[numberOfLines];
        try {
            File file = new File(filePath);
            Scanner scanner = new Scanner(file);
            int index = 0;
            while (scanner.hasNextLine() && index < numberOfLines) {
                data[index++] = scanner.nextLine();
            }
            scanner.close();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred while reading the file.");
            e.printStackTrace();
        }
    }

    /**
     * Prints the contents of the array to the console.
     */
    public void printArray() {
        for (int i = 0; i < data.length; i++) {
            System.out.println(data[i]);
        }
    }

 
}

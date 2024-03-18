import java.time.LocalDate;
import java.time.Period;

/**
 * The Student class represents a student with personal information.
 * It includes methods to set and get student attributes, print student information,
 * and calculate the student's age based on their date of birth.
 */
public class Student {
    // Private attributes
    private String name;
    private LocalDate DOB; // Using LocalDate for date of birth
    private String ssn;
    private String address;

    // Constructor
    public Student() {
    }

    // Setters and Getters
    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setDOB(LocalDate DOB) {
        this.DOB = DOB;
    }

    public LocalDate getDOB() {
        return DOB;
    }

    public void setSsn(String ssn) {
        this.ssn = ssn;
    }

    public String getSsn() {
        return ssn;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getAddress() {
        return address;
    }

    /**
     * Prints the student's information in a readable format.
     */
    public void printStudentInfo() {
        System.out.println("Student Information:");
        System.out.println("Name: " + getName());
        System.out.println("Date of Birth: " + getDOB());
        System.out.println("SSN: " + getSsn());
        System.out.println("Address: " + getAddress());
    }

    /**
     * Calculates the student's age based on their date of birth and the current date.
     * @return The age of the student.
     */
    public int calculateAge() {
        if (DOB != null) {
            return Period.between(DOB, LocalDate.now()).getYears();
        } else {
            return 0; // If DOB is not set, return 0
        }
    }
}

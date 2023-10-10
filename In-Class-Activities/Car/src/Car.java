public class Car {
    // Fields (Attributes)
    private String make;
    private String model;
    private int year;
    private double price;

    // Constructor1 
    public Car(String make, String model, int year, double price) {
        this.make = make;
        this.model = model;
        this.year = year;
        this.price = price;
    }
    // Constructor2 

    public Car() {
        this.make = "Not Provided";
        this.model = "Not Provided";
        this.year = 0000;
        this.price = 0.0;
    }

    // Getter methods
    public String getMake() {
        return make;
    }

    public String getModel() {
        return model;
    }

    public int getYear() {
        return year;
    }

    public double getPrice() {
        return price;
    }

    // Setter methods
    public void setMake(String make) {
        this.make = make;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    // Method to display car information
    public void displayInfo() {
        System.out.println("---------------------------------");

    	System.out.println("Make: " + make);
        System.out.println("Model: " + model);
        System.out.println("Year: " + year);
        System.out.println("Price: $" + price);
        System.out.println("---------------------------------");

    }

 
}

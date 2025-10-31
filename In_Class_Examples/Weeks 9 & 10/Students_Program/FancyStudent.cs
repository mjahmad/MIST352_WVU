using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// ===============================
//  CLASS: FancyStudent
//  Demonstrates Encapsulation, Constructors, and Methods
// ===============================
//

public class FancyStudent
{
    // ============================================
    // 🧩 FIELDS (Private Variables)
    // --------------------------------------------
    // These hold the actual data for each object.
    // They are kept private to protect direct access.
    // ============================================
    private string name;
    private int age;
    private double gpa;


    // ============================================
    // PROPERTY (Encapsulation Layer)
    // --------------------------------------------
    // Properties control how fields are accessed or changed.
    // They can include validation logic inside get/set.
    // ============================================
    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                name = value;
            else
                throw new ArgumentException("Name cannot be empty.");
        }
    }


    // ============================================
    // CONSTRUCTORS (Object Initialization)
    // --------------------------------------------
    // Constructors are special methods that run
    // automatically when a new object is created.
    // They can be overloaded (same name, different parameters).
    // ============================================

    // Constructor that sets all fields when name, age and gpa are used to create the objects
    public FancyStudent(string name, int age, double gpa)
    {
        // Use property for validation when appropriate
        Name = name;   // ✅ Calls property setter
        this.age = age;
        this.gpa = gpa;
    }

    // Constructor that sets all fields when name, age and gpa are used to create the objects

    public FancyStudent(string name)
    {
        Name = name;   // ✅ Calls property setter
        this.age = 0;
        this.gpa = 0;
    }

    // Constructor that sets only the age
    public FancyStudent(int theAge)
    {
        this.name = "Not Provided";
        this.age = theAge;
        this.gpa = 0;
    }


    // ============================================
    // METHODS (Behavior / Actions)
    // --------------------------------------------
    // Methods define what the object can *do*.
    // They can display information, calculate results, etc.
    // ============================================

    // Displays object information to the console
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}, Age: {age}, GPA: {gpa}");
    }

    // Returns whether the student is an honor student
    public bool IsHonorStudent()
    {
        return gpa >= 3.5;
    }
}

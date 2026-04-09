using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


    public class STUDENT
    {
    private string FirstName;
    private string LastName;
    private string ID;
    private double firstGrades;



     //##################### CONSTRUCTORS ########################

    //Constructor1 (Create a student by providng thier first and last names)
    public STUDENT(string fName, string lName)
    {
        this.FirstName = fName;
        this.LastName = lName;
        this.ID = "00000";
        this.firstGrades = 0;   

    }

    //Constructor2 (Create a student by providng thier ID only)
    public STUDENT(string theID)
    {
        this.ID = theID;
        this.FirstName = "Not Provided";
        this.LastName = "Not Provided";
        this.firstGrades = 0;
    }
    //Constructor3 (Create a student by providng thier first, last name, and ID)

    public STUDENT(string theID, string fName, string lName)
    {
        this.FirstName = fName;
        this.LastName = lName;
        this.ID = theID;
        this.firstGrades = 0;
    }

    //##################### PROPERTIES ########################
    public string TheID{ 
        
        get => this.ID;
        set
        { this.ID = value; }
    }

    public string TheFirstName
    {

        get => this.FirstName;
        set
        {
            Console.WriteLine("Doi yo usee this?");
           
                while (value.Equals("Idiot" )|| value.Length<3 || value.StartsWith("_"))
                {
                    Console.WriteLine($"Invalid name {value}. Re-provide the first name");
                    value = Console.ReadLine();
                    this.FirstName = value;

                }
             
            
             }
    }

    public string TheLastName
    {

        get => this.LastName;
        set
        { this.LastName = value; }
    }

    public double TheGrade
    {

        get => this.firstGrades;
        set
        { this.firstGrades = value; }
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Hello {FirstName} {LastName}, Youd ID is {ID} and your GPA is {firstGrades}");
    }

    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Employee
    {
    private string name;
    private double hourlyRate;
    private int hoursPerWeek;

    //#############################################################
    // ==========================Properties =======================
    //#############################################################
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double HourlyRate
    {
        get { return hourlyRate; }
        set {
            if (value < 0 || value > 200)
            {
                Console.WriteLine("Hourly rate can not be less than zero or greater than 100. Default is now 0");
                this.hourlyRate = 0;
            }
            else
            {
                this.hourlyRate = value;
            }
        
        
        }
    }

    public int HoursPerWeek
    {
        get { return this.hoursPerWeek; }
        set
        {
            if (value < 0 || value > 60)
            {
                Console.WriteLine("Invalid hours per week. It can not be less than zero or more than 60. now it is 0");
                this.hoursPerWeek = 0;
            }
            else
            {
                this.hoursPerWeek = value;
            }


        }
    }


    //#############################################################
    // ==========================Constructors======================
    //#############################################################
    public Employee()
    {
        this.name = "No Name";
        this.hourlyRate= 0;
        this.hoursPerWeek = 0;
    }

    public Employee(string name)
    {
        this.name = name;
        this.hourlyRate = 0;
        this.hoursPerWeek = 0;
    }
    //#############################################################
    // ==========================Method======================
    //#############################################################
    public void DisplayInfo()
    {
        Console.WriteLine($"{this.name} {this.hourlyRate} {this.hoursPerWeek}");
    }
}

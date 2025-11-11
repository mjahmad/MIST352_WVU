using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Car
    {
    private string make;
    private string model;
    private int year;

    //#############################################################
    // ==========================Properties =======================
    //#############################################################

    public string Make
    {
        get { return make; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                make = value;
            else
                make = "N/A";
        }
    }

    public string Model
    {
        get { return model; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                model = value;
            else
            {
                Console.WriteLine("Model is not provided. Not it is N.A");
                model = "N.A";
            }
        }
    }

    public int Year
        { get { return year; }
        set {
            if (value <= 0 || value > 2027)
            {
                Console.WriteLine("Invalid year provided. year is now 0");
                year = 0;
            }
            else { 
            year = value;
            }        
        }

    
    }
    //###############################################################

    //#############################################################
    // ==========================Constructors======================
    //#############################################################
    /*
     */
    public Car()
    {
        this.make = "N/A";
        this.model = "N/A";
        this.year = 0;
    }


    public Car(string strMake, string strModel)
    {
        this.make = strMake;
        this.model = strModel;
        this.year = 0;
    }

    //#############################################################
    // ==========================Method======================
    //#############################################################
    public void DisplayInfo()
    {
        Console.WriteLine($"{this.make} {this.model} {this.year}");
    }




}


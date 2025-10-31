using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    private string ID;
    
    string FirstName;
    public string LastName;
    public string phone; 
    private double dblGpa;


    public Student(String anID, string FName, string LName)
    {
        ID = anID;
        FirstName = FName;
        LastName = LName;
    
    }

    public Student(String anID)
    {
        ID = anID;
        FirstName = "Not Provided";
        LastName = "Not Provided";

    }

    public Student(String LName, String FName)
    {
        LastName = LName;
        FirstName = FName;
        ID = "000-00-0000";
    }

    public void SetGPA(double theGPA)
    {
        while (theGPA < 0 || theGPA > 4)
        {
            Console.WriteLine($"The {theGPA} is invalid. It has to be between 0 and 4. Insert again");
            theGPA = Double.Parse( Console.ReadLine() );
        
        }
        dblGpa = theGPA;

    
    }

    public double GetGPA()
    {
        return dblGpa;
    }



    public void SetID(string theID)
    {
        ID = theID; 
    }

    
    public void PrintInfo()
    {
        Console.WriteLine($"{FirstName} {LastName} with ID {ID} has GPA {dblGpa} and phone {phone}");
    }
}
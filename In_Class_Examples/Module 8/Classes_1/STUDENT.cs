using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


    public class STUDENT
    {
    public string FirstName;
    public string LastName;
    private string ID;
    public double firstGrades;

    public void PrintInfo()
    {
        Console.WriteLine($"Hello {FirstName} {LastName}, Youd ID is {ID} and your GPA is {firstGrades}");
    }

    }


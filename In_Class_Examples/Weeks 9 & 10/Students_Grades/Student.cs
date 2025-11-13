using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    private string strName;
    private CourseGrade[] arrGrades;

    public Student(string name, int numCourses)
    {
        strName = name;
        arrGrades = new CourseGrade[numCourses];
    }

    public void AddGrade(int index, CourseGrade grade)
    {
        if (index >= 0 && index < arrGrades.Length)
            arrGrades[index] = grade;
    }

    public double CalcGpa()
    {
        double dblPoints = 0;
        int intCredits = 0;

        for (int i = 0; i < arrGrades.Length; i++)
        {
            if (arrGrades[i] != null)
            {
                dblPoints += arrGrades[i].GetPoints() * arrGrades[i].GetCredits();
                intCredits += arrGrades[i].GetCredits();
            }
        }

        return intCredits == 0 ? 0 : dblPoints / intCredits;
    }

    public void PrintTranscript()
    {
        Console.WriteLine($"\nTranscript for {strName}");
        for (int i = 0; i < arrGrades.Length; i++)
        {
            if (arrGrades[i] != null)
                arrGrades[i].Print();
        }
        Console.WriteLine($"GPA: {CalcGpa():F2}");
    }
}
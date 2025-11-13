using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CourseGrade
{
    private string strCourseCode;
    private double dblScore;
    private int intCredits;

    public CourseGrade(string code, double score, int credits)
    {
        strCourseCode = code;
        dblScore = score;
        intCredits = credits;
    }

    public char GetLetter()
    {
        if (dblScore >= 90) return 'A';
        if (dblScore >= 80) return 'B';
        if (dblScore >= 70) return 'C';
        if (dblScore >= 60) return 'D';
        return 'F';
    }

    public double GetPoints()
    {
        switch (GetLetter())
        {
            case 'A': return 4.0;
            case 'B': return 3.0;
            case 'C': return 2.0;
            case 'D': return 1.0;
            default: return 0.0;
        }
    }

    public int GetCredits() => intCredits;
    public void Print() => Console.WriteLine($"{strCourseCode}: {dblScore} ({GetLetter()}) {intCredits}cr");
}



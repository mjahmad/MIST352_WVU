using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_III
{
    internal class Student
    {
        public int _id;
        public string _name;
        public string _DOB;
        public Grade[] TheGrades = new Grade[5];

        public Student (int id, string name, string dOB, double gr1, double gr2, double gr3, double gr4, double gr5,)
        {
            _id = id;
            _name = name;
            _DOB = dOB;
            TheGrades[0].Score = gr1;
            TheGrades[1].Score = gr2;
            TheGrades[2].Score = gr3;
            TheGrades[3].Score = gr4;
            TheGrades[4].Score = gr5;


        }

        public void ShowAvg()
        {
            double sum = 0, avg = 0;
            for (int i = 0; i <= TheGrades.Length; i++)
            {
                sum += TheGrades[i].Score;

            
            }

            Console.WriteLine( sum / TheGrades.Length);
        }
    }
}

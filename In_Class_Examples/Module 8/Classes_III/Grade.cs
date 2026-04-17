using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_III
{
    internal class Grade
    {
        private double _score;
        private char _letter;


        public Grade(double theScore)
        { 
        _score = theScore;

        }

        public  double Score { get { return _score; } set { _score = value; } }
        public char Letter { get {

                if (_score >= 90)
                    _letter= 'A';
                else if (_score >= 80)
                    _letter = 'B';
                else if (_score >= 70)
                    _letter = 'C';
                else if (_score >= 60)
                    _letter = 'D';
                else
                    _letter = 'F';
                
                return _letter;


            
            
            } }



    
    }
}

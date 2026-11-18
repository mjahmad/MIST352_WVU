using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_1
{
    internal class STUDENT
    {
        //Fields
        private string strFirstName;
        private string strLastName;
        private int intID;
        private double dbl1stGrade;
        private string strSSN;


       
        //Properties
        public string theFirstName
            {
            get => this.strFirstName; 
            set => this.strFirstName = value;

            
            }

        public string theLastName
        {
            get => this.strLastName;
            set
            { 
            if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Last name can not be empty");
            else

             this.strLastName = value;

            }




        }
        //Construtor 
     

        public STUDENT(string ssn)
        {
            string tempSSN = ssn;

            while (!tempSSN.Contains('-')) //as long as rhe ssn has a dash

            {
                Console.WriteLine("SSN is missing a -, provde it again.");


                tempSSN = Console.ReadLine();
            }
            this.strSSN = tempSSN; 



        }
        /// <summary>
        /// 
        /// Construcotr 1: Allow creating students using first and last names
        /// </summary>
        /// <param name="fName">First Name</param>
        /// <param name="lName"> Last name</param>
        /// <exception cref="ArgumentNullException">Raised if either is empty or null</exception>
        public STUDENT(string fName, string lName)
        {

            if (string.IsNullOrWhiteSpace(fName) || string.IsNullOrWhiteSpace(lName))
            {
                throw new ArgumentNullException("names can not ve empty");
                
                   
            }

            
            else

            {
                this.strFirstName = fName;
                this.strLastName = lName;
            }
        
        }


        public STUDENT(string fName, string lName, string ssn, double grade, int id)
        {
            this.strFirstName = fName;
            this.strLastName = lName;
            this.strSSN = ssn;
            this.intID = id;
            this.dbl1stGrade = grade;

        }





    }
}

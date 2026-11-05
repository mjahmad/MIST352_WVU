using System;
using System.Collections.Generic;
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
        /// </This tell us how to interact with the private variable strFirstName>

        public string theFirstName
        {
            //get means, allow users to view with strFirstName by calling theFirstName
           get => strFirstName;
            //set measn allow users to change it by passing. Take is, verify its not empty then assign it to the private variable
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
               strFirstName = value.Trim();
            }
        }



        //Constructor(s): These tell us how to create new objects.
        //Here, we are saying you can create a student by providing their SSN only
        public STUDENT(string theSSN)
        {
            this.strSSN = theSSN;
        }

        //Here, we are saying you can create a student by providing their first and last names
        public STUDENT(string firstName, string lastName)
        {
        
            this.strFirstName = firstName;
            this.strLastName = lastName;
        }

        //And here we ar saying you can create a student object by provindg ALL INFO.
        public STUDENT(string firstName, string lastName, int theID, double theGrade, string theSSN)
        {

            this.strFirstName = firstName;
            this.strLastName = lastName;
            if (theID == 0)
            {
                Console.WriteLine("ID can not be zero. Try again");
            }
            if (firstName.Equals("") ||lastName.Equals("") ||theSSN.Equals(""))
            {

                Console.WriteLine("Data can not be empty");
                    
                    }
            this.intID = theID;
            this.dbl1stGrade = theGrade;
            this.strSSN = theSSN;
        }


        // Properties
      
    }
}

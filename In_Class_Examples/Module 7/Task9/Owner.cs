using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Owner
    {
        //Fields
        private string name;
        private string phone;

        //Constrcutors
        public Owner()
        {
            this.name = "Unknown";
            this.phone = "Not Provided";
        }


        public Owner(string theName, string thePhone)
        {
            if (string.IsNullOrWhiteSpace(theName) || string.IsNullOrWhiteSpace(thePhone))
            {
                //do somethin
                Console.WriteLine("Names / Phones can not be empty");
            }
            else
            {
                this.name = theName;
                this.phone = thePhone;
            }
        }

        //Method
        public void DisplayInfo()
        {
            Console.WriteLine($"{this.name} -- {this.phone}");
        }

        public string BuildContactCard()
        {
            return ($"{this.name} -- {this.phone}");
        }


    }

}

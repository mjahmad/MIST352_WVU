using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Product
    {
        //Fields
        private string name;
        private double unitPrice;


        //Constructor
        public Product(string theName, double thePrice)
        {
            this.name = theName;
            this.unitPrice = thePrice;
        }


        //Methods
        public string GetName()
        {
            return this.name.ToUpper();
        }

        public void SetName(string theName)
        {
            if (string.IsNullOrEmpty(theName))
                this.name = "Unknown Product";
            else
                this.name = theName;
            
        }

    }


}

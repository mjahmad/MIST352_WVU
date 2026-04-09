using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_2
{
    internal class Product
    {
        // ++++++++++ Fields +++++++++++++

        private int _id;
        private string _name;
        private double _price;
        public string _category;

        // ++++++++++ Properties +++++++++++++
        public int Id {
            set
            {
                this._id = value; 
            }
            
            get {
                return this._id; 
            } 
        }

        public string Name
        {
            set
            {
                this._name = value;
            }

            get
            {
                return this._name;
            }
        }

        public double Price 
        {
            set
            {
                this._price = value;
            }

            get
            {
                return this._price;
            }
        }

       

        // ++++++++++ Constructors +++++++++++++
        public Product()
        {
            this._id = 0;
            this._name = "Not Defined";
            this._price = 0;
            this._category = "N/A";
        }

        public Product(int theID, string theName)
        {
            this._id = theID;
            this._name = theName;
            this._price = 0.99;
            this._category = "Not Decided";
        }

        public Product(int theID, string theName, double thePrice, string theCategory)
        {
            this._id = theID;
            this._name = theName;
            this._price = thePrice;
            this._category = theCategory;
        }

        // ++++++++++ Methods +++++++++++++
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {_id}\nName: {_name}\n" +
             $"Price: {_price}\n Category: {_category}");

        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Pet
    {
        private string name;
        private int age;
        private Owner owner;

        //Constructors

        public Pet()
        {
            this.name = "Unknown";
            this.age = 0;
            this.owner = new Owner();
        }


        public void DisplayInfo()
        {

            Console.WriteLine($"{this.name} == {this.age}");
            this.owner.DisplayInfo();
        }

    }
}

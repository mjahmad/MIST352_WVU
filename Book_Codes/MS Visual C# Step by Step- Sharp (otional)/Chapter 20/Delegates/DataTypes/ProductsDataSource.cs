using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class ProductsDataSource
    {
        public List<Product> Products { get; set; }

        public ProductsDataSource()
        {
            // Populate data source with dummy data

            Products = new List<Product>
            {
                new Product { ProductID="P1", Name="Rope", Description="Best Italian hemp, 40ft", AgeRestricted=false, Price=28.00M },
                new Product { ProductID="P2", Name="Wood", Description="Pine, 4\' x 2\' x 18\'", AgeRestricted=false, Price=12.20M },
                new Product { ProductID="P3", Name="Screwdriver", Description="Crossheaded", AgeRestricted=false, Price=4.99M },
                new Product { ProductID="P4", Name="Power Drill", Description="1800 RPM hammer drill", AgeRestricted=true, Price=75.50M },
                new Product { ProductID="P5", Name="Hammer", Description="24oz heavy-duty claw hammer", AgeRestricted=false, Price=18.35M },
                new Product { ProductID="P6", Name="Power Saw", Description="Rotary action, high powered", AgeRestricted=true, Price=88.00M },
                new Product { ProductID="P7", Name="Nails", Description="2\" masonry nails", AgeRestricted=false, Price=5.00M },
                new Product { ProductID="P8", Name="Saw", Description="Fine-toothed fretsaw", AgeRestricted=false, Price=3.20M },
            };
        }
    }
}

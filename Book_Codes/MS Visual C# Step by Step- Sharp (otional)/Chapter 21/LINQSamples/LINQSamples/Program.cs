using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // The data
            var customers = new[] 
            {
                new { CustomerID = 1, FirstName = "Kim", LastName = "Abercrombie", CompanyName = "Alpine Ski House" },
                new { CustomerID = 2, FirstName = "Jeff", LastName = "Hay", CompanyName = "Coho Winery" },
                new { CustomerID = 3, FirstName = "Charlie", LastName = "Herb", CompanyName = "Alpine Ski House" },
                new { CustomerID = 4, FirstName = "Chris", LastName = "Preston", CompanyName = "Trey Research" },
                new { CustomerID = 5, FirstName = "Dave", LastName = "Barnett", CompanyName = "Wingtip Toys" },
                new { CustomerID = 6, FirstName = "Ann", LastName = "Beebe", CompanyName = "Coho Winery" },
                new { CustomerID = 7, FirstName = "John", LastName = "Kane", CompanyName = "Wingtip Toys" },
                new { CustomerID = 8, FirstName = "David", LastName = "Simpson", CompanyName = "Trey Research" },
                new { CustomerID = 9, FirstName = "Greg", LastName = "Chapman", CompanyName = "Wingtip Toys" },
                new { CustomerID = 10, FirstName = "Tim", LastName = "Litton", CompanyName = "Wide World Importers" }
            };

            var addresses = new[] 
            {
                new { CompanyName = "Alpine Ski House", City = "Berne", Country = "Switzerland" },
                new { CompanyName = "Coho Winery", City = "San Francisco", Country = "United States" },
                new { CompanyName = "Trey Research", City = "New York", Country = "United States" },
                new { CompanyName = "Wingtip Toys", City = "London", Country = "United Kingdom" },
                new { CompanyName = "Wide World Importers", City = "Tetbury", Country = "United Kingdom" }
            };

            // Selecting data
            Console.WriteLine("Selecting data");
            IEnumerable<string> customerFirstNames = 
                customers.Select(cust => cust.FirstName);
            foreach (string name in customerFirstNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            // Displaying the full name of each customer
            Console.WriteLine("Displaying the full name of each customer using concatenation");
            IEnumerable<string> customerNames = 
                customers.Select(cust => $"{cust.FirstName} {cust.LastName}");
            foreach (string name in customerNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            Console.WriteLine("Displaying the full name of each customer using class to wrap names");
            IEnumerable<FullName> customerFullNames = 
                customers.Select(cust => new FullName
                {
                    FirstName = cust.FirstName,
                    LastName = cust.LastName
                });
            foreach (FullName name in customerFullNames)
            {
                Console.WriteLine($"{name.FirstName} {name.LastName}");
            }
            Console.WriteLine();

            Console.WriteLine("Displaying the full name of each customer using an anonymous type");
            var customerFullNames2 = customers.Select(cust => new
            {
                FirstName = cust.FirstName,
                LastName = cust.LastName
            });
            foreach (var name in customerFullNames2)
            {
                Console.WriteLine($"{name.FirstName} {name.LastName}");
            }
            Console.WriteLine();

            // Filtering data
            IEnumerable<string> usCompanies = addresses
                .Where(addr => String.Equals(addr.Country, "United States"))
                .Select(usComp => usComp.CompanyName);

            Console.WriteLine("Displaying the names of American companies");
            foreach (string name in usCompanies)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            // Ordering data
            IEnumerable<string> companyNames = addresses
                .OrderBy(addr => addr.CompanyName)
                .Select(comp => comp.CompanyName);

            Console.WriteLine("Displaying the names of companies in alphabetical order");
            foreach (string name in companyNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            // Grouping data
            var companiesGroupedByCountry = addresses
                .GroupBy(addrs => addrs.Country);

            Console.WriteLine("Grouping companies by country");
            foreach (var companiesPerCountry in companiesGroupedByCountry)
            {
                Console.WriteLine(
                    $"Country: {companiesPerCountry.Key}\t{companiesPerCountry.Count()} companies");

                foreach (var companies in companiesPerCountry)
                {
                    Console.WriteLine($"\t{companies.CompanyName}");
                }
            }
            Console.WriteLine();

            // How many companies in total?
            int numberOfCompanies = addresses
                .Select(addr => addr.CompanyName).Count();
            Console.WriteLine($"Number of companies: {numberOfCompanies}");

            // How many countries?
            int numberOfCountries = addresses
                .Select(addr => addr.Country).Count();
            Console.WriteLine($"Number of countries: {numberOfCountries}");

            // How many DISTINCT countries?
            int numberOfDistinctCountries = addresses
                .Select(addr => addr.Country).Distinct().Count();
            Console.WriteLine($"Number of distinct countries: {numberOfDistinctCountries}");
            Console.WriteLine();

            // Joining data
            var companiesAndCustomers = customers
                .Select(c => new { c.FirstName, c.LastName, c.CompanyName })
                .Join(addresses, custs => custs.CompanyName, addrs => addrs.CompanyName, 
                (custs, addrs) => new { custs.FirstName, custs.LastName, addrs.Country });

            Console.WriteLine("Joining companies and customers");
            foreach (var row in companiesAndCustomers)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine();

            // Using query operators
            var customerFirstNames2 = from cust in customers
                                      select cust.FirstName;

            Console.WriteLine("Displaying customer first names using query operators");
            foreach(var name in customerFirstNames2)
            {
                Console.WriteLine($"{name}");
            }
            Console.WriteLine();

            var customerNames2 = from cust in customers
                                 select new { cust.FirstName, cust.LastName };

            Console.WriteLine("Displaying customer full names using query operators");
            foreach (var name in customerNames2)
            {
                Console.WriteLine($"{name}");
            }
            Console.WriteLine();

            var usCompanies2 = from a in addresses
                               where String.Equals(a.Country, "United States")
                               select a.CompanyName;

            Console.WriteLine("Filtering data using query operators");
            foreach (var name in usCompanies2)
            {
                Console.WriteLine($"{name}");
            }
            Console.WriteLine();

            var companyNames2 = from a in addresses
                                orderby a.CompanyName
                                select a.CompanyName;

            Console.WriteLine("Ordering data using query operators");
            foreach (var name in companyNames2)
            {
                Console.WriteLine($"{name}");
            }
            Console.WriteLine();

            var companiesGroupedByCountry2 = from a in addresses
                                             group a by a.Country;

            Console.WriteLine("Grouping data using query operators");
            foreach (var companiesPerCountry in companiesGroupedByCountry2)
            {
                Console.WriteLine($"Country: {companiesPerCountry.Key}\t{companiesPerCountry.Count()} companies");
                foreach (var companies in companiesPerCountry)
                {
                    Console.WriteLine($"\t{companies.CompanyName}");
                }
            }
            Console.WriteLine();

            numberOfCompanies = (from a in addresses
                                 select a.CompanyName).Count();
            
            numberOfDistinctCountries = (from a in addresses
                                         select a.Country).Distinct().Count();

            Console.WriteLine("Counting rows using query operators");
            Console.WriteLine($"Number of companies: {numberOfCompanies}{Environment.NewLine}Number of distinct countries: {numberOfDistinctCountries}");
            Console.WriteLine();

            var countriesAndCustomers = from a in addresses
                                        join c in customers 
                                        on a.CompanyName equals c.CompanyName
                                        select new { c.FirstName, c.LastName, a.Country };

            Console.WriteLine("Joining data using query operators");
            foreach (var row in countriesAndCustomers)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine();

        }
    }

    class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

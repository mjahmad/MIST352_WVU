using System;
using System.Linq;
using BinaryTree;

namespace QueryBinaryTree
{
    class Program
    {
        static void doWork()
        {
            Tree<Employee> empTree = new Tree<Employee>(
                new Employee
                {
                    Id = 1,
                    FirstName = "Kim",
                    LastName = "Abercrombie",
                    Department = "IT"
                });

            empTree.Insert(
                new Employee
                {
                    Id = 2,
                    FirstName = "Jeff",
                    LastName = "Hay",
                    Department = "Marketing"
                });

            empTree.Insert(
                new Employee
                {
                    Id = 4,
                    FirstName = "Charlie",
                    LastName = "Herb",
                    Department = "IT"
                });

            empTree.Insert(
                new Employee
                {
                    Id = 6,
                    FirstName = "Chris",
                    LastName = "Preston",
                    Department = "Sales"
                });

            empTree.Insert(
                new Employee
                {
                    Id = 3,
                    FirstName = "Dave",
                    LastName = "Barnett",
                    Department = "Sales"
                });

            empTree.Insert(
                new Employee
                {
                    Id = 5,
                    FirstName = "Tim",
                    LastName = "Litton",
                    Department = "Marketing"
                });

            Console.WriteLine("All employees");
            var allEmployees = from e in empTree.ToList<Employee>()
                               select e;

            foreach (var emp in allEmployees)
            {
                Console.WriteLine(emp);
            }

            empTree.Insert(new Employee
            {
                Id = 7,
                FirstName = "David",
                LastName = "Simpson",
                Department = "IT"
            });

            Console.WriteLine();
            Console.WriteLine("Employee added");

            Console.WriteLine("All employees");
            foreach (var emp in allEmployees)
            {
                Console.WriteLine(emp);
            }

            /*
            Console.WriteLine("List of departments");
            //var depts = empTree.Select(d => d.Department).Distinct();
            var depts = (from d in empTree
                         select d.Department).Distinct();

            foreach (var dept in depts)
            {
                Console.WriteLine($"Department: {dept}");
            }

            Console.WriteLine();
            Console.WriteLine("Employees in the IT department");
            //var ITEmployees =
            //    empTree.Where(e => String.Equals(e.Department, "IT"))
            //    .Select(emp => emp);

            var ITEmployees = from e in empTree
                              where String.Equals(e.Department, "IT")
                              select e;

            foreach (var emp in ITEmployees)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("");
            Console.WriteLine("All employees grouped by department");
            //var employeesByDept = empTree.GroupBy(e => e.Department);
            var employeesByDept = from e in empTree
                                  group e by e.Department;

            foreach (var dept in employeesByDept)
            {
                Console.WriteLine($"Department: {dept.Key}");
                foreach (var emp in dept)
                {
                    Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
                }
            }*/
        }

        static void Main()
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryTree;

namespace QueryBinaryTree
{
    class Program
    {
        static void DoWork()
        {
            Tree<Employee> empTree = new Tree<Employee>(new Employee
                {Id = 1, FirstName = "Janet", LastName = "Gates", Department = "IT"});
            empTree.Insert(new Employee {Id = 2, FirstName = "Orlando", LastName = "Gee", Department = "Marketing"});
            empTree.Insert(new Employee {Id = 4, FirstName = "Keith", LastName = "Harris", Department = "IT"});
            empTree.Insert(new Employee {Id = 6, FirstName = "Lucy", LastName = "Harrington", Department = "Sales"});
            empTree.Insert(new Employee {Id = 3, FirstName = "Eric", LastName = "Lang", Department = "Sales"});
            empTree.Insert(new Employee {Id = 5, FirstName = "David", LastName = "Liu", Department = "Marketing"});


            //////////////////////////////
            ///// USING LINQ METHODS
            
            Console.WriteLine("List of departments");
            var depts = empTree.Select(d => d.Department).Distinct();

            foreach (var dept in depts)
            {
                Console.WriteLine("Department {0}", dept);
            }

            Console.WriteLine("\nEmployees in the IT department");
            var ITEmployees = empTree.Where(dept => String.Equals(dept.Department, "IT"))
                                     .Select(empl => empl);
            foreach (var employee in ITEmployees)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine("\nAll employees grouped by department");
            var employeesByDept = empTree.GroupBy(e => e.Department);
            foreach (var dept in employeesByDept)
            {
                Console.WriteLine("Department: {0}", dept.Key);
                foreach (var emp in dept)
                {
                    Console.WriteLine("\t{0} {1}", emp.FirstName, emp.LastName);
                }
            }

            ////////////////////////////////
            ///// USING QUERY OPERATORS
            Console.WriteLine("\n \n ============= USING QUERY OPERATORS ==============");
            var depts2 = (from d in empTree select d.Department).Distinct();
            foreach (var dept in depts2)
            {
                Console.WriteLine("Department {0}", dept);
            }

            var ITEmployees2 = from e in empTree where String.Equals(e.Department, "IT") select e;
            foreach (var employee in ITEmployees2)
            {
                Console.WriteLine(employee);
            }

            var employeesByDept2 = from e in empTree group e by e.Department;
            foreach (var dept in employeesByDept2)
            {
                Console.WriteLine("Department: {0}", dept.Key);
                foreach (var emp in dept)
                {
                    Console.WriteLine("\t{0} {1}", emp.FirstName, emp.LastName);
                }
            }

            //////////////////////////////////////////////////////////////////
            ////// Normal LINQ evaluation versus Deferred Evaluation
            Console.WriteLine("\n\n===============================================================================");
            Console.WriteLine("============= Normal LINQ evaluation versus Deferred Evaluation ===============");

            Console.WriteLine("All employees");
            //var allEmployeees = from e in empTree select e; // statement where the list of allEmployees changes everytime it iterates through it.
            var allEmployeees = from e in empTree.ToList<Employee>() select e;
            foreach (var emp  in allEmployeees)
            {
                Console.WriteLine(emp);
            }

            empTree.Insert(new Employee {Id = 7, FirstName = "Donald", LastName = "Blanton", Department = "IT"});
            Console.WriteLine("\nEmployee added");

            Console.WriteLine("All employees");
            foreach (var employee in allEmployeees)
            {
                Console.WriteLine(employee);
            }

        }

        static void Main()
        {
            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}

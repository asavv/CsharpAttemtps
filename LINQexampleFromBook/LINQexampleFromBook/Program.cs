using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQexampleFromBook
{
    class Program
    {
        static void Main(string[] args)
        {
             var customers = new[]
                {
                    new {CustomerID = 1, FirstName = "Orlando", LastName = "Gee", CompanyName = "A Bike Store"},
                    new {CustomerID = 2, FirstName = "Janet", LastName = "Gates", CompanyName = "Fitness Hotel"},
                    new {CustomerID = 3, FirstName = "Keith", LastName = "Harris", CompanyName = "Bike World"},
                    new {CustomerID = 4, FirstName = "Donna", LastName = "Carreras", CompanyName = "A Bike Store"},
                    new {CustomerID = 5, FirstName = "Lucy", LastName = "Harrington", CompanyName = "Grand Industries"}
                };
//new{CustomerID = 1, FirstName = "", LastName = "", CompanyName = ""},

            var addresses = new[]
                {
                    new {CompanyName = "A Bike Store", Country = "USA"},
                    new {CompanyName = "Bike World", Country = "Canada"},
                    new {CompanyName = "Fitness Hotel", Country = "Canada"},
                    new {CompanyName = "Grand Industries", Country = "UK"},
                };

            //// Select data with LINQ
            IEnumerable<string> customerFirstNames = customers.Select(cust => cust.FirstName);

            foreach (string name in customerFirstNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\n \t Selecting with multiple itmes now: \n ");

            IEnumerable<string> customerFullName = customers.Select(cust => cust.FirstName + " " + cust.LastName);

            foreach (string fullName in customerFullName)
            {
                Console.WriteLine(fullName);
            }

            // OR another way of doing it, by wrapping the first and last names in a class
            IEnumerable<Names> customerName =
                customers.Select(cust => new Names {FirstName = cust.FirstName, LastName = cust.LastName});
            Console.WriteLine("");
            foreach (Names fullName in customerName)
            {
                Console.WriteLine(fullName.FirstName + " " + fullName.LastName);
            }

            //OR USE AN anonymous type to define a new type specifically for a single operation
            var customerName2 = customers.Select(cust => new {FirstName = cust.FirstName, LastName = cust.LastName});
            Console.WriteLine("");
            foreach (var fullName in customerName2)
            {
                Console.WriteLine(fullName.FirstName + " " + fullName.LastName);
            }

            ////  Filtering Data
            IEnumerable<string> usCompanies =
                addresses.Where(addr => String.Equals(addr.Country, "Canada")).Select(usComp => usComp.CompanyName);
            Console.WriteLine("\n \t Filtering data by company country:");
            foreach (string usCompany in usCompanies)
            {
                Console.WriteLine(usCompany);
            }

            //// Ordering Data
            IEnumerable<string> companyNames =
                addresses.OrderBy(addr => addr.CompanyName).Select(comp => comp.CompanyName);
            Console.WriteLine("\n \t Ordering data by company name");
            foreach (string name in companyNames)
            {
                Console.WriteLine(name);
            }

            IEnumerable<string> companyNames2 =
                addresses.OrderByDescending(addr => addr.CompanyName).ThenBy(cou => cou.Country).Select(comp => comp.CompanyName);
            Console.WriteLine("\n \t Ordering by descending order, by company name and country");
            foreach (string name in companyNames2)
            {
                Console.WriteLine(name);
            }

            //// Group data
            var companiesGroupedByCountry = addresses.GroupBy(addrs => addrs.Country);
            Console.WriteLine("\n \t Group companies by country");
            foreach (var companiesPerCountry in companiesGroupedByCountry)
            {
                Console.WriteLine("Country: {0} \t {1} companies", companiesPerCountry.Key, companiesPerCountry.Count());

                foreach (var companies in companiesPerCountry)
                {
                    Console.WriteLine("\t {0}", companies.CompanyName);
                }
            }

            ///// Using summary methods
            int numberOfCompanies = addresses.Select(addr => addr.CompanyName).Count();
            Console.WriteLine("\nNumber of companies: {0}", numberOfCompanies);

            int numberOfCountries = addresses.Select(cou => cou.Country).Count();
            Console.WriteLine("Wrong number of countries present in addresses array: {0}", numberOfCountries);

            int numberOfCountries2 = addresses.Select(cou => cou.Country).Distinct().Count();
            Console.WriteLine("Correct number of countries present in addresses array: {0}", numberOfCountries2);
        }

        class Names
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}

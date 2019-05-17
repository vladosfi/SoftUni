using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.CompanyRoster
{
    class Employee
    {
        string name;
        decimal salary;
        string department;

        public Employee(string name, decimal salary, string department)
        {
            this.name = name;
            this.salary = salary;
            this.department = department;
        }

        public string Name => this.name;
        public decimal Salary => this.salary;
        public string Department => this.department;
    }
    class CompanyRoster
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<Employee> employees = new List<Employee>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                decimal salary = decimal.Parse(tokens[1]);
                string department = tokens[2];

                Employee currentEmployee = new Employee(name, salary, department);

                employees.Add(currentEmployee);
            }


            var groupedEmploees = employees
                .GroupBy(d => d.Department)
                .OrderByDescending(p => p.Average(s => s.Salary))
                .FirstOrDefault()
                .ToList();


            Console.WriteLine($"Highest Average Salary: {groupedEmploees.FirstOrDefault().Department.ToString()}");

            foreach (var department in groupedEmploees.OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{department.Name} {department.Salary:f02}");
            }
        }
    }
}

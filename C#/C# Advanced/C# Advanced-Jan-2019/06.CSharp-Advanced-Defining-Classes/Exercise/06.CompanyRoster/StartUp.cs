using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _06.CompanyRoster
{
    class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            List<Employee> employees = new List<Employee>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                Employee employee = new Employee(tokens[0], decimal.Parse(tokens[1]), tokens[2], tokens[3]);

                if (tokens.Length == 5)
                {
                    if (tokens[4].Contains("@"))
                    {
                        employee.Email = tokens[4]; 
                    }
                    else
                    {
                        employee.Age = int.Parse(tokens[4]);
                    }
                }
                else if(tokens.Length == 6)
                {
                    employee.Email = tokens[4];
                    employee.Age = int.Parse(tokens[5]);
                }

                employees.Add(employee);
            }

            var highestAverageSalaryDepartment = employees
                .GroupBy(e => e.Department)
                .OrderByDescending(g => g.Select(e => e.Salary).Average())
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment.Key}");
            Console.WriteLine(string.Join(Environment.NewLine, highestAverageSalaryDepartment
                .OrderByDescending(e => e.Salary)
                .Select(e => $"{e.Name} {e.Salary:F2} {e.Email} {e.Age}")));

        }
        
    }
}

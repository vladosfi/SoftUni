using System;
using System.Collections.Generic;
using System.Text;

namespace _06.CompanyRoster
{
    class Employee
    {
        //private string name;
        //private decimal salary;
        //private string position;
        //private string department;
        //private string email;
        //private int age;
        
        public Employee(string name, decimal salary, string position, string department)
            : this(name, salary, position, department, "n/a", -1)
        {
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.Age = age;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}

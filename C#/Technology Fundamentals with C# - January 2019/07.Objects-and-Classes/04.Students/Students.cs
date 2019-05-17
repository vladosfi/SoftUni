using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _04.Students
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public Student(string firstName,string lastName,double grade)
        {
            this.FirstName = firstName;

            this.LastName = lastName;

            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f02}";
        }
    }
    class Students
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                Student newStudent = new Student(
                    firstName, 
                    lastName, 
                    grade);

                students.Add(newStudent);
            }

            List<Student> orderedStudents = students.OrderByDescending(s=>s.Grade).ToList();

            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student.ToString());
            }
            
        }
    }
}

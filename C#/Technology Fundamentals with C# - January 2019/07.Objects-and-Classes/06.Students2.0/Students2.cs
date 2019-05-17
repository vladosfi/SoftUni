using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Hometown { get; set; }
    }

    class Students
    {
        static void Main()
        {
            List<Student> listOfStudents = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string hometown = tokens[3];
                Student student = new Student();

                if (IsStudentExist(listOfStudents, firstName, lastName))
                {
                    student = GetStudent(listOfStudents, firstName, lastName);
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = hometown;
                }
                else
	            {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = hometown;
                    listOfStudents.Add(student);
                }
            }

            string town = Console.ReadLine();

            foreach (Student student in listOfStudents.Where(s => s.Hometown == town))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        private static Student GetStudent(List<Student> listOfStudents, string firstName, string lastName)
        {
            Student existingStudent = null;
            foreach (var student in listOfStudents)
            {
                if (firstName == student.FirstName && lastName == student.LastName)
                {
                    existingStudent = student;
                    break;
                }
            }

            return existingStudent;
        }

        private static bool IsStudentExist(List<Student> listOfStudents, string firstName, string lastName)
        {
            foreach (var s in listOfStudents)
            {
                if (firstName == s.FirstName && lastName == s.LastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

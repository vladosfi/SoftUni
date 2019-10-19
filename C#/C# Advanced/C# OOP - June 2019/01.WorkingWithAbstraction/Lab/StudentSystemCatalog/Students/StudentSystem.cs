namespace StudentSystemCatalog.Students
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> students;

        public StudentSystem()
        {
            this.students = new Dictionary<string, Student>();
        }

        public void Add(string[] commandParts)
        {
            var name = commandParts[0];
            var age = int.Parse(commandParts[1]);
            var grade = double.Parse(commandParts[2]);

            if (!this.students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                students[name] = student;
            }
        }

        public Student Get(string name)
        {
            if (!students.ContainsKey(name))
            {
                return null;
            }

            var student = students[name];
            return student;
        }
    }
}
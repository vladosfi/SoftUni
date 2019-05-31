using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public DateTime Birthdate { get; private set; }


        public Person(string name, int age, DateTime birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthDate;
        }
    }
}

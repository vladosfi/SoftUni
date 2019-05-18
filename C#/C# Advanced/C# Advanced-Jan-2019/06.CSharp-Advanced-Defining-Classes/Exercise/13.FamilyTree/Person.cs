using System;
using System.Collections.Generic;
using System.Text;

namespace _13.FamilyTree
{
    public class Person
    {

        public string Name { get; set; }

        public string BirthDate { get; set; }

        public Person( string name , string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public Person(string data)
        {
            if (int.TryParse(data[0].ToString(), out _))
            {
                this.BirthDate = data;
            }
            else
            {
                this.Name = data;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.BirthDate}";
        }
    }
}

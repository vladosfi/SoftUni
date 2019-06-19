using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            int result = this.name.CompareTo(other.name);

            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.name == person.name && this.age == person.age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() + this.age.GetHashCode(); ;
        }

    }
}

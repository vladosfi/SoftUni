using System;
using System.Collections.Generic;
using System.Text;

namespace _06.StrategyPattern
{
    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}

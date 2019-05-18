using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class PersonNameLengthComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            int nameLenghtResult = first.Name.Length.CompareTo(second.Name.Length);

            if (nameLenghtResult == 0)
            {
                return first.Name.ToLower()[0].CompareTo(second.Name.ToLower()[0]);
            }
            return nameLenghtResult;
        }
    }
}

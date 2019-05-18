using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    public class Box
    {
        public static int Compare<T>(List<T> list, T element)
            where T : IComparable<T>
        {
            int counter = 0;
            foreach (var generic in list)
            {
                if (generic.CompareTo(element) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

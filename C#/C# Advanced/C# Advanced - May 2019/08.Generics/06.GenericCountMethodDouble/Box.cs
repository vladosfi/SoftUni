using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box
    {
        public int Compare<T>(List<T> boxCollection, T element)
            where T : IComparable<T>
        {
            int count = 0;

            foreach (var item in boxCollection)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

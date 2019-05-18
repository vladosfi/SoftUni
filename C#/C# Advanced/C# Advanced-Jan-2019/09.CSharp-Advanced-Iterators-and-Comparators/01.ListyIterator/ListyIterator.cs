using System;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> collection;
        private int currentIndex;

        public ListyIterator(params T[] collection)
        {
            this.collection = new List<T>(collection);
            currentIndex = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                currentIndex++;
                return true;
            }
            return false;
        }

        public string Print()
        {
            if (collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            else
            {
                T result = collection[currentIndex];
                return result.ToString();
            }
        }

        public bool HasNext()
        {
            if (currentIndex + 1 < collection.Count)
            {
                return true;
            }

            return false;
        }
    }
}

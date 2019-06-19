using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class ListyIterator<T>
    {
        private List<T> collection;
        private int currentIndex;

        public ListyIterator()
        {
            currentIndex = 0;
        }

        public void Create(params T[] elements)
        {
            collection = new List<T>(elements);
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

        public bool HasNext()
        {
            if (currentIndex + 1 < collection.Count)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (currentIndex >= 0 && currentIndex < collection.Count)
            {
                Console.WriteLine(collection[currentIndex]);
                return;
            }

            throw new InvalidOperationException("Invalid Operation!");
        }
    }
}

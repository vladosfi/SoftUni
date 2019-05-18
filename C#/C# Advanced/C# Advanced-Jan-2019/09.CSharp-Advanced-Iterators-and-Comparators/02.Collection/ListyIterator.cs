using System;
using System.Collections;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int currentIndex;

        public ListyIterator(List<T> collection)
        {
            this.collection = collection;
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

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}

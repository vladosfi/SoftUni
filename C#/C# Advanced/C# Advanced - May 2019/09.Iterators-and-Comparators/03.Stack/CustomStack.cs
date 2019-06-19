using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private readonly List<T> stack;
        private int currentindex;

        public CustomStack()
        {
            stack = new List<T>();
            currentindex = -1;
        }

        public void Push(T[] array)
        {
            foreach (var element in array)
            {
                this.stack.Add(element);
                this.currentindex++;
            }
        }

        public T Pop()
        {
            if (this.currentindex >= 0)
            {
                T lastElemen = this.stack[currentindex];
                this.stack.RemoveAt(this.currentindex);
                this.currentindex--;
                return lastElemen;
            }

            throw new IndexOutOfRangeException("No elements");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = currentindex; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> customStack;

        public CustomStack()
        {
            this.customStack = new List<T>();
        }

        public void Push(List<T> values)
        {
            this.customStack.AddRange(values);
        }

        public T Pop()
        {
            if (customStack.Count > 0)
            {
                T value = this.customStack[customStack.Count - 1];
                this.customStack.RemoveAt(customStack.Count - 1);
                return value;  
            }
            else
            {
                throw new ArgumentException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.customStack.Count - 1; i >= 0 ; i--)
            {
                yield return customStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

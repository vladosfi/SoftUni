using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofInteger
{
    public class Box<T>
    {
        private T storedValue;

        public Box(T storedValue)
        {
            this.storedValue = storedValue;
        }

        public override string ToString()
        {
            return $"{storedValue.GetType().FullName}: {this.storedValue}";
        }
    }
}

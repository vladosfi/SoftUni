using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofString
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
            return $"{typeof(T)}: {this.storedValue}";
        }
    }
}

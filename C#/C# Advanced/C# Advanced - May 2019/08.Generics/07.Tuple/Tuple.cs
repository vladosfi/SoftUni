using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTuple
{
    public class Tuple<T, V>
    {
        public T item1 { get; set; }
        public V item2 { get; set; }
    }
}

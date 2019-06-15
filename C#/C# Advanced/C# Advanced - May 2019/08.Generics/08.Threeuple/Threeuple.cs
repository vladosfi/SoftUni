using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuples
{
    public class Threeuple<T,V,U>
    {
        public T item1 { get; set; }
        public V item2 { get; set; }
        public U item3 { get; set; }
    }
}

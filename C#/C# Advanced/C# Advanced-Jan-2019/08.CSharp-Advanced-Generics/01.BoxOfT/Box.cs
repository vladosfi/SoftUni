using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> Boxes { get; set; }

        public Box()
        {
            this.Boxes = new List<T>();
        }

        public int Count => this.Boxes.Count;

        public void Add(T element)
        {
            this.Boxes.Add(element);
        }

        public T Remove()
        {
            T lastElement = this.Boxes[this.Boxes.Count - 1];
            this.Boxes.RemoveAt(this.Boxes.Count - 1);
            return lastElement;
        }


    }
}

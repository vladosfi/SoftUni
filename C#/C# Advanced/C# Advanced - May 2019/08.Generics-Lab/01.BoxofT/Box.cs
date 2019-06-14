using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> boxes;

        public int Count { get => boxes.Count;}

        public Box()
        {
            boxes = new List<T>();
        }

        public void Add(T element)
        {
            boxes.Add(element);
        }

        public T Remove()
        {
            if (boxes.Count > 0)
            {
                T elementToRemove = boxes[boxes.Count - 1];
                boxes.RemoveAt(boxes.Count - 1);
                return elementToRemove;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            
        }
    }
}

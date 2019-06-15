using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Generic<T>
    {
        List<T> listOfValues;

        public Generic()
        {
            listOfValues = new List<T>();
        }

        public void Add(T element)
        {
            listOfValues.Add(element);
        }

        public void Swap(int indexOne, int indexTwo)
        {
            if (indexOne >= 0 &&
                indexOne < listOfValues.Count &&
                indexTwo >= 0 &&
                indexTwo < listOfValues.Count &&
                indexOne != indexTwo)
            {
                T temp = listOfValues[indexOne];
                listOfValues[indexOne] = listOfValues[indexTwo];
                listOfValues[indexTwo] = temp;
            }
        }


        public void Print()
        {
            foreach (var item in listOfValues)
            {
                Console.WriteLine($"{typeof(T)}: {item}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;

namespace _06.GenericCountMethodDouble
{
    class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int n = int.Parse(Console.ReadLine());

            List<double> elements = new List<double>();

            for (int i = 0; i < n; i++)
            {
                elements.Add(double.Parse(Console.ReadLine()));
            }

            var elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(Box.Compare(elements, elementToCompare));
        }
    }


    public class Box
    {
        public static int Compare<T>(List<T> list, T element)
            where T : IComparable<T>
        {
            int counter = 0;
            foreach (var generic in list)
            {
                if (generic.CompareTo(element) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

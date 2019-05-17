using System;
using System.Collections.Generic;

namespace _01.SortNumbers
{
    class SortNumbers
    {
        static void Main()
        {
            List<int> sorted = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                sorted.Add(int.Parse(Console.ReadLine()));
            }

            sorted.Sort();
            sorted.Reverse();

            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }

        }
    }
}

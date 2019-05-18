using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> values = new List<int>();

            for (int i = 0; i < n; i++)
            {
                values.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            GenericSwap.Swap(values, indexes[0], indexes[1]);

            foreach (var item in values)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
    }
}

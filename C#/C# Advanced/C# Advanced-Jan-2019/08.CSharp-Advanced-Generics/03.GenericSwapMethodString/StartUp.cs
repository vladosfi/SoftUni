using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> values = new List<string>();

            for (int i = 0; i < n; i++)
            {
                values.Add(Console.ReadLine());
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

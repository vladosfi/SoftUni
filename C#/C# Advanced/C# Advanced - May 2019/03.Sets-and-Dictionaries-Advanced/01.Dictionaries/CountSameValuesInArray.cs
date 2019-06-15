using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.Dictionaries
{
    class CountSameValuesInArray
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var dict = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 0);
                }

                dict[number]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}

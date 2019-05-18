using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.UniqueUsernames
{
    class CountSameValues
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var valueCounter = new Dictionary<double, int>();

            var array = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (var number in array)
            {
                if (!valueCounter.ContainsKey(number))
                {
                    valueCounter[number] = 0;
                }

                valueCounter[number]++;
            }

            foreach (var kvp in valueCounter)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}

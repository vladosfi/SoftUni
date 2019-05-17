using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.SumAdjacentEqualNumbers
{
    class SumAdjacentEqualNumbers
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            while (true)
            {
                bool equalNumbers = false;

                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] == numbers[i + 1])
                    {
                        numbers[i] += numbers[i + 1];
                        numbers.RemoveAt(i + 1);
                        equalNumbers = true;
                    }
                }

                if (!equalNumbers)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

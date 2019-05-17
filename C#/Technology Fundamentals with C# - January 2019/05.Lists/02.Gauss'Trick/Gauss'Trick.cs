using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Gauss_Trick
{
    class GaussTrick
    {
        static void Main()
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            if (numbers.Count > 0)
            {
                for (int i = 0; i < numbers.Count-1; i++)
                {
                    numbers[i] += numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

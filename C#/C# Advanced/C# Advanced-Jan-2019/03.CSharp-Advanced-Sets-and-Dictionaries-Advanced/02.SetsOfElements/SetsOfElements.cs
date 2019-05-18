using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class SetsOfElements
    {
        static void Main()
        {
            var setCount = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> numbersN = new HashSet<int>();
            HashSet<int> numbersM = new HashSet<int>();

            int n = setCount[0];
            int m = setCount[1];

            for (int i = 0; i < n; i++)
            {
                numbersN.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                numbersM.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> numbers = new HashSet<int>();

            foreach (var number in numbersN)
            {
                if (numbersM.Contains(number))
                {
                    numbers.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

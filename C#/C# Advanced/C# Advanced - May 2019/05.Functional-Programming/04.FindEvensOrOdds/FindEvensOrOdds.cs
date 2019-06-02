using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            int[] bounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            List<int> numbers = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", numbers.Where(n => EvenOrOdd(n, command))));

            Func<int, string, bool> Func = EvenOrOdd;
        }

        public static bool EvenOrOdd(int n, string criteria)
        {
            if (criteria == "odd")
            {
                return n % 2 != 0 ? true : false;
            }
            else
            {
                return n % 2 == 0 ? true : false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> range = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                range.Add(i);
            }

            Func<List<int>, int, bool> divisibleFilter = Devisible;

            Console.WriteLine(string.Join(" ", range.Where(x => divisibleFilter(list, x)).ToList()));
        }

        static bool Devisible(List<int> nums, int n)
        {
            foreach (var e in nums)
            {
                if (n % e != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

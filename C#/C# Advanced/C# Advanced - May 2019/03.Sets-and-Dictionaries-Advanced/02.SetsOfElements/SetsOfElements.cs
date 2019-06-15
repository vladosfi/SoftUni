using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class SetsOfElements
    {
        static void Main()
        {
            HashSet<string> first = new HashSet<string>();
            HashSet<string> second = new HashSet<string>();

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nums[0];
            int m = nums[1];

            for (int i = 0; i < n + m; i++)
            {
                if (i < n)
                {
                    first.Add(Console.ReadLine());
                }
                else
                {
                    second.Add(Console.ReadLine());
                }
            }

            foreach (var firstNumber in first.Where(x => second.Contains(x)))
            {
                Console.Write(firstNumber + " ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            Func<int,int,bool> RemoveDivisible = (n,m) => n % m != 0;

            Func<List<int>, List<int>> ReverseList = nums =>
            {
                List<int> revercedList = new List<int>();

                for (int i = nums.Count - 1; i >= 0; i--)
                {
                    revercedList.Add(nums[i]);
                }
                return revercedList;
            };

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int number = int.Parse(Console.ReadLine());

            numbers = numbers.Where(x => RemoveDivisible(x, number)).ToList();

            Console.WriteLine(string.Join(" ", ReverseList(numbers)));
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, string, List<int>> ApplyArithmetics = (nums, opr) =>
            {
                if (opr == "add")
                {
                    nums = nums.Select(n => ++n).ToList();
                }
                else if (opr == "multiply")
                {
                    nums = nums.Select(n => n =n * 2).ToList();
                }
                else if (opr == "subtract")
                {
                    nums = nums.Select(n => --n).ToList();
                }
                else if (opr == "print")
                {
                    Console.WriteLine(string.Join(" ", nums));
                }

                return nums;
            };

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                numbers = ApplyArithmetics(numbers, command);
                command = Console.ReadLine().ToLower();
            }
        }
    }
}

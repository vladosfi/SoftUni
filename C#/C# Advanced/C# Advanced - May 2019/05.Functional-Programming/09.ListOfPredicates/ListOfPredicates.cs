using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main()
        {
            Func<int, int[], bool> ListOfPredicates = (int number, int[] devideNumbers) =>
            {
                foreach (var item in devideNumbers)
                {
                    if (number % item != 0)
                    {
                        return false;
                    }
                }
                return true;
            };

            int endRange = int.Parse(Console.ReadLine());
            int[] deviders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> predicates = new List<int>();

            for (int i = 1; i <= endRange; i++)
            {
                predicates.Add(i);
            }

            Console.WriteLine(string.Join(" ", predicates.Where(n => ListOfPredicates(n, deviders))));
        }
    }
}

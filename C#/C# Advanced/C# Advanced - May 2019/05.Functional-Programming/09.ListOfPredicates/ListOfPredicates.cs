using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main()
        {
            int endRange = int.Parse(Console.ReadLine());
            int[] deviders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            var numbers = Enumerable.Range(1, endRange).ToList();

            List<Predicate<int>> listOfPredicates = new List<Predicate<int>>();

            foreach (var devider in deviders)
            {
                listOfPredicates.Add(x => x % devider == 0);
            }

            foreach (var currentPredicate in listOfPredicates)
            {
                numbers = numbers.FindAll(currentPredicate);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

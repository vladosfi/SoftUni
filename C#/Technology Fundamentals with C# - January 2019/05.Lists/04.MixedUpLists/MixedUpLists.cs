using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class MixedUpLists
    {
        static void Main()
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int shorterListLen = Math.Min(firstList.Count, secondList.Count);

            List<int> resultList = new List<int>();

            for (int i = 0; i < shorterListLen; i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[secondList.Count - i - 1]);
            }

            int startRange;
            int endRange;

            if (shorterListLen == firstList.Count)
            {
                startRange = Math.Min(secondList[0], secondList[1]);
                endRange = Math.Max(secondList[0], secondList[1]);
            }
            else
            {
                startRange = Math.Min(firstList[shorterListLen], firstList[shorterListLen + 1]);
                endRange = Math.Max(firstList[shorterListLen], firstList[shorterListLen + 1]);
            }

            Console.WriteLine(string.Join(" ", resultList.Where(x => x > startRange && x < endRange).OrderBy(x=>x)));

        }
    }
}

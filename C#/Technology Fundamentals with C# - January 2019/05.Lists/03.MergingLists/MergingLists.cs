using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Lists
    {
        static void Main()
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> resultList = new List<int>();
            int maxLen = Math.Max(firstList.Count, secondList.Count);

            for (int i = 0; i < maxLen; i++)
            {
                if (firstList.Count > i)
                {
                    resultList.Add(firstList[i]);
                }
                if (secondList.Count > i)
                {
                    resultList.Add(secondList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}

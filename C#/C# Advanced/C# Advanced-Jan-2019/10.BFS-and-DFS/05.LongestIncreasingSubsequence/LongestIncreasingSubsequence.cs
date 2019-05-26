using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LongestIncreasingSubsequence
{
    class LongestIncreasingSubsequence
    {
        static void Main()
        {
            int[] seq = Console.ReadLine().Split().Select(int.Parse).ToArray();//{ 7, 3, 5, 8, -1, 0, 6, 7 };
            int[] len = new int[seq.Length];
            int[] prev = new int[seq.Length];
            int lastIndex = -1;
            int maxLen = 0;

            for (int x = 0; x < seq.Length; x++)
            {
                len[x] = 1;
                prev[x] = -1;

                for (int i = 0; i <= x - 1; i++)
                {
                    if (seq[i] < seq[x] && len[i] + 1 > len[x])
                    {
                        len[x] = 1 + len[i];
                        prev[x] = i;
                    }
                }

                if (len[x] > maxLen)
                {
                    maxLen = len[x];
                    lastIndex = x;
                }
            }

            List<int> longestSeq = new List<int>();

            while (lastIndex != -1)
            {
                longestSeq.Add(seq[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSeq.Reverse();

            Console.WriteLine(string.Join(" ", longestSeq));
        }
    }
}

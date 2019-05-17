using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class FoldAndSum
    {
        static void Main()
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int half = n.Length / 2;
            int quarter = half / 2;

            int[] sum = new int[half];
            int sumIndex = 0;

            for (int i = quarter; i < quarter * 2; i++)
            {
                //First half
                int firstFolf = quarter - 1 - sumIndex;
                sum[sumIndex] = n[i] + n[firstFolf];

                //Second half
                int secondFolf = half * 2 - sumIndex - 1;
                sum[sumIndex + quarter] = n[sumIndex + half] + n[secondFolf];

                sumIndex++;
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}

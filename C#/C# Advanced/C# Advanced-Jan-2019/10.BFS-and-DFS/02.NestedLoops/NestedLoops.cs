using System;

namespace _02.NestedLoops
{
    class NestedLoops
    {
        private static int[] arr;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            arr = new int[n];

            LoopsRecursion(n, 0);
        }

        private static void LoopsRecursion(int n, int counter)
        {
            if (counter >= n)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                arr[counter] = i;
                LoopsRecursion(n, counter + 1);
            }

        }
    }
}

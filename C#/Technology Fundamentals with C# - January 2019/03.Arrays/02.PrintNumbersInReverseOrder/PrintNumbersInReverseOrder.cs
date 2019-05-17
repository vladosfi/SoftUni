using System;

namespace _02.PrintNumbersInReverseOrder
{
    class PrintNumbersInReverseOrder
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = n-1; i >= 0; i--)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}

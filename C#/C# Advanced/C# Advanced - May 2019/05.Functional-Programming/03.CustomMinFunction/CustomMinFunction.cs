using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main()
        {
            Func<int[], int> minVal = n =>
            {
                int minValue = int.MaxValue;

                foreach (var num in n)
                {
                    if (minValue > num)
                    {
                        minValue = num;
                    }
                }

                return minValue;
            };

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minVal(numbers));
        }

    }
}

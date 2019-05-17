using System;
using System.Linq;

namespace _02.FromLeftToTheRight
{
    class FromLeftToTheRight
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Split();
                long firstNumber = long.Parse(numbers[0]);
                long secondNumber = long.Parse(numbers[1]);
                long max;

                if (firstNumber > secondNumber)
                {
                    max = firstNumber;
                }
                else
                {
                    max = secondNumber;
                }

                if (max < 0)
                {
                    max *= -1;
                }

                long sum = 0;

                while (max > 0)
                {
                    sum += max % 10;
                    max /= 10;
                }

                Console.WriteLine(sum);

            }
        }
    }
}

using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class PrimaryDiagonal
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers;
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}

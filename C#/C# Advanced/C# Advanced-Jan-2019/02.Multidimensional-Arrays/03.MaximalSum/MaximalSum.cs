using System;
using System.Linq;

namespace _03.MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = numbers[0];
            int m = numbers[1];
            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                numbers = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int maxSum = 0;
            int[,] maxMatrix = new int[3, 3];

            for (int row = 0; row <= matrix.GetLength(0) - 3; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - 3; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxMatrix[0, 0] = matrix[row, col];
                        maxMatrix[0, 1] = matrix[row, col + 1];
                        maxMatrix[0, 2] = matrix[row, col + 2];
                        maxMatrix[1, 0] = matrix[row + 1, col];
                        maxMatrix[1, 1] = matrix[row + 1, col + 1];
                        maxMatrix[1, 2] = matrix[row + 1, col + 2];
                        maxMatrix[2, 0] = matrix[row + 2, col];
                        maxMatrix[2, 1] = matrix[row + 2, col + 1];
                        maxMatrix[2, 2] = matrix[row + 2, col + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(maxMatrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

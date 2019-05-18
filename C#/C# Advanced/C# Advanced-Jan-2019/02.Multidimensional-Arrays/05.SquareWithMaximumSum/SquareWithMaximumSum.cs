using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = numbers[0];
            int cols = numbers[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int[,] maxSumMatrix = new int[2,2];
            int maxSum = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int curSum = matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row+1, col] +
                        matrix[row+1, col+1];

                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                        maxSumMatrix[0, 0] = matrix[row, col];
                        maxSumMatrix[0, 1] = matrix[row, col+1];
                        maxSumMatrix[1, 0] = matrix[row+1, col];
                        maxSumMatrix[1, 1] = matrix[row+1, col+1];
                    }

                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(maxSumMatrix[row,col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}

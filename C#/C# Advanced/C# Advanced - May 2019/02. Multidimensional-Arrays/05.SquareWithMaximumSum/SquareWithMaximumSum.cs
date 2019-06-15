using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main()
        {
            int[] sizeOfMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowCount = sizeOfMatrix[0];
            int colCount = sizeOfMatrix[1];
            int[,] matrix = new int[rowCount, colCount];

            for (int row = 0; row < rowCount; row++)
            {
                int[] curCol = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < colCount; col++)
                {
                    matrix[row, col] = curCol[col];
                }
            }


            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < rowCount - 1; row++)
            {
                for (int col = 0; col < colCount - 1; col++)
                {
                    int curSum =
                        matrix[row, col] +
                        matrix[row + 1, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col + 1];

                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int row = maxRow; row < maxRow + 2; row++)
            {
                for (int col = maxCol; col < maxCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);

        }
    }
}

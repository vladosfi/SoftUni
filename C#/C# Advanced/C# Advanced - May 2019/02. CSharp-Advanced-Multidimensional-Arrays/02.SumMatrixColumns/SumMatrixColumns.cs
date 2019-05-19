using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class SumMatrixColumns
    {
        static void Main()
        {
            int[] sizeOfMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowCount = sizeOfMatrix[0];
            int colCount = sizeOfMatrix[1];
            int[,] matrix = new int[rowCount, colCount];

            for (int row = 0; row < rowCount; row++)
            {
                int[] curCol = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < colCount; col++)
                {
                    matrix[row, col] = curCol[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int columnSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    columnSum += matrix[row, col];
                }
                Console.WriteLine(columnSum);
            }

        }
    }
}

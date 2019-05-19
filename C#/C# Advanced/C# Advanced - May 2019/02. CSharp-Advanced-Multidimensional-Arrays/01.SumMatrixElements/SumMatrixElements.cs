using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class SumMatrixElements
    {
        static void Main()
        {
            int[] sizeOfMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowCount = sizeOfMatrix[0];
            int colCount = sizeOfMatrix[1];
            int[,] matrix = new int[rowCount, colCount];
            int sum = 0;

            for (int row = 0; row < rowCount; row++)
            {
                int[] curCol = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < colCount; col++)
                {
                    matrix[row, col] = curCol[col];
                }
            }

            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}

using System;
using System.Linq;

namespace _02._2x2SquaresInMatrix
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int squareMatrixCount = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char checkSymbol = matrix[row, col];

                    if (checkSymbol == matrix[row, col + 1] &&
                         checkSymbol == matrix[row + 1, col] &&
                         checkSymbol == matrix[row + 1, col + 1])
                    {
                        squareMatrixCount++;
                    }
                }
            }

            Console.WriteLine(squareMatrixCount);

        }
    }
}

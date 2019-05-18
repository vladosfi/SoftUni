using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            int colNum = n;

            for (int i = 0; i < n; i++)
            {
                colNum--;
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[i, colNum];
            }


            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}

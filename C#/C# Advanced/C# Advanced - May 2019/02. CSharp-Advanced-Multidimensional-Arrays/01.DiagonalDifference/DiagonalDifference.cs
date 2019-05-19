using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int row = 0; row < n; row++)
            {
                primarySum += matrix[row, row];
                secondarySum += matrix[row, n - row - 1];
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}

using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class SumMatrixElements
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = numbers[0];
            int cols = numbers[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum = 0;

            foreach (var item in matrix)
            {
                sum+=item;
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}

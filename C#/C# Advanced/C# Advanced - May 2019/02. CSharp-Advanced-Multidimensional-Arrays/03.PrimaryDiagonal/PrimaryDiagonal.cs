using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class PrimaryDiagonal
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] curCol = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = curCol[col];
                }
            }

            int sum = 0;

            for (int step = 0; step < size; step++)
            {
                sum += matrix[step, step];
            }

            Console.WriteLine(sum);
        }
    }
}

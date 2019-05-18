using System;
using System.Linq;

namespace _08.Bombs
{
    class Bombs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            if (n == 0)
            {
                return;
            }

            for (int row = 0; row < n; row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split();

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] coordinate = coordinates[i].Split(",").Select(int.Parse).ToArray();
                int row = coordinate[0];
                int col = coordinate[1];
                int bomVal = matrix[row, col];
                if (matrix[row, col] > 0)
                {
                    matrix[row, col] = 0;
                    ExplosionDamage(n, matrix, row, col, bomVal);
                }
            }


            Console.WriteLine($"Alive cells: {GetCountOfAliveCells(n, matrix)}");
            Console.WriteLine($"Sum: {GetSum(n, matrix)}");
            PrintMatrix(n, matrix);


        }

        private static void ExplosionDamage(int n, int[,] matrix, int row, int col, int bomVal)
        {
            if (row - 1 >= 0 && col - 1 >= 0 && matrix[row - 1, col - 1] > 0)
            {
                matrix[row - 1, col - 1] = matrix[row - 1, col - 1] - bomVal;
            }
            if (row - 1 >= 0 && matrix[row - 1, col] > 0)
            {
                matrix[row - 1, col] = matrix[row - 1, col] - bomVal;
            }
            if (row - 1 >= 0 && col + 1 < n && matrix[row - 1, col + 1] > 0)
            {
                matrix[row - 1, col + 1] = matrix[row - 1, col + 1] - bomVal;
            }

            if (col - 1 >= 0 && matrix[row, col - 1] > 0)
            {
                matrix[row, col - 1] = matrix[row, col - 1] - bomVal;
            }
            if (col + 1 < n && matrix[row, col + 1] > 0)
            {
                matrix[row, col + 1] = matrix[row, col + 1] - bomVal;
            }

            if (row + 1 < n && col - 1 >= 0 && matrix[row + 1, col - 1] > 0)
            {
                matrix[row + 1, col - 1] = matrix[row + 1, col - 1] - bomVal;
            }
            if (row + 1 < n && matrix[row + 1, col] > 0)
            {
                matrix[row + 1, col] = matrix[row + 1, col] - bomVal;
            }
            if (row + 1 < n && col + 1 < n && matrix[row + 1, col + 1] > 0)
            {
                matrix[row + 1, col + 1] = matrix[row + 1, col + 1] - bomVal;
            }
        }

        private static object GetCountOfAliveCells(int n, int[,] matrix)
        {
            int count = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static long GetSum(int n, int[,] matrix)
        {
            long sum = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            return sum;
        }

        private static void PrintMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

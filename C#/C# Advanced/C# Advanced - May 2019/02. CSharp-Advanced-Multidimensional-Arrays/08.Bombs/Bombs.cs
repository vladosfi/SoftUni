using System;
using System.Linq;

namespace _08.Bombs
{
    class Bombs
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

            string[] bombs = Console.ReadLine().Split();

            foreach (var bomb in bombs)
            {
                int[] bombCoordinates = bomb.Split(",").Select(int.Parse).ToArray();
                int bombRow = bombCoordinates[0];
                int bombCol = bombCoordinates[1];
                int damage = matrix[bombRow, bombCol];

                if (matrix[bombRow, bombCol] > 0)
                {
                    matrix[bombRow, bombCol] = 0;
                }

                for (int row = bombRow - 1; row <= bombRow + 1; row++)
                {
                    for (int col = bombCol - 1; col <= bombCol + 1; col++)
                    {
                        if (row >= 0 && row < n && col >= 0 && col < n)
                        {
                            if (matrix[row, col] > 0)
                            {
                                matrix[row, col] -= damage;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Alive cells: {GetAliveCells(n, matrix)}");
            Console.WriteLine($"GetSum: {GetSum(n, matrix)}");
            Print(n, matrix);
        }

        private static int GetSum(int n, int[,] matrix)
        {
            int sum = 0;

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

        private static int GetAliveCells(int n, int[,] matrix)
        {
            int counter = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        private static void Print(int n, int[,] matrix)
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

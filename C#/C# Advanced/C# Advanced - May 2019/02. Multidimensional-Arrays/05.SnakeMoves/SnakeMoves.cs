using System;
using System.Linq;

namespace _01.SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            int counter = rows * cols;

            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    counter--;
                    if (counter > 0)
                    {
                        int curChar = counter % (snake.Length);
                        matrix[row, col] = snake[curChar];
                    }
                    else
                    {
                        matrix[row, col] = snake[0];
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}

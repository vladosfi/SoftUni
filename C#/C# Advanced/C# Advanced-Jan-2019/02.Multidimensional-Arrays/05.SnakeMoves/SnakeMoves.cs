using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class SnakeMoves
    {
        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (size.Length != 2)
            {
                return;
            }

            int rows = size[0];
            int cols = size[1];

            string snake = Console.ReadLine();
            int snakeLenght = snake.Length;
            int counter = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    counter = counter % snakeLenght;
                    matrix[row, col] = snake[counter];
                    counter++;
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
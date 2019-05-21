using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Miner
{
    class Miner
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            Queue<string> commands = new Queue<string>(input);
            char[,] field = new char[fieldSize, fieldSize];
            int rowIndex = 0;
            int colIndex = 0;
            int remainingCoals = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                char[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    if (line[col] == 's')
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                    if (line[col] == 'c')
                    {
                        remainingCoals++;
                    }
                    field[row, col] = line[col];
                }
            }

            int collectedCoals = 0;

            while (commands.Count > 0)
            {
                string command = commands.Dequeue().ToLower();

                if (command == "up" && rowIndex - 1 >= 0)
                {
                    rowIndex--;
                }
                else if (command == "right" && colIndex + 1 < fieldSize)
                {
                    colIndex++;
                }
                else if (command == "left" && colIndex - 1 >= 0)
                {
                    colIndex--;
                }
                else if (command == "down" && rowIndex + 1 < fieldSize)
                {
                    rowIndex++;
                }

                if (field[rowIndex, colIndex] == 'c')
                {
                    field[rowIndex, colIndex] = '*';
                    collectedCoals++;
                    remainingCoals--;

                    if (remainingCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                        return;
                    }
                }
                if (field[rowIndex, colIndex] == 'e')
                {
                    collectedCoals++;
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    return;
                }

            }

            Console.WriteLine($"{remainingCoals} coals left. ({rowIndex}, {colIndex})");
        }
    }
}

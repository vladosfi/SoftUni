using System;

namespace _09.Miner
{
    class Miner
    {
        static void Main()
        {
            int remainingCoals = 0;
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[,] mine = new string[size, size];
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < size; row++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < size; col++)
                {
                    string symbol = line[col];

                    if (symbol == "c")
                    {
                        remainingCoals++;
                    }
                    else if (symbol == "s")
                    {
                        rowIndex = row;
                        colIndex = col;
                    }

                    mine[row, col] = symbol;
                }
            }

            string currentSymbol = mine[rowIndex, colIndex];

            foreach (var command in commands)
            {
                if (command == "up" && rowIndex - 1 >= 0)
                {
                    rowIndex--;
                }
                else if (command == "down" && rowIndex + 1 < size)
                {
                    rowIndex++;
                }
                else if (command == "right" && colIndex + 1 < size)
                {
                    colIndex++;
                }
                else if (command == "left" && colIndex - 1 >= 0)
                {
                    colIndex--;
                }

                currentSymbol = mine[rowIndex, colIndex];

                if (currentSymbol == "c")
                {
                    remainingCoals--;
                    mine[rowIndex, colIndex] = "*";
                }
                else if (currentSymbol == "e")
                {
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    return;
                }

                if (remainingCoals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                    return;
                }
            }

            Console.WriteLine($"{remainingCoals} coals left. ({rowIndex}, {colIndex})");
        }
    }
}

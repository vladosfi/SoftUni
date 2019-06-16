using System;
using System.Linq;

namespace _01.Problem
{
    class StartUp
    {
        public static int harmedCount = 0;

        static void Main()
        {
            int countOfCarrots = 0;
            int countOfPotatos = 0;
            int countOfCucmbers = 0;
            int n = int.Parse(Console.ReadLine());

            char[][] garden = new char[n][];

            for (int i = 0; i < n; i++)
            {
                char[] rowsOfGarden = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                garden[i] = new char[rowsOfGarden.Length];

                for (int j = 0; j < rowsOfGarden.Length; j++)
                {
                    garden[i][j] = rowsOfGarden[j];
                }
            }

            string input = Console.ReadLine();

            while (input.ToLower() != "end of harvest")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0].ToLower();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (row < 0 || row > garden.Length - 1 ||
                    col < 0 || col > garden[row].Length -1)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (command == "harvest")
                {
                    char cell = garden[row][col];

                    if (cell == 'C')
                    {
                        countOfCarrots++;
                        garden[row][col] = ' ';
                    }
                    else if (cell == 'P')
                    {
                        countOfPotatos++;
                        garden[row][col] = ' ';
                    }
                    else if (cell == 'L')
                    {
                        countOfCucmbers++;
                        garden[row][col] = ' ';
                    }
                }
                if (command == "mole")
                {
                    string direction = tokens[3].ToLower();
                    if (garden[row][col] != ' ')
                    {
                        Move(direction, row, col, garden);
                    }
                    
                }

                input = Console.ReadLine();
            }


            Print(garden);

            Console.WriteLine($"Carrots: {countOfCarrots}");
            Console.WriteLine($"Potatoes: {countOfPotatos}");
            Console.WriteLine($"Lettuce: {countOfCucmbers}");
            Console.WriteLine($"Harmed vegetables: {harmedCount}");
        }

        private static void Print(char[][] garden)
        {
            foreach (var col in garden)
            {
                Console.WriteLine(string.Join(" ", col));
            }
        }

        private static void Move(string direction, int row, int col, char[][] garden)
        {
            if (direction == "up")
            {
                for (int i = row; i >= 0; i -= 2)
                {
                    if (CellContainsVegitable(i, col, garden))
                    {
                        garden[i][col] = ' ';
                        harmedCount++;
                    }
                }
            }
            else if (direction == "down")
            {
                for (int i = row; i < garden.Length; i += 2)
                {
                    if (CellContainsVegitable(i, col, garden))
                    {
                        garden[i][col] = ' ';
                        harmedCount++;
                    }
                }
            }
            else if (direction == "left")
            {
                for (int i = col; i >= 0; i -= 2)
                {
                    if (CellContainsVegitable(row, i, garden))
                    {
                        garden[row][i] = ' ';
                        harmedCount++;
                    }
                }
            }
            else if (direction == "right")
            {
                for (int i = col; i < garden[row].Length; i += 2)
                {
                    if (CellContainsVegitable(row, i, garden))
                    {
                        garden[row][i] = ' ';
                        harmedCount++;
                    }
                }
            }
        }

        private static bool CellContainsVegitable(int row, int col, char[][] garden)
        {
            if (garden[row][col] == 'C' || garden[row][col] == 'P' || garden[row][col] == 'L')
            {
                return true;
            }

            return false;
        }
    }
}

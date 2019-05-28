using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            int[] samPosition = new int[2];

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine().Trim();
                matrix[row] = new char[line.Length];

                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row][col] = line[col];

                    if (matrix[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }

            string input = Console.ReadLine();
            Queue<char> commands = new Queue<char>();

            foreach (var command in input)
            {
                commands.Enqueue(command);
            }

            bool samIsDead = false;

            while (commands.Count > 0 && !samIsDead)
            {
                //Move enemies
                MoveEnemies(matrix);

                //Is Sam dead
                samIsDead = IsSamDead(samPosition, matrix);

                if (samIsDead)
                {
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    break;
                }

                //Sam move 
                char move = commands.Dequeue();
                int[] samNextPosition = new int[2];

                matrix[samPosition[0]][samPosition[1]] = '.';

                if (move == 'U')
                {
                    samPosition[0]--;
                }
                else if (move == 'D')
                {
                    samPosition[0]++;
                }
                else if (move == 'L')
                {
                    samPosition[1]--;
                }
                else if (move == 'R')
                {
                    samPosition[1]++;
                }

                matrix[samPosition[0]][samPosition[1]] = 'S';                

                if (matrix[samPosition[0]].Contains('N'))
                {
                    int nikoladzeCol = Array.IndexOf(matrix[samPosition[0]], 'N');
                    matrix[samPosition[0]][nikoladzeCol] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            Print(matrix);
        }

        private static void MoveEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b' &&
                        col == matrix[row].Length - 1)
                    {
                        matrix[row][col] = 'd';
                    }
                    else if (matrix[row][col] == 'b')
                    {
                        matrix[row][col] = '.';
                        matrix[row][col + 1] = 'b';
                        col++;
                    }
                    else if (matrix[row][col] == 'd' &&
                        col == 0)
                    {
                        matrix[row][col] = 'b';
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        matrix[row][col] = '.';
                        matrix[row][col - 1] = 'd';
                    }
                }
            }
        }

        private static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsSamDead(int[] samPosition, char[][] matrix)
        {
            bool isDead = false;

            for (int col = 0; col < matrix[samPosition[0]].Length; col++)
            {
                if ((matrix[samPosition[0]][col] == 'b' && samPosition[1] > col) || 
                    (matrix[samPosition[0]][col] == 'd' && samPosition[1] < col))
                {
                    matrix[samPosition[0]][samPosition[1]] = 'X';
                    isDead = true;
                    break;
                }
            }

            return isDead;
        }
    }
}

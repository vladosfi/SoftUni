using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];
            char[,] lair = new char[n, m];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < m; col++)
                {
                    lair[row, col] = line[col];

                    if (line[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();
            string playerState = string.Empty;

            foreach (var command in commands)
            {
                lair[playerRow, playerCol] = '.';
                if (command == 'U' && playerRow - 1 >= 0)
                {
                    playerRow--;
                }
                else if (command == 'D' && playerRow + 1 < n)
                {
                    playerRow++;
                }
                else if (command == 'L' && playerCol - 1 >= 0)
                {
                    playerCol--;
                }
                else if (command == 'R' && playerCol + 1 < m)
                {
                    playerCol++;
                }
                else
                {
                    playerState = "won";
                }

                if (playerState != "won" && lair[playerRow, playerCol] != 'B')
                {
                    lair[playerRow, playerCol] = 'P';
                }

                BunnySpread(n, m, lair);

                if (playerState == "won")
                {
                    break;
                }

                if (IsPlayerDead(n, m, lair))
                {
                    playerState = "dead";
                    break;
                }
            }

            PrintLair(n, m, lair);
            if (playerState == "dead")
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else if (playerState == "won")
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }

        private static void BunnySpread(int n, int m, char[,] lair)
        {
            char[,] lairSpeaded = new char[n, m];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    lairSpeaded[row, col] = lair[row, col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        lairSpeaded[row, col] = 'B';

                        if (row - 1 >= 0)
                        {
                            lairSpeaded[row - 1, col] = 'B';
                        }
                        if (row + 1 < n)
                        {
                            lairSpeaded[row + 1, col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            lairSpeaded[row, col - 1] = 'B';
                        }
                        if (col + 1 < m)
                        {
                            lairSpeaded[row, col + 1] = 'B';
                        }
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    lair[row, col] = lairSpeaded[row, col];
                }
            }
        }

        private static void PrintLair(int n, int m, char[,] lair)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
        }


        private static bool IsPlayerDead(int n, int m, char[,] lair)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (lair[row, col] == 'P')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

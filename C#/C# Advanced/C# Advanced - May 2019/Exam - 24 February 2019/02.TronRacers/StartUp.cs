using System;

namespace _02.TronRacers
{
    class StartUp
    {
        static char[][] matrix;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());            
            int[] firstPalyerPosition = new int[2];
            int[] secondPalyerPosition = new int[2];
            matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                matrix[row] = new char[n];

                for (int col = 0; col < n; col++)
                {
                    matrix[row][col] = input[col];

                    if (input[col] == 'f')
                    {
                        firstPalyerPosition[0] = row;
                        firstPalyerPosition[1] = col;
                    }
                    else if (input[col] == 's')
                    {
                        secondPalyerPosition[0] = row;
                        secondPalyerPosition[1] = col;
                    }
                }
            }


            while (true)
            {

                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (MovePlayer(command, 0, firstPalyerPosition) ||
                    MovePlayer(command, 1, secondPalyerPosition))
                {
                    break;
                }
            }

            
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }

        }

        private static bool MovePlayer(string[] command, int player, int[] playerPosition)
        {
            bool isPlayerDead = false;
            int row = playerPosition[0];
            int col = playerPosition[1];
            char playerSymbol = matrix[row][col];

            switch (command[player])
            {
                case "up":

                    playerPosition[0]--;

                    if (GoesOut(playerPosition))
                    {
                        playerPosition[0] = matrix.Length - 1;
                    }

                    if (IsDead(playerPosition))
                    {
                        matrix[playerPosition[0]][playerPosition[1]] = 'x';
                        isPlayerDead = true;
                    }
                    else
                    {
                        matrix[playerPosition[0]][playerPosition[1]] = playerSymbol;
                    }                    
                    break;
                case "down":

                    playerPosition[0]++;

                    if (GoesOut(playerPosition))
                    {
                        playerPosition[0] = 0;
                    }

                    if (IsDead(playerPosition))
                    {
                        matrix[playerPosition[0]][playerPosition[1]] = 'x';
                        isPlayerDead = true;
                    }
                    else
                    {
                        matrix[playerPosition[0]][playerPosition[1]] = playerSymbol;
                    }
                    break;
                case "left":
                    playerPosition[1]--;

                    if (GoesOut(playerPosition))
                    {
                        playerPosition[1] = matrix[playerPosition[0]].Length - 1;
                    }

                    if (IsDead(playerPosition))
                    {
                        matrix[playerPosition[0]][playerPosition[1]] = 'x';
                        isPlayerDead = true;
                    }
                    else
                    {
                        matrix[playerPosition[0]][playerPosition[1]] = playerSymbol;
                    }
                    break;
                case "right":
                    playerPosition[1]++;

                    if (GoesOut(playerPosition))
                    {
                        playerPosition[1] = 0;
                    }

                    if (IsDead(playerPosition))
                    {
                        matrix[playerPosition[0]][playerPosition[1]] = 'x';
                        isPlayerDead = true;
                    }
                    else
                    {
                        matrix[playerPosition[0]][playerPosition[1]] = playerSymbol;
                    }
                    break;
                default:
                    break;
            }

            return isPlayerDead;
        }

        private static bool IsDead(int[] playerPosition)
        {
            bool result = false;

            if (matrix[playerPosition[0]][playerPosition[1]] != '*')
            {
                result = true;
            }

            return result;
        }

        private static bool GoesOut(int[] palyerPosition)
        {
            bool result = true;

            if (palyerPosition[0] >= 0 && 
                palyerPosition[1] >= 0 &&
                palyerPosition[0] < matrix.Length && 
                palyerPosition[1] < matrix[palyerPosition[0]].Length)
            {
                result = false;
            }

            return result;
        }
    }
}

using System;
using System.Linq;

namespace _06.BombTheBasement
{
    class BombTheBasement
    {
        static void Main()
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = size[0];
            int m = size[1];

            int[] bombParameters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int targetRow = bombParameters[0];
            int targetCol = bombParameters[1];
            int radius = bombParameters[2];

            int[,] basement = new int[n, m];

            // Generate damage
            int startPointRow = targetRow - radius;
            int endPointRow = targetRow + radius;
            int colDamage = 0;

            for (int row = 0; row < n; row++)
            {
                if (row >= startPointRow && row <= endPointRow)
                {
                    for (int col = 0; col < m; col++)
                    {
                        if (col >= targetCol - colDamage && col <= targetCol + colDamage)
                        {
                            basement[row, col] = 1;
                        }                 
                    }

                    if (row < targetRow)
                    {
                        colDamage++;
                    }
                    else
                    {
                        colDamage--;
                    }
                }
            }
            
            // Falling down 
            FallingDown(basement);

            PrintMatrix(basement);

        }

        private static void FallingDown(int[,] basement)
        {
            for (int row = 0; row < basement.GetLength(0); row++)
            {
                for (int col = 0; col < basement.GetLength(1); col++)
                {
                    if (basement[row,col] == 1)
                    {
                        int curRow = row - 1;

                        while (true)
                        {
                            if (curRow < 0 || basement[curRow, col] == 1)
                            {
                                break;
                            }
                            basement[curRow + 1, col] = 0;
                            basement[curRow, col] = 1;
                            curRow--;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(int[,] basement)
        {
            for (int row = 0; row < basement.GetLength(0); row++)
            {
                for (int col = 0; col < basement.GetLength(1); col++)
                {
                    Console.Write(basement[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

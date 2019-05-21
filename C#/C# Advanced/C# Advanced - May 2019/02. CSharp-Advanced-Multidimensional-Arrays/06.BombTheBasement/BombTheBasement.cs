using System;
using System.Linq;

namespace _06.BombTheBasement
{
    class BombTheBasement
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] basement = new int[rows, cols];
            int[] bombParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowHit = bombParameters[0];
            int colHit = bombParameters[1];
            int bombPower = bombParameters[2];
            int shift = -1;
            bool increase = true;

            for (int row = rowHit - bombPower; row <= rowHit + bombPower; row++)
            {
                if (shift == bombPower)
                {
                    increase = false;
                }

                if (increase)
                {
                    shift++;
                }
                else
                {
                    shift--;
                }

                for (int col = colHit - shift; col <= colHit + shift; col++)
                {
                    if (row >= 0 && row < rows && col >=0 && col < cols)
                    {
                        basement[row, col] = 1;
                    }
                }
            }

            
            FallingDown(rows, cols, basement);
            Print(rows, cols, basement);
        }

        private static void FallingDown(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        for (int i = row; i > 0; i--)
                        {
                            if (matrix[i - 1, col] == 0)
                            {
                                matrix[i, col] = 0;
                                matrix[i - 1, col] = 1;
                            }
                        }
                    }
                }
            }
        }

        private static void Print(int rows, int cols, int[,] matrix)
        {
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

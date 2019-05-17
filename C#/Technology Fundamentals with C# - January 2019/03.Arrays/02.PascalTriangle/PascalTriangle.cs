using System;

namespace _02.PascalTriangle
{
    class PascalTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] pascal = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    if (col == 0 || col == row)
                    {
                        pascal[row, col] = 1;
                    }
                    else
                    {
                        pascal[row, col] = pascal[row - 1, col] + pascal[row - 1, col - 1];
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    if (col == row)
                    {
                        Console.Write(pascal[row, col]);
                    }
                    else
                    {
                        Console.Write(pascal[row, col] + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = numbers[0];
            int m = numbers[1];
            string[,] matrix = new string[n, m];

            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0].ToLower() == "end")
                {
                    break;
                }
                else if (tokens[0].ToLower() == "swap" && tokens.Length == 5)
                {
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    if (row1 < 0 || row1 >= matrix.GetLength(0) 
                        || row2 < 0 || row2 >= matrix.GetLength(0) 
                        || col1 < 0 || col1 >= matrix.GetLength(1) 
                        || col2 < 0 || col2 >= matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string val = matrix[row1, col1];

                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = val;

                        PrintMatrix(matrix);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}

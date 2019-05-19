using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                
                if (tokens.Length != 5 || command != "swap" )
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                int row1 = int.Parse(tokens[1]);
                int col1 = int.Parse(tokens[2]);
                int row2 = int.Parse(tokens[3]);
                int col2 = int.Parse(tokens[4]);

                if (row1 < 0 || row1 > matrix.GetLength(0) ||
                    col1 < 0 || col1 > matrix.GetLength(0) ||
                    row2 < 0 || row2 > matrix.GetLength(1) ||
                    col2 < 0 || col2 > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                string tempValue = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = tempValue;
                PrinMatrix(matrix);

                input = Console.ReadLine();
            }
        }

        public static void PrinMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

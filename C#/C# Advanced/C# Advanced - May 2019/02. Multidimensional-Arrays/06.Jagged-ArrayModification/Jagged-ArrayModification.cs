using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class ArrayModification
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                string[] tokens = input.Split();
                string command = tokens[0].ToLower();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                {
                    input = Console.ReadLine();
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "add")
                {
                    matrix[row, col] += value;
                }
                else if (command == "subtract")
                {
                    matrix[row, col] -= value;
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}

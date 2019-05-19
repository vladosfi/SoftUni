using System;

namespace _04.SymbolInMatrix
{
    class SymbolInMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            char charToFind = char.Parse(Console.ReadLine());
            string result = $"{charToFind} does not occur in the matrix";
            bool isFound = false;

            for (int row = 0; row < n && !isFound; row++)
            {
                for (int col = 0; col < n && !isFound; col++)
                {
                    if (matrix[row, col] == charToFind)
                    {
                        result = $"({row}, {col})";
                        isFound = true;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}

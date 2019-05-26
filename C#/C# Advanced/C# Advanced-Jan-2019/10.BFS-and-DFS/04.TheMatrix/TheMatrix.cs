using System;
using System.Linq;

namespace _04.TheMatrix
{
    class TheMatrix
    {
        public static int rows;
        public static int cols;

        static void Main()
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rows = size[0];
            cols = size[1];

            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Replace(" ", "").ToCharArray();
            }

            char fillChar = char.Parse(Console.ReadLine());
            int[] startPosition = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startRow = startPosition[0];
            int startCol = startPosition[1];

            char charToReplace = matrix[startRow][startCol];

            FillMatrix(matrix, startRow, startCol, fillChar, charToReplace);

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }

        private static void FillMatrix(char[][] matrix, int r, int c, char fillChar, char charToReplace)
        {
            if (!IsInBounds(r, c) || matrix[r][c] == fillChar || matrix[r][c] != charToReplace)
            {
                return;
            }

            matrix[r][c] = fillChar;

            FillMatrix(matrix, r + 1, c, fillChar, charToReplace);
            FillMatrix(matrix, r - 1, c, fillChar, charToReplace);
            FillMatrix(matrix, r, c + 1, fillChar, charToReplace);
            FillMatrix(matrix, r, c - 1, fillChar, charToReplace);
        }

        private static bool IsInBounds(int row, int col)
        {
            return row < rows && row >= 0 && col < cols && col >= 0;
        }
    }
}

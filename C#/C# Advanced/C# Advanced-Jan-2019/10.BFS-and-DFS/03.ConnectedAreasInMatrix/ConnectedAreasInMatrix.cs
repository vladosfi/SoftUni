using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ConnectedAreasInMatrix
{
    class ConnectedAreasInMatrix
    {

        private struct Area
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public int Size { get; set; }
        }

        public static int rows;
        public static int cols;

        static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            List<Area> arias = new List<Area>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == '-')
                    {
                        Area area = new Area();
                        area.Row = row;
                        area.Col = col;
                        int size = 0;
                        FindAreaSize(matrix, row, col, ref size);
                        area.Size = size;
                        arias.Add(area);
                    }
                }
            }

            Console.WriteLine($"Total areas found: {arias.Count}");
            int counter = 0;

            foreach (var area in arias.OrderByDescending(a => a.Size).ThenBy(a => a.Row).ThenBy(a => a.Col))
            {
                counter++;
                Console.WriteLine($"Area #{counter} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void FindAreaSize(char[][] matrix, int row, int col, ref int size)
        {
            if (!IsInBounds(row,col) || matrix[row][col] == '*' || matrix[row][col] == 'X')
            {
                return;
            }

            size++;
            matrix[row][col] = 'X';

            FindAreaSize(matrix, row + 1, col, ref size);
            FindAreaSize(matrix, row, col + 1, ref size);
            FindAreaSize(matrix, row - 1, col, ref size);
            FindAreaSize(matrix, row, col - 1, ref size);
        }

        private static bool IsInBounds(int row, int col)
        {
            return row < rows && row >= 0 && col < cols && col >= 0;
        }
    }
}

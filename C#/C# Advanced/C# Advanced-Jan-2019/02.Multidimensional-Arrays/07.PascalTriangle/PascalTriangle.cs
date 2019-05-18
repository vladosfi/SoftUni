using System;

namespace _07.PascalTriangle
{
    class PascalTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[n][];

            for (int row = 0; row < n; row++)
            {
                pascalTriangle[row] = new long[row + 1];

                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    if (col == 0 || col == pascalTriangle[row].Length - 1)
                    {
                        pascalTriangle[row][col] = 1;
                    }
                    else
                    {
                        pascalTriangle[row][col] = pascalTriangle[row - 1][col] + pascalTriangle[row - 1][col - 1];
                    }
                }
            }


            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}

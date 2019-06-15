using System;

namespace _07.PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];

            for (int i = 0; i < n; i++)
            {
                triangle[i] = new long[i + 1];

                for (int j = 0; j < i + 1; j++)
                {
                    if (j == 0 || j == triangle[i].Length - 1)
                    {
                        triangle[i][j] = 1;
                    }
                    else
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }
            }

            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ExcelFunctions
{
    class ExcelFunctions
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[][] table = new string[n][];


            for (int row = 0; row < n; row++)
            {
                string[] line = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                table[row] = new string[line.Length];

                for (int col = 0; col < line.Length; col++)
                {
                    table[row][col] = line[col];
                }
            }

            string[] tokens = Console.ReadLine().Split();
            string command = tokens[0];
            string header = tokens[1];


        }
    }
}

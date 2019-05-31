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
            int headerIndex = Array.IndexOf(table[0], header);

            if (command == "hide")
            {
                for (int row = 0; row < n; row++)
                {
                    List<string> lineToPrint = new List<string>(table[row]);
                    lineToPrint.RemoveAt(headerIndex);

                    //List<string> lineToPrint = new List<string>();
                    //lineToPrint.AddRange(table[row].Take(headerIndex)); 
                    //lineToPrint.AddRange(table[row].Skip(headerIndex + 1).Take(table[row].Length - headerIndex));

                    //Console.WriteLine(string.Join(" | ", table[row]
                    //    .Where((value, index) => index != headerIndex)
                    //   .ToArray()));
                      

                    Console.WriteLine(string.Join(" | ", lineToPrint));
                }
            }
            else if (command == "sort")
            {
                string[] headerRow = table[0];
                Console.WriteLine(string.Join(" | ", headerRow));

                table = table.OrderBy(x => x[headerIndex]).ToArray();

                for (int i = 0; i < n; i++)
                {
                    if (headerRow == table[i])
                    {
                        continue;
                    }

                    Console.WriteLine(string.Join(" | ",table[i]));
                }

            }
            else if (command == "filter")
            {
                string value = tokens[2];

                for (int row = 0; row < n; row++)
                {
                    if (row == 0 || table[row][headerIndex] == value)
                    {
                        Console.WriteLine(string.Join(" | ", table[row]));
                    }
                }
            }
        }
    }
}

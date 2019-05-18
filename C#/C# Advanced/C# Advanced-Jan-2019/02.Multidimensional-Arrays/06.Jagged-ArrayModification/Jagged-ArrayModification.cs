using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class JaggedArrayModification
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jagged[row] = new int[numbers.Length];

                for (int col = 0; col < numbers.Length; col++)
                {
                    jagged[row][col] = numbers[col];
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];

                if (command.ToLower() == "end")
                {
                    break;
                }

                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row < 0 || col < 0 || row >= jagged.Length || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    jagged[row][col] += value; 
                }
                else if (command == "Subtract")
                {
                    jagged[row][col] -= value;
                }
            }

            foreach (var col in jagged)
            {
                Console.WriteLine(string.Join(" ", col));
            }
            
        }
    }
}

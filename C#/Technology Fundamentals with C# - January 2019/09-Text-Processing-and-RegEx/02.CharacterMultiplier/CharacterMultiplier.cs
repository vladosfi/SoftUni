using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            string max = string.Empty;
            string min = string.Empty;

            if (input[0].Length >= input[1].Length)
            {
                max = input[0];
                min = input[1];
            }
            else
            {
                max = input[1];
                min = input[0];
            }

            int totalSum = 0;

            for (int i = 0; i < min.Length; i++)
            {
                totalSum += (int)min[i] * (int)max[i];
            }

            for (int i = min.Length; i < max.Length; i++)
            {
                totalSum += (int)max[i];
            }

            Console.WriteLine(totalSum);
        }
    }
}

using System;

namespace _04.ReverseArrayOfStrings
{
    class ReverseArrayOfStrings
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write($"{input[i]} ");
            }

            Console.WriteLine();
        }
    }
}

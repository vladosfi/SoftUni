using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            Func<int, int> addOne = x => x + 1;

            Func<int, int> multiplyByTwo = x => x * 2;

            Func<int, int> subtractOne = x => x - 1;

            Action<int[]> print = nums
                => Console.WriteLine(string.Join(" ", nums));

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(addOne).ToArray();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multiplyByTwo).ToArray();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(subtractOne).ToArray();
                }
                else if (command == "print")
                {
                    print(numbers);
                }
                
                command = Console.ReadLine().ToLower();
            }

            
        }
    }
}

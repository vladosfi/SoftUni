using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int s = input[1];
            int x = input[2];
            Stack<int> numbers = new Stack<int>();

            input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = n-1; i >= 0; i--)
            {
                numbers.Push(input[i]);
            }

            int count = Math.Min(s, numbers.Count);
            for (int i = 0; i < count; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Any())
            {
                Console.WriteLine(numbers.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}

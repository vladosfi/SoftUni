using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main()
        {
            int[] arguments = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = arguments[0];
            int s = arguments[1];
            int x = arguments[2];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers.Take(n));

            for (int i = 0; i < s; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }

            if (stack.Any())
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}

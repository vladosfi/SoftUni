using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class StackSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            string inpit = Console.ReadLine().ToLower();

            while (inpit != "end")
            {
                string[] tokens = inpit.Split();
                string command = tokens[0];

                if (command == "add")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        stack.Push(int.Parse(tokens[i]));
                    }
                }
                else if (command == "remove")
                {
                    int count = int.Parse(tokens[1]);
                    if (count < stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                inpit = Console.ReadLine().ToLower();
            }

            int sum = 0;
            while (stack.Any())
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}

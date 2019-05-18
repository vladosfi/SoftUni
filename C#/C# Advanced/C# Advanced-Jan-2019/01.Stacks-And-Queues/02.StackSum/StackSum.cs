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
            Stack<int> stackOfNumbers = new Stack<int>(numbers);

            while (true)
            {
                string command = Console.ReadLine().ToLower();

                if (command == "end")
                {
                    break;
                }

                string[] tockens = command.Split();

                if (tockens[0] == "add")
                {
                    for (int i = 1; i < tockens.Length; i++)
                    {
                        stackOfNumbers.Push(int.Parse(tockens[i]));
                    }
                }
                else if (tockens[0] == "remove")
                {
                    int elementsToRemove = int.Parse(tockens[1]);

                    if (stackOfNumbers.Count > elementsToRemove)
                    {
                        for (int i = 0; i < elementsToRemove; i++)
                        {
                            stackOfNumbers.Pop();
                        }
                    }
                }
            }

            int sum = 0;

            while (stackOfNumbers.Any())
            {
                sum += stackOfNumbers.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}

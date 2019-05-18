using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class MaximumAndMinimumElement
    {
        static void Main()
        {
            int queries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> tmpStack = new Stack<int>();

            for (int i = 0; i < queries; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int comand = tokens[0];

                switch (comand)
                {
                    case 1:
                        stack.Push(tokens[1]);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            int max = int.MinValue;
                            while (stack.Count > 0)
                            {
                                if (max < stack.Peek())
                                {
                                    max = stack.Peek();
                                }
                                tmpStack.Push(stack.Pop());
                            }
                            while (tmpStack.Count > 0)
                            {
                                stack.Push(tmpStack.Pop());
                            }
                            Console.WriteLine(max);
                        }
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            int min = int.MaxValue;
                            while (stack.Count > 0)
                            {
                                if (min > stack.Peek())
                                {
                                    min = stack.Peek();
                                }
                                tmpStack.Push(stack.Pop());
                            }
                            while (tmpStack.Count > 0)
                            {
                                stack.Push(tmpStack.Pop());
                            }
                            Console.WriteLine(min);
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}

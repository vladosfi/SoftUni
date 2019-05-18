using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (char bracket in input)
            {
                if (bracket == '{' || bracket == '(' || bracket == '[')
                {
                    stack.Push(bracket);
                }
                else if ((bracket == ')' || bracket == '}' || bracket == ']') && 
                    stack.Count > 0)
                {
                    if (stack.Peek() == '(' && bracket == ')' || 
                        stack.Peek() == '{' && bracket == '}' || 
                        stack.Peek() == '[' && bracket == ']')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main()
        {
            string input = Console.ReadLine();
            bool balanced = true;
            Stack<char> parenthesis = new Stack<char>();
            char[] opening = new char[] { '{', '[', '(' };

            foreach (var paranthes in input)
            {
                if (opening.Contains(paranthes))
                {
                    parenthesis.Push(paranthes);
                }
                else
                {
                    if (parenthesis.Count > 0 &&
                        (paranthes == '}' && parenthesis.Peek() == '{' ||
                        paranthes == ']' && parenthesis.Peek() == '[' ||
                        paranthes == ')' && parenthesis.Peek() == '('))
                    {
                        parenthesis.Pop();
                    }
                    else
                    {
                        balanced = false;
                        break;
                    }
                }
            }
            if (balanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

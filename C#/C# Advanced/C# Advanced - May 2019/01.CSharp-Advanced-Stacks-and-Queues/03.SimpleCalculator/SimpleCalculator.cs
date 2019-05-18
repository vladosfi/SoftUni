using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main()
        {
            string[] expression = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(expression.Reverse());

            while (stack.Count > 1)
            {
                int operandOne = int.Parse(stack.Pop());
                char opr = char.Parse(stack.Pop());
                int operandTwo = int.Parse(stack.Pop());
                
                switch (opr)
                {
                    case '+':
                        stack.Push($"{operandOne + operandTwo}");
                        break;
                    case '-':
                        stack.Push($"{operandOne - operandTwo}");
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(stack.Peek());
        }
    }
}

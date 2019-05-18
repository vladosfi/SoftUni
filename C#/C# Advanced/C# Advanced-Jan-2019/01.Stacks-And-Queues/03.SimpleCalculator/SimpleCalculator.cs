using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            Stack<string> expression = new Stack<string>(numbers.Reverse());

            int sum = int.Parse(expression.Pop());

            while (expression.Any())
            {
                string nextSymbol = expression.Pop();

                if (nextSymbol == "+")
                {
                    sum += int.Parse(expression.Pop());
                }
                else if (nextSymbol == "-")
                {
                    sum -= int.Parse(expression.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}

using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class ReverseStrings
    {
        static void Main()
        {
            Stack<char> text = new Stack<char>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                text.Push(input[i]);
            }

            while (text.Count != 0)
            {
                Console.Write(text.Pop());
            }
            Console.WriteLine();
        }
    }
}

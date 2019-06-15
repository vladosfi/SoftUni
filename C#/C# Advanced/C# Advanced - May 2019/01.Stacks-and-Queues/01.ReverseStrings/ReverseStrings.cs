using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class ReverseStrings
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> revercedString = new Stack<char>();

            foreach (var ch in input)
            {
                revercedString.Push(ch);
            }

            foreach (var ch in revercedString)
            {
                Console.Write(ch);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    class Socks
    {
        static void Main()
        {
            int[] inputSocks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> leftSocks = new Stack<int>(inputSocks);

            inputSocks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> rightSocks = new Queue<int>(inputSocks);

            List<int> pairs = new List<int>();

            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                int leftSock = leftSocks.Peek();
                int rightSock = rightSocks.Peek();

                if (leftSock > rightSock)
                {
                    pairs.Add(leftSocks.Pop() + rightSocks.Dequeue());
                }
                else if (leftSock < rightSock)
                {
                    leftSocks.Pop();
                }
                else
                {
                    rightSocks.Dequeue();
                    leftSocks.Push(leftSocks.Pop() + 1);
                }
            }


            Console.WriteLine(pairs.Max());

            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}

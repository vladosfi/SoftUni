using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class PrintEvenNumbers
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(nums);
            Queue<int> evensQueue = new Queue<int>();


            while (queue.Any())
            {
                if (queue.Peek() % 2 == 0)
                {
                    evensQueue.Enqueue(queue.Dequeue());
                }
                else
                {
                    queue.Dequeue();
                }
            }

            while (evensQueue.Any())
            {
                Console.Write(evensQueue.Dequeue());
                if (evensQueue.Any())
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}

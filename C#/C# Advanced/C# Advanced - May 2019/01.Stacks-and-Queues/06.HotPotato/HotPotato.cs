using System;
using System.Collections.Generic;

namespace _06.HotPotato
{
    class HotPotato
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(input);

            while (queue.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is { queue.Peek()}");
        }
    }
}

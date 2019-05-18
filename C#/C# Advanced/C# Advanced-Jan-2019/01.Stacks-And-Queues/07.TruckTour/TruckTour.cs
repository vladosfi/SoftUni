using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();


            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(tokens[0] - tokens[1]);
            }

            int index = 0;

            while (true)
            {
                Queue<int> copyQueue = new Queue<int>(queue);
                int fuel = -1;

                while (copyQueue.Any())
                {
                    if (copyQueue.Peek() > 0 && fuel == -1)
                    {
                        fuel = copyQueue.Dequeue();
                        queue.Enqueue(queue.Dequeue());
                    }
                    else if (copyQueue.Peek() < 0 && fuel == -1)
                    {
                        copyQueue.Enqueue(copyQueue.Dequeue());
                        queue.Enqueue(queue.Dequeue());
                        index++;
                    }
                    else
                    {
                        fuel += copyQueue.Dequeue();

                        if (fuel < 0)
                        {
                            break;
                        }
                    }
                }

                if (fuel >= 0)
                {
                    Console.WriteLine(index);
                    return;
                }
                index++;
            }
        }
    }
}

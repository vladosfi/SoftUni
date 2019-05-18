using System;
using System.Collections.Generic;

namespace _07.TrafficJam
{
    class TrafficJam
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int count = 0;
            Queue<string> queue = new Queue<string>();

            while (input.ToLower() != "end")
            {
                if (input.ToLower() == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}

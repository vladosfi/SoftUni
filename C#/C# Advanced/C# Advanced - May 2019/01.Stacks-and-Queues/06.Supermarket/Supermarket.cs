using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Supermarket
    {
        static void Main()
        {
            Queue<string> queue = new Queue<string>();
            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                if (input.ToLower() == "paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}

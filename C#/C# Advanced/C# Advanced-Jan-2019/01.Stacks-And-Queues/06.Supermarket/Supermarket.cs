using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Supermarket
{
    class Supermarket
    {
        static void Main()
        {
            Queue<string> marketQueue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    break;
                }

                if (input.ToLower() == "paid")
                {
                    while (marketQueue.Any())
                    {
                        Console.WriteLine(marketQueue.Dequeue());
                    }
                }
                else
                {
                    marketQueue.Enqueue(input);
                }
            }

            Console.WriteLine($"{marketQueue.Count} people remaining.");
        }
    }
}

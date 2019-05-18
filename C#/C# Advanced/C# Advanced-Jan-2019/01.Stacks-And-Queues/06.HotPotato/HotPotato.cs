using System;
using System.Collections.Generic;

namespace _06.HotPotato
{
    class HotPotato
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Queue<string> childrens = new Queue<string>(input);
            int n = int.Parse(Console.ReadLine());
            int counter = 1;

            while (childrens.Count != 1)
            {
                if (counter % n == 0)
                {
                    Console.WriteLine($"Removed {childrens.Dequeue()}");
                }
                else
                {
                    string child = childrens.Dequeue();
                    childrens.Enqueue(child);
                }
                counter++;
            }

            Console.WriteLine($"Last is {childrens.Dequeue()}");
        }
    }
}

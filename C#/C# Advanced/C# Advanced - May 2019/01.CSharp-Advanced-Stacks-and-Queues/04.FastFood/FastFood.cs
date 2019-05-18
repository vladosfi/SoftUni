using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class FastFood
    {
        static void Main()
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(input);
            int biggestOrder = 0;

            while (orders.Count > 0 && quantityOfFood > 0)
            {
                if (biggestOrder < orders.Peek())
                {
                    biggestOrder = orders.Peek();
                }
                quantityOfFood -= orders.Peek();
                if (quantityOfFood < 0)
                {
                    break;
                }
                orders.Dequeue();
            }

            Console.WriteLine(biggestOrder);

            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}

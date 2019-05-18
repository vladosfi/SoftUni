using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class FastFood
    {
        static void Main()
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(input);
            
            if (orders.Any())
            {
                Console.WriteLine(orders.Max());
            }

            while (orders.Any())
            {
                if (quantityFood >= orders.Peek())
                {
                    quantityFood -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Any())
            {
                Console.WriteLine("Orders left: " + string.Join(" ", orders));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class KeyRevolver
    {
        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsSize);
            Queue<int> locks = new Queue<int>(locksSize);
            int barrelCount = 0;

            while (bullets.Any() && locks.Any())
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bullets.Pop();
                barrelCount++;

                if (barrelCount % barrelSize == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int bulletCoast = barrelCount * bulletPrice;
                int earned = intelligence - bulletCoast;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
            }
        }
    }
}

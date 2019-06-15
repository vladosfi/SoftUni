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
            int[] inputBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(inputBullets);
            int[] inputLocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(inputLocks);
            int valueOfTheIntelligence = int.Parse(Console.ReadLine());
            int shots = 0;

            while (locks.Count > 0 && bullets.Count > 0)
            {
                int currentLock = locks.Peek();
                int currentBullet = bullets.Pop();
                shots++;

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (shots % barrelSize == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            int moneyEarned = valueOfTheIntelligence - bulletPrice * shots;

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            
        }
    }
}

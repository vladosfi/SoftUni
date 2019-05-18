using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main()
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] filledBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacity);
            Stack<int> bottles = new Stack<int>(filledBottles);
            int wastedWater = 0;

            int currentCup = 0;
            int currentBottle = 0;

            while (bottles.Any() && cups.Any())
            {
                if (currentCup == 0)
                {
                    currentCup = cups.Peek();
                }
                
                currentBottle = bottles.Peek();
                
                currentBottle -= currentCup;
                
                if (currentBottle >= 0)
                {
                    wastedWater += currentBottle;
                    cups.Dequeue();
                    bottles.Pop();
                    currentCup = 0;
                }
                else if(currentBottle < 0)
                {
                    currentCup = Math.Abs(currentBottle);
                    bottles.Pop();
                }
            }

            if (!cups.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}

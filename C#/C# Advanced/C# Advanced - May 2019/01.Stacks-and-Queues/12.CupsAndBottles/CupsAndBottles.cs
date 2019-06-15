using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main()
        {
            int[] inputCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(inputCups);
            int[] inputBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(inputBottles);
            int wastedLitters = 0;
            int prevCup = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currenCup = cups.Peek() ;
                int currentBottle = bottles.Pop();

                if (prevCup != 0)
                {
                    currenCup = prevCup;
                    prevCup = 0;
                }

                if (currenCup > currentBottle)
                {
                    prevCup = currenCup - currentBottle;    
                }
                else
                {
                    cups.Dequeue();
                    wastedLitters += currentBottle - currenCup;
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}

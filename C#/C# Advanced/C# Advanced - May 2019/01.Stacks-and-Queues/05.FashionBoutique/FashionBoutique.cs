using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class FashionBoutique
    {
        static void Main()
        {
            int racksCount = 1;
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(input);
            int sumOfClotesInRack = 0;

            while (clothes.Count > 0)
            {
                int valueOfClote = clothes.Peek();

                if (sumOfClotesInRack + valueOfClote <= rackCapacity)
                {
                    sumOfClotesInRack += valueOfClote;
                    clothes.Pop();
                }
                else
                {
                    sumOfClotesInRack = 0;
                    racksCount++;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}

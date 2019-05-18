using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class FashionBoutique
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clotes = new Stack<int>(input);
            Stack<int> rack = new Stack<int>();
            int rackCapacity = int.Parse(Console.ReadLine());

            while (clotes.Any())
            {
                if (rack.Any())
                {
                    int currentRackValue = rack.Peek();
                    int clotesValue = clotes.Pop();

                    if (rackCapacity - currentRackValue >= clotesValue)
                    {
                        rack.Pop();
                        rack.Push(currentRackValue + clotesValue);
                    }
                    else
                    {
                        rack.Push(clotesValue);
                    }
                }
                else
                {
                    rack.Push(clotes.Pop());
                }
            }

            if (rack.Any())
            {
                Console.WriteLine(rack.Count());
            }
            else
            {
                Console.WriteLine(0);
            }
            
        }
    }
}

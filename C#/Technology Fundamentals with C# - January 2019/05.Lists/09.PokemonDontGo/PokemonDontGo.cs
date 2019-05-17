using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDontGo
{
    class PokemonDontGo
    {
        static void Main()
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            long sum = 0;

            while (true)
            {
                if (sequence.Count <= 0)
                {
                    break;
                }

                int index = int.Parse(Console.ReadLine());

                int elementToRemove = 0;

                if (index < 0)
                {
                    elementToRemove = sequence[0];
                    sequence.RemoveAt(0);
                    sequence.Insert(0, sequence[sequence.Count - 1]);
                }
                else if (index >= sequence.Count)
                {
                    elementToRemove = sequence[sequence.Count - 1];
                    sequence.RemoveAt(sequence.Count - 1);
                    //sequence.Insert(sequence.Count, sequence[0]);
                    sequence.Add(sequence[0]);
                }
                else
                {
                    elementToRemove = sequence[index];
                    sequence.RemoveAt(index);
                }
                sum += elementToRemove;

                IncreaceOrDecreaceElements(elementToRemove, sequence);
            }

            Console.WriteLine(sum);
        }

        private static void IncreaceOrDecreaceElements(int elementToRemove, List<int> sequence)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] > elementToRemove)
                {
                    sequence[i] -= elementToRemove;
                }
                else
                {
                    sequence[i] += elementToRemove;
                }
            }
        }
    }
}

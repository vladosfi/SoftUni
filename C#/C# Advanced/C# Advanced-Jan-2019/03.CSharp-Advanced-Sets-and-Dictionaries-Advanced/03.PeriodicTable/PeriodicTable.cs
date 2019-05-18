using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class PeriodicTable
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> compounds = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split();

                foreach (var element in elements)
                {
                    compounds.Add(element);
                }
                
            }

            Console.WriteLine(string.Join(" " , compounds));
        }
    }
}

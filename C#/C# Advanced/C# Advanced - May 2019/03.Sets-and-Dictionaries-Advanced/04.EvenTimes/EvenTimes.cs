using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class EvenTimes
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, bool>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, true);
                }

                numbers[number] = !numbers[number];
            }

            foreach (var even in numbers.Where(x=>x.Value == true))
            {
                Console.WriteLine(even.Key);
            }
        }
    }
}

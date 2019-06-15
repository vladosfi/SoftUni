using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Supermarket
{
    class Supermarket
    {
        static void Main()
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();
            Queue<int> evenNumbers = new Queue<int>();

            foreach (var number in sequence)
            {
                numbers.Enqueue(number);
            }


            while (numbers.Any())
            {
                if (numbers.Peek() % 2 == 0)
                {
                    evenNumbers.Enqueue(numbers.Peek());
                }
                numbers.Dequeue();
            }

            Console.WriteLine(string.Join(", ", evenNumbers));

        }
    }
}

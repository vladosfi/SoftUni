using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class MaximumAndMinimumElement
    {
        static void Main()
        {
            Stack<int> numbers = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int query = tokens[0];

                switch (query)
                {
                    case 1:
                        numbers.Push(tokens[1]);
                        break;
                    case 2:
                        if (numbers.Any())
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                    case 4:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;
                    default:
                        break;
                }
            }
            if (numbers.Any())
            {
                Console.WriteLine(string.Join(", ", numbers));
            }
        }
    }
}

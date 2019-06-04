using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            Predicate<int> isEven = number 
                => number % 2 == 0;

            Predicate<int> isOdd = number 
                => number % 2 != 0;

            Action<List<int>> print = x 
                => Console.WriteLine(string.Join(" ",x)); 
            
            int[] bounds = Console.ReadLine() 
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            List<int> numbers = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                numbers.Add(i);
            }

            if (command == "odd")
            {
                numbers = numbers.Where(n => isOdd(n)).ToList();
            }
            else
            {
                numbers = numbers.Where(n => isEven(n)).ToList();
            }

            print(numbers);
        }
    }
}

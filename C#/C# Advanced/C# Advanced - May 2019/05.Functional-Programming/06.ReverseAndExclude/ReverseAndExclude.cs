using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            Func<int,int,bool> RemoveDivisible = (n,m) => n % m != 0;

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int number = int.Parse(Console.ReadLine());

            numbers = numbers.Where(x => RemoveDivisible(x, number)).Reverse().ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }

    }
}


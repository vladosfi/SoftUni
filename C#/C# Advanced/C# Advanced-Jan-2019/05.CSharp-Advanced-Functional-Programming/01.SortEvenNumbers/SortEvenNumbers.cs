using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class SortEvenNumbers
    {
        static void Main()
        { 
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
} 

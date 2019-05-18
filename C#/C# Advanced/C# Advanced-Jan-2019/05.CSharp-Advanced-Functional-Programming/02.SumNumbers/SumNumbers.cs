using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SumNumbers
{
    class SumNumbers
    {
        static void Main()
        {
            Func<string, int> parser = n => int.Parse(n);

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
            
        }


    }
}

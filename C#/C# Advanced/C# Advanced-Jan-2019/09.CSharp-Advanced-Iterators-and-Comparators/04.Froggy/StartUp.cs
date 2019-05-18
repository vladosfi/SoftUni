using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    class StartUp
    {
        static void Main()
        {
            List<int> input = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Lake lakePath = new Lake(input);

            Console.WriteLine(string.Join(", ", lakePath));
        }
    }
}

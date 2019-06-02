using System;
using System.Linq;

namespace _01.ActionPoint
{
    class ActionPoint
    {
        static void Main()
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

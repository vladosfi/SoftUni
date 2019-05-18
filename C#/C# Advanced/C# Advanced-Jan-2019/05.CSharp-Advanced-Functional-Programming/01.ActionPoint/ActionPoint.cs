using System;
using System.Linq;

namespace _01.ActionPoint
{
    class ActionPoint
    {
        static void Main()
        {
            Func<string, string> selectName = n => n;

            Console.ReadLine()
                .Split()
                .Select(selectName)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

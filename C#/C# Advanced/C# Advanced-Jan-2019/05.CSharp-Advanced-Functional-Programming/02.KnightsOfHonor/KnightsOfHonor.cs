using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main()
        {
            Action<string> printString = p => Console.WriteLine("Sir " + p);

            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printString);

        }
    }
}

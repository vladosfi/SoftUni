using System;
using System.Linq;

namespace _05.SumEvenNumbers
{
    class SumEvenNumbers
    {
        static void Main()
        {
            Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Where(x => x % 2 == 0).Sum());
        }
    }
}

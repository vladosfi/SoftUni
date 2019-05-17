using System;
using System.Numerics;

namespace _03.BigFactorial
{
    class BigFactorial
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger fact = n;

            for (int i = n-1; i > 1; i--)
            {
                fact *= i;
            }

            Console.WriteLine(fact);
        }
    }
}

using System;
using System.Threading;

namespace _08.FactorialDivision
{
    class FactorialDivision
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            Console.WriteLine($"{GetFactorial(first) / GetFactorial(second):f02}");
        }

        private static decimal GetFactorial(int n)
        {
            decimal fact = 1;

            for (int i = 2; i <= n; i++)
            {
                fact = fact * i;
            }

            return fact;
        }
    }
}

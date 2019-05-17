using System;

namespace _01.GreatestCommonDivisor_CGD_
{
    class GreatestCommonDivisor
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int min = a;
            int remainder = 0;

            if (min > b)
            {
                a = b;
                b = min;
            }

            do
            {
                remainder = a % b;
                a = b;
                b = remainder;
            } while (remainder != 0);

            Console.WriteLine(a);
        }
    }
}

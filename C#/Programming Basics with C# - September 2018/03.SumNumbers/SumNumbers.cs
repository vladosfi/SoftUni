using System;

namespace _03.SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum = sum + long.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}

using System;

namespace _09.SumOfOddNumbers
{
    class SumOfOddNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sumOfOdds = 0;

            for (int i = 1; i <= 100; i+=2)
            {
                if (n < 1)
                {
                    break;
                }
                n--;
                Console.WriteLine(i);
                sumOfOdds += i;
            }

            Console.WriteLine($"Sum: {sumOfOdds}");

        }
    }
}

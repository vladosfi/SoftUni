using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class EvenAndOddSubtraction
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumOfEvens = 0;
            int sumOfOdds = 0;

            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    sumOfEvens += num;
                }
                else
                {
                    sumOfOdds += num;
                }
            }

            int difference = sumOfEvens - sumOfOdds;

            Console.WriteLine(difference);
        }
    }
}

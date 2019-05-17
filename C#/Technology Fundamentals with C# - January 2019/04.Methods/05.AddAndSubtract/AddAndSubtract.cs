using System;

namespace _05.AddAndSubtract
{
    class AddAndSubtract
    {
        static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine(Subtract(third, Sum(first, second)));

        }

        private static long Subtract(int third, long sum)
        {
            return sum - third;
        }

        private static long Sum(int first, int second)
        {
            return first + second;
        }
    }
}

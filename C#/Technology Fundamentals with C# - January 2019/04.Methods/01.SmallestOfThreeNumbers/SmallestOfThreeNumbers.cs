using System;

namespace _01.SmallestOfThreeNumbers
{
    class SmallestOfThreeNumbers
    {
        static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine(FindSmallestNumber(first, second, third));
        }

        private static int FindSmallestNumber(int first, int second, int third)
        {
            int min = first;

            if (second <= min && second <= third)
            {
                min = second;
            }
            else if (third <= second && third <= first)
            {
                min = third;
            }

            return min;
        }
    }
}

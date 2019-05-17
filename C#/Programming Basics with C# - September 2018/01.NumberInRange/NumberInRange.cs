using System;

namespace _01.NumberInRange
{
    class NumberInRange
    {
        static void Main(string[] args)
        {
            int n = 0;

            Console.Write("Enter a number in the range[1...100]: ");
            n = int.Parse(Console.ReadLine());

            while (n<1 || n > 100)
            {
                Console.Write("Enter a number in the range[1...100]: ");
                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {n}");

        }
    }
}

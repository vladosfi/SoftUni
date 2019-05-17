using System;

namespace _06.DivideWithoutRemainder
{
    class DivideWithoutRemainder
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            int number;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    p1++;
                }
                if (number % 3 == 0)
                {
                    p2++;
                }
                if (number % 4 == 0)
                {
                    p3++;
                }
            }

            Console.WriteLine($"{p1 / n * 100:f02}%");
            Console.WriteLine($"{p2 / n * 100:f02}%");
            Console.WriteLine($"{p3 / n * 100:f02}%");
        }
    }
}

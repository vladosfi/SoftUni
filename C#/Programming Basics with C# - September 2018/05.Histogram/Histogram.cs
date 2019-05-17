using System;

namespace _05.Histogram
{
    class Histogram
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            int number;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    p1++;
                }
                else if (number < 400)
                {
                    p2++;
                }
                else if (number < 600)
                {
                    p3++;
                }
                else if (number < 800)
                {
                    p4++;
                }
                else if (number <= 1000)
                {
                    p5++;
                }
            }

            Console.WriteLine($"{p1 / n * 100:f02}%");
            Console.WriteLine($"{p2 / n * 100:f02}%");
            Console.WriteLine($"{p3 / n * 100:f02}%");
            Console.WriteLine($"{p4 / n * 100:f02}%");
            Console.WriteLine($"{p5 / n * 100:f02}%");
        }
    }
}

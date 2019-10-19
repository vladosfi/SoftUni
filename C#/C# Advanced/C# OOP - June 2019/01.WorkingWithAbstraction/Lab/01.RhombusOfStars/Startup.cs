using System;

namespace _01.RhombusOfStars
{
    class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintRow(n - i, i);
            }

            for (int i = n - 1; i > 0; i--)
            {
                PrintRow(n - i, i);
            }
        }

        public static void PrintRow(int spaces, int starsCount)
        {
            Console.Write(new string(' ', spaces));

            for (int i = 0; i < starsCount; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
            
        }
    }
}

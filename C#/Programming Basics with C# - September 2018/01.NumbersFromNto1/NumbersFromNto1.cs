using System;

namespace _01.NumbersFromNto1
{
    class NumbersFromNto1
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = n; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}

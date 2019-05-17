using System;

namespace _5.AriaOfTrapeze
{
    class AriaOfTrapeze
    {
        static void Main()
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double aria = (b1 + b2) * h / 2;

            Console.WriteLine(aria);
        }
    }
}

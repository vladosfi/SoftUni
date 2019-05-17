using System;

namespace _7.AriaOfTriangle
{
    class AriaOfTriangle
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double aria = Math.Round(a * h / 2, 2);

            Console.WriteLine($"Triangle aria = {aria}");

        }
    }
}

using System;

namespace _6.PerimeterAndAriaOfCircle
{
    class PerimeterAndAriaOfCircle
    {
        static void Main()
        {
            double radius = double.Parse(Console.ReadLine());
            double aria = Math.PI * radius * radius;
            double perimeter = 2 * Math.PI * radius;

            Console.WriteLine($"Aria = {aria}");
            Console.WriteLine($"Perimeter = {perimeter}");
        }
    }
}


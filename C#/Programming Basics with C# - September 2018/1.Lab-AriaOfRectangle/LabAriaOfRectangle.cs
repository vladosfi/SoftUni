using System;

namespace _1.Lab_AriaOfRectangle
{
    class LabAriaOfRectangle
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double sideA = Math.Abs(y1 - y2);
            double sideB = Math.Abs(x1 - x2);
            double aria = sideA * sideB;
            double perimeter = 2 * (sideA + sideB);

            Console.WriteLine($"{aria}");
            Console.WriteLine($"{perimeter}");

        }
    }
}

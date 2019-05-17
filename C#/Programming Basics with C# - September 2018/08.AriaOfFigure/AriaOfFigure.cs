using System;

namespace _08.AriaOfFigure
{
    class AriaOfFigure
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double aria = 0;

            if (figure == "square")
            {
                aria = AriaOfSquare();
            }
            else if (figure == "rectangle")
            {
                aria = AriaOfRectangle();
            }
            else if (figure == "circle")
            {
                aria = AriaOfCircle();
            }
            else if (figure == "triangle")
            {
                aria = AriaOfTriangle();
            }
            else
            {
                Console.WriteLine("Incorrect figure");
            }
            Console.WriteLine($"{aria:.###}");
        }

        static double AriaOfSquare()
        {
            double side = double.Parse(Console.ReadLine());
            return (side * side);
        }
        static double AriaOfRectangle()
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            return (sideA * sideB);
        }
        static double AriaOfCircle()
        {
            double radius = double.Parse(Console.ReadLine());
            return (Math.PI*(radius * radius));
        }
        static double AriaOfTriangle()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            return ((side * height)/2);
        }
    }
}

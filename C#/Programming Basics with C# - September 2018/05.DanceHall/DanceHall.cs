using System;

namespace _05.DanceHall
{
    class DanceHall
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());

            // Hall space in santimeters
            double hall = (lenght * 100 * width * 100);
            double wardrobe = (a * 100 * a * 100);
            double bench = hall / 10;

            // Hall free space in santimeters
            hall = hall - wardrobe - bench;

            // Person free space needed
            double personSpace = 40 + 7000;

            Console.WriteLine(Math.Floor(hall / personSpace));

        }
    }
}

using System;

namespace _02.Spaceship
{
    class Spaceship
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double avgHeight = double.Parse(Console.ReadLine());
            avgHeight = avgHeight + 0.40;
            double capacityOfSpaceShip = width * lenght * height;
            double roomSpace = 2 * 2 * avgHeight;
            double rooms = Math.Floor(capacityOfSpaceShip / roomSpace);

            if (rooms >= 3 && rooms <= 10)
            {
                Console.WriteLine($"The spacecraft holds {rooms} astronauts.");
            }

            else if (rooms < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }

            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}

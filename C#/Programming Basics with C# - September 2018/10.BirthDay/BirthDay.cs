using System;

namespace _10.BirthDay
{
    class BirthDay
    {
        static void Main()
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            //Obem na akvariuma v kubichni decimetri
            double volume = width * height * lenght;
            double liters = volume / 1000;

            percent = (percent * liters) / 100;
            liters = liters - percent;
            Console.WriteLine($"{liters:F03}");

        }
    }
}

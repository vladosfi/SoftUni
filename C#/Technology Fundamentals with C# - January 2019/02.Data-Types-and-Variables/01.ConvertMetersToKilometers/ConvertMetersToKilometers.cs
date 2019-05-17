using System;

namespace _01.ConvertMetersToKilometers
{
    class ConvertMetersToKilometers
    {
        static void Main()
        {
            int meters = int.Parse(Console.ReadLine());
            double km = (double)meters / 1000;

            Console.WriteLine($"{km:F02}");
        }
    }
}

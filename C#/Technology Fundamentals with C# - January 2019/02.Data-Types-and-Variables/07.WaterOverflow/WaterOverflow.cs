using System;

namespace _07.WaterOverflow
{
    class WaterOverflow
    {
        static void Main()
        {
            int capacity = 255;
            int n = int.Parse(Console.ReadLine());
            int tank = 0;

            for (int i = 0; i < n; i++)
            {
                int litersOfWaterToPour = int.Parse(Console.ReadLine());

                if (tank + litersOfWaterToPour <= capacity)
                {
                    tank += litersOfWaterToPour;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(tank);
        }
    }
}

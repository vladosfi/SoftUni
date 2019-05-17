using System;

namespace _09.WorldSwimmingRecord
{
    class WorldSwimmingRecord
    {
        static void Main(string[] args)
        {
            double recordTime = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double metersInSec = double.Parse(Console.ReadLine());
            double lag = 0;
            double timeIvan = distance * metersInSec;
            
            if (distance >= 15)
            {
                lag = Math.Floor(distance / 15);
                lag = lag * 12.5;
            }

            timeIvan = timeIvan + lag;

            if (recordTime > timeIvan)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeIvan:F02} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(timeIvan - recordTime):F02} seconds slower.");
            }

        }
    }
}

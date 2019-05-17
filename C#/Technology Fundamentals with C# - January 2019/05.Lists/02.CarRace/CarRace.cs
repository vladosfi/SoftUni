using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _02.CarRace
{
    class CarRace
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            double leftCar = 0;
            double rightCar = 0;

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                leftCar += numbers[i];
                if (numbers[i] == 0)
                {
                    leftCar -= leftCar * 0.2;
                }
                rightCar += numbers[numbers.Count - 1 - i];
                if (numbers[numbers.Count - 1 - i] == 0)
                {
                    rightCar -= rightCar * 0.2;
                }
            }

            if (leftCar <= rightCar)
            {
                Console.WriteLine($"The winner is left with total time: {leftCar}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightCar}");
            }
            
        }
    }
}

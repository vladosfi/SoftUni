using System;
using System.Collections.Generic;

namespace _07.TrafficJam
{
    class TrafficJam
    {
        static void Main()
        {
            int carsToPass = int.Parse(Console.ReadLine());
            Queue<string> carList = new Queue<string>();
            int passedCars = 0;

            while (true)
            {
                string token = Console.ReadLine();

                if (token.ToLower() == "end")
                {
                    break;
                }

                if (token.ToLower() == "green")
                {
                    int carsToPassCount = Math.Min(carList.Count, carsToPass);

                    for (int i = 0; i < carsToPassCount; i++)
                    {
                        Console.WriteLine($"{carList.Dequeue()} passed!");
                        passedCars++;
                    }
                }
                else
                {
                    carList.Enqueue(token);
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}

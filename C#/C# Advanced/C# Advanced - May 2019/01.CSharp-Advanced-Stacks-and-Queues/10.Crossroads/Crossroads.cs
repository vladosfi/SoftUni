using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string input = Console.ReadLine();
            int totalCarsPassed = 0;

            while (input.ToLower() != "end")
            {
                if (input.ToLower() == "green")
                {
                    int curTime = greenLight;
                    string curCar;
                    string carInCrossroad = string.Empty;

                    while (curTime > 0 && cars.Count > 0)
                    {
                        curCar = cars.Dequeue();
                        totalCarsPassed++;

                        if (curCar.Length <= curTime)
                        {
                            curTime -= curCar.Length;
                        }
                        else
                        {
                            carInCrossroad = curCar.Substring(curTime, curCar.Length - curTime);
                            curTime = 0;

                            if (freeWindow < carInCrossroad.Length)
                            {
                                char hitPlace = carInCrossroad[freeWindow];
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{curCar} was hit at {hitPlace}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}

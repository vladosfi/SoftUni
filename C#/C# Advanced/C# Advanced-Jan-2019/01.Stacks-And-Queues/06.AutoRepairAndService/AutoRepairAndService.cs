using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.AutoRepairAndService
{
    class AutoRepairAndService
    {
        static void Main()
        {
            string[] cars = Console.ReadLine().Split();
            Queue<string> carQueue = new Queue<string>(cars);
            Stack<string> servedCars = new Stack<string>();
            
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    break;
                }

                string[] tokens = input.Split("-");

                string command = tokens[0];

                switch (command)
                {
                    case "Service":
                        if (carQueue.Any())
                        {
                            servedCars.Push(carQueue.Peek());
                            Console.WriteLine($"Vehicle {carQueue.Dequeue()} got served.");
                        }
                        break;
                    case "CarInfo":
                        string vehicleName = tokens[1];
                        if (carQueue.Any() && carQueue.Contains(vehicleName))
                        {
                            Console.WriteLine("Still waiting for service.");
                        }
                        else
                        {
                            Console.WriteLine("Served.");
                        }
                        break;
                    case "History":
                        Queue<string> tmpCarHistory = new Queue<string>(servedCars);
                        Console.WriteLine(string.Join(", ", tmpCarHistory));
                        break;
                    default:
                        break;
                }
            }

            if (carQueue.Any())
            {
                Console.WriteLine("Vehicles for service: " + string.Join(", ", carQueue));
            }
            if (servedCars.Any())
            {
                Console.WriteLine("Served vehicles: " + string.Join(", ", servedCars));
            }
            
        }
    }
}

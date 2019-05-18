using System;
using System.Collections.Generic;

namespace _06.AutoRepairAndService
{
    class AutoRepairAndService
    {
        static void Main()
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> cars = new Queue<string>(data);
            Stack<string> carHistory = new Stack<string>();

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                if (command.ToLower() == "service")
                {
                    if (cars.Count > 0)
                    {
                        string vehicleName = cars.Dequeue();
                        carHistory.Push(vehicleName);
                        Console.WriteLine($"Vehicle {vehicleName} got served.");
                    }
                }
                else if (command.ToLower().Contains("carinfo"))
                {
                    string[] tokens = command.Split("-");
                    if (cars.Contains(tokens[1]))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (command.ToLower() == "history")
                {
                    if (carHistory.Count > 0)
                    {
                        Console.WriteLine(string.Join(", ", carHistory));
                    }
                }

                command = Console.ReadLine();
            }

            if (cars.Count > 0)
            {
                Console.WriteLine("Vehicles for service: " + string.Join(", ", cars));
            }

            if (carHistory.Count > 0)
            {
                Console.WriteLine("Served vehicles: " + string.Join(", ", carHistory));
            }
        }
    }
}

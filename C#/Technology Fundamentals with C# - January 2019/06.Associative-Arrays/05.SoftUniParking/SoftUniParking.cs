using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class SoftUniParking
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingPlaces = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string userName = tokens[1];

                if (command == "register")
                {
                    if (parkingPlaces.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingPlaces[userName]}");
                    }
                    else
                    {
                        string licensePlateNumber = tokens[2];
                        parkingPlaces.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (!parkingPlaces.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        parkingPlaces.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }
            }


            foreach (var kvp in parkingPlaces)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}

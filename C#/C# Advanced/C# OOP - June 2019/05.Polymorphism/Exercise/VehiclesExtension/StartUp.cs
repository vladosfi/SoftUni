using System;
using System.Collections.Generic;
using System.Threading;

namespace Polymorphism
{
    public class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string command = tokens[0];
                string type = tokens[1];

                try
                {
                    if (command == "Drive")
                    {
                        double distance = double.Parse(tokens[2]);

                        if (type == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (type == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (type == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        double liters = double.Parse(tokens[2]);

                        if (type == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else if (type == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        double liters = double.Parse(tokens[2]);

                        if (type == "Bus")
                        {
                            if (bus is Bus curBus)
                            {
                                Console.WriteLine(curBus.DriveEmpty(liters));
                            }
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            List<Vehicle> vehicles = new List<Vehicle>() { car, truck, bus };

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private static Vehicle CreateVehicle()
        {
            string[] vehicleInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double consumption = double.Parse(vehicleInfo[2]);
            double tankCapacity = double.Parse(vehicleInfo[3]);
            string vehicleType = vehicleInfo[0];

            Vehicle vehicle = null;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, consumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, consumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, consumption, tankCapacity);
            }

            return vehicle;
        }
    }
}

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

            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);

            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);

            Vehicle car = new Car(carFuelQuantity, carConsumption);
            Vehicle truck = new Truck(truckFuelQuantity, truckConsumption);

            List<Vehicle> vehicles = new List<Vehicle>() { car, truck };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string command = tokens[0];
                string type = tokens[1];

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
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}

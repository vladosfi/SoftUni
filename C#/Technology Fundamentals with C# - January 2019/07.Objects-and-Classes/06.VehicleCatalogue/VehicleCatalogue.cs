using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _06.VehicleCatalogue
{
    class Vehicle
    {
        string type;
        string model;
        string color;
        int horsePower;

        public Vehicle(string type, string model, string color, int horsePower)
        {
            this.type = type;
            this.model = model;
            this.color = color;
            this.horsePower = horsePower;
        }

        public string Type => this.type;
        public string Model => this.model;
        public string Color => this.color;
        public int HorsePower => this.horsePower;
    }
    class VehicleCatalogue
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<Vehicle> vehicleList = new List<Vehicle>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    break;
                }

                string[] tokens = command.Split();
                string type = UppercaseFirst(tokens[0]);
                string model = tokens[1];
                string color = tokens[2];
                int horsePower = int.Parse(tokens[3]);

                Vehicle vehicle = new Vehicle(
                    type, 
                    model, 
                    color, 
                    horsePower
                    );

                vehicleList.Add(vehicle);
            }


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Close the Catalogue")
                {
                    break;
                }
                int index = vehicleList.FindIndex(x => x.Model == command);

                if (index >=0)
                {
                    Console.WriteLine($"Type: {vehicleList[index].Type}");
                    Console.WriteLine($"Model: {vehicleList[index].Model}");
                    Console.WriteLine($"Color: {vehicleList[index].Color}");
                    Console.WriteLine($"Horsepower: {vehicleList[index].HorsePower}");
                }
            }

            double averageHorsePower = 0;

            if (vehicleList.Any(x=>x.Type == "Car"))
            {
                averageHorsePower = vehicleList
                .Where(x => x.Type == "Car")
                .Average(x => x.HorsePower);

                Console.WriteLine($"Cars have average horsepower of: {averageHorsePower:f02}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f02}.");
            }

            if (vehicleList.Any(x => x.Type == "Truck"))
            {
                averageHorsePower = vehicleList
                .Where(x => x.Type == "Truck")
                .Average(x => x.HorsePower);

                Console.WriteLine($"Trucks have average horsepower of: {averageHorsePower:f02}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f02}.");
            }
        }


        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string carModel = inputData[0];
                double fuelAmount = double.Parse(inputData[1]);
                double fuelConsumptionFor1km = double.Parse(inputData[2]);

                Car newCar = new Car(fuelAmount, fuelConsumptionFor1km);




                cars.Add(carModel, newCar);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] != "Drive")
                {
                    input = Console.ReadLine();
                    continue;
                }

                string model = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                try
                {
                    cars[model].Drive(amountOfKm);
                }
                catch (ArgumentException message)
                {
                    Console.WriteLine(message.Message);
                }


                input = Console.ReadLine();
            }


            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f02} {car.Value.TravelledDistance}");
            }
        }
    }
}

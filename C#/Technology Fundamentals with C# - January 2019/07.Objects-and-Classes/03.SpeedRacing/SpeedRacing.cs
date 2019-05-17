using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace _03.SpeedRacing
{
    class Car
    {
        string model;
        double fuelAmount;
        double fuelConsumptionPerKilometer;
        double traveledDistance = 0;

        public Car(
            string model,
            double fuelAmount,
            double fuelConsumptionPerKilometer
            )
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model => this.model;
        public double FuelAmount => this.fuelAmount;
        public double FuelConsumptionPerKilometer => this.fuelConsumptionPerKilometer;
        public double TraveledDistance => this.traveledDistance;

        public bool IsCarCanMoveDistance(double amountOfKm)
        {
            if (amountOfKm <= FuelAmount / this.fuelConsumptionPerKilometer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ReduceAmountOfFuel(double amountOfKm)
        {
            this.fuelAmount -= amountOfKm * this.fuelConsumptionPerKilometer;
        }

        public void IncreaseTraveledDistance(double amountOfKm)
        {
            this.traveledDistance += amountOfKm;
        }
    }
    class SpeedRacing
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<Car> carList = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionPerKilometer = double.Parse(tokens[2]);

                Car curCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

                carList.Add(curCar);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    break;
                }

                string[] tokens = command.Split();

                if (tokens[0] == "Drive")
                {
                    string model = tokens[1];
                    double distanceToTravel = double.Parse(tokens[2]);
                    int indexOfCar = carList.FindIndex(x => x.Model == model);

                    if (!carList[indexOfCar].IsCarCanMoveDistance(distanceToTravel))
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                    else
                    {
                        carList[indexOfCar].ReduceAmountOfFuel(distanceToTravel);
                        carList[indexOfCar].IncreaseTraveledDistance(distanceToTravel);
                    }
                }
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model} { car.FuelAmount:f02} { car.TraveledDistance}");
            }


        }
    }
}

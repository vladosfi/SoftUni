using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _08.RawData
{
    class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                double tire1Pressure = double.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);
                double tire2Pressure = double.Parse(tokens[7]);
                int tire2Age = int.Parse(tokens[8]);
                double tire3Pressure = double.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);
                double tire4Pressure = double.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4]
                {
                    new Tire(tire1Pressure,tire1Age),
                    new Tire(tire2Pressure,tire2Age),
                    new Tire(tire3Pressure,tire3Age),
                    new Tire(tire4Pressure,tire4Age)
                };

                Car newCar = new Car(model, engine, cargo, tires);

                cars.Add(newCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(x=>x.Cargo.Type == command
                && x.Tires.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == command 
                && x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
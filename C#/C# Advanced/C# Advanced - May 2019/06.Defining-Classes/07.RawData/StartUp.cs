using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

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

                Car newCar = new Car(
                    model,
                    engineSpeed,
                    enginePower,
                    cargoWeight,
                    cargoType,
                    tire1Pressure,
                    tire1Age,
                    tire2Pressure,
                    tire2Age,
                    tire3Pressure,
                    tire3Age,
                    tire4Pressure,
                    tire4Age);

                cars.Add(newCar);

            }

            string filter = Console.ReadLine();

            List<Car> filtredCars;

            if (filter == "fragile")
            {
                filtredCars = cars
                .Where(c => c.Cargo.Type == filter && c.Tires.Any(t => t.TirePressure < 1))
                .ToList();
            }
            else
            {
                filtredCars = cars
                .Where(c => c.Cargo.Type == filter && c.Engine.Power > 250)
                .ToList();
            }


            foreach (var filtredCar in filtredCars)
            {
                Console.WriteLine(filtredCar.Model);
            }

        }
    }
}

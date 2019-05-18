using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _07.SpeedRacing
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
                Car car = new Car(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]));
                cars.Add(car);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split();

                if (tokens[0] == "Drive")
                {
                    string carModel = tokens[1];
                    int amountOfKm = int.Parse(tokens[2]);

                    var driveCar = cars.Where(c => c.Model == carModel).FirstOrDefault();

                    try
                    {
                        driveCar.Drive(amountOfKm);
                    }
                    catch (ArgumentException message)
                    {
                        Console.WriteLine(message.Message);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f02} {car.DistanceTraveled}");
            }
        }
    }
}

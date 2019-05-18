using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.CarSalesman
{
    class StartUp
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                Engine newEngine = new Engine(engineInfo[0], int.Parse(engineInfo[1]));
                
                if (engineInfo.Length == 3)
                {
                    int displacement;

                    if (int.TryParse(engineInfo[2], out displacement))
                    {
                        newEngine.Displacement = engineInfo[2];
                    }
                    else
                    {
                        newEngine.Efficiency = engineInfo[2];
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    newEngine = new Engine(engineInfo[0], int.Parse(engineInfo[1]),
                        engineInfo[2], engineInfo[3]);
                }

                engines.Add(newEngine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                //“<Model> <Engine> <Weight> <Color>
                string[] carInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInfo[0];
                Engine engine = engines.Where(c => c.Model == carInfo[1]).FirstOrDefault();
                Car newCar = new Car(carModel, engine);

                if (carInfo.Length == 3)
                {
                    int weight;

                    if (int.TryParse(carInfo[2],out weight))
                    {
                        newCar.Weight = carInfo[2];
                    }
                    else
                    {
                        newCar.Color = carInfo[2];
                    }
                }
                else if (carInfo.Length == 4)
                {
                    newCar.Weight = carInfo[2];
                    newCar.Color = carInfo[3];
                }

                cars.Add(newCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = inputData[0];
                int power = int.Parse(inputData[1]);

                Engine engine = new Engine(model, power);

                if (inputData.Length == 3)
                {
                    int displacement = 0;

                    if (int.TryParse(inputData[2], out displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = inputData[2];
                        engine.Efficiency = efficiency;
                    }
                }
                else if (inputData.Length == 4)
                {
                    int displacement = 0;

                    if (int.TryParse(inputData[2], out displacement))
                    {
                        engine.Displacement = displacement;
                        string efficiency = inputData[3];
                        engine.Efficiency = efficiency;
                    }
                    else
                    {
                        string efficiency = inputData[2];
                        engine.Efficiency = efficiency;
                    }
                }

                engines.Add(engine);
            }


            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] inputData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string model = inputData[0];
                string engineModel = inputData[1];
                Engine engine = engines.Where(e => e.Model == engineModel).FirstOrDefault();

                Car newCar = new Car(model, engine);

                if (inputData.Length == 3)
                {
                    int weight = 0;

                    if (int.TryParse(inputData[2], out weight))
                    {
                        newCar.Weight = weight;
                    }
                    else
                    {
                        string color = inputData[2];
                        newCar.Color = color;
                    }
                }
                else if (inputData.Length == 4)
                {
                    int weight = 0;

                    if (int.TryParse(inputData[2], out weight))
                    {
                        newCar.Weight = weight;
                        string color = inputData[3];
                        newCar.Color = color;
                    }
                    else
                    {
                        string color = inputData[2];
                        newCar.Color = color;
                    }
                }

                cars.Add(newCar);
            }


            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

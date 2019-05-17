using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Engine
    {
        private int engineSpeed;
        private int enginePower;

        public Engine(int engineSpeed, int enginePower )
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }

        public int EngineSpeed => this.engineSpeed;
        public int EnginePower => this.enginePower;
    }

    class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }

        public int CargoWeight => this.cargoWeight;
        public string CargoType => this.cargoType;
    }

    class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;

        public Car(
            string model,
            int engineSpeed,
            int enginePower,
            int cargoWeight,
            string cargoType
            )
        {
            this.model = model;
            this.engine = new Engine(engineSpeed, enginePower);
            this.cargo = new Cargo(cargoWeight, cargoType);
        }

        public string Model => this.model;
        public Engine Engine => this.engine;
        public Cargo Cargo => this.cargo;
    }

    class RawData
    {
        static void Main()
        {
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

                Car newCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);

                cars.Add(newCar);
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.CargoType == type && c.Cargo.CargoWeight < 1000).ToList())
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (type == "flamable")
            {
                foreach (var car in cars.Where(c => c.Cargo.CargoType == type && c.Engine.EnginePower > 250).ToList())
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}

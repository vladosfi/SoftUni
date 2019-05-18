using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public double CubicCapacity { get => cubicCapacity; set => cubicCapacity = value; }

        public int HorsePower { get => horsePower; set => horsePower = value; }
    }

    public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public double Pressure { get => pressure; set => pressure = value; }

        public int Year { get => year; set => year = value; }
    }

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantiyt, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantiyt;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantiyt, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantiyt, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get => make; set => make = value; }

        public string Model { get => model; set => model = value; }

        public int Year { get => year; set => year = value; }

        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }

        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }

        public Engine Engine { get => engine; set => engine = value; }

        public Tire[] Tires { get => tires; set => tires = value; }

        public void Drive(double distance)
        {
            var canContinue = this.FuelQuantity - distance * this.FuelConsumption / 100 >= 0;

            if (canContinue)
            {
                this.FuelQuantity -= distance * this.FuelConsumption / 100;
            }
            else
            {
                throw new ArgumentException("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L";
        }
    }

    public class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                string[] tokens = input.Split();
                double pressure = double.Parse(tokens[1]);

                Tire[] tire = new Tire[4]
                {
                    new Tire(int.Parse(tokens[0]),double.Parse(tokens[1])),
                    new Tire(int.Parse(tokens[2]),double.Parse(tokens[3])),
                    new Tire(int.Parse(tokens[4]),double.Parse(tokens[5])),
                    new Tire(int.Parse(tokens[6]),double.Parse(tokens[7]))
                };

                tires.Add(tire);
                
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Engines done")
            {
                string[] tokens = input.Split();
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Show special")
            {
                string[] tokens = input.Split();

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);

                input = Console.ReadLine();
            }


            foreach (var car in cars.Where(x => x.Year >= 2017
            && x.Engine.HorsePower > 330 
            && x.Tires.Select(t => t.Pressure).Sum() > 9
            && x.Tires.Select(t => t.Pressure).Sum() < 10))
            {
                try
                {
                    car.Drive(20);
                }
                catch (ArgumentException message)
                {
                    Console.WriteLine(message);
                }

                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}

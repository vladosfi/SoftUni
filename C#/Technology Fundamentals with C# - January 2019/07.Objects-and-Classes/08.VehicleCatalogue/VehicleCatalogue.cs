namespace VehicleCatalogue3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Truck
    {
        private string brand;
        private string model;
        private int weight;

        public Truck(string brand, string model, int weight)
        {
            this.brand = brand;
            this.model = model;
            this.weight = weight;
        }

        public string Brand => this.brand; 

        public string Model => this.model; 

        public int Weight => this.weight; 
    }

    class Car
    {
        private string brand;
        private string model;
        private int horsePawer;

        public Car(string brand, string model, int horsePawer)
        {
            this.brand = brand;
            this.model = model;
            this.horsePawer = horsePawer;
        }

        public string Brand => this.brand; 

        public string Model => this.model;

        public int HorsePawer => this.horsePawer; 
    }

    class Catalog
    {
        private List<Truck> trucks;
        private List<Car> cars;

        public Catalog()
        {
            trucks = new List<Truck>();
            cars = new List<Car>();
        }

        public List<Truck> Trucks => this.trucks; 

        public List<Car> Cars => this.cars; 
    }

    class Program
    {
        static void Main()
        {
            Catalog catalog = new Catalog();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                if (input.Split("/")[0] == "Car")
                {
                    catalog.Cars.Add(
                        new Car(
                            input.Split("/")[1]
                            , input.Split("/")[2]
                            , int.Parse(input.Split("/")[3])
                            ));
                }
                else
                {
                    catalog.Trucks.Add(
                        new Truck(
                            input.Split("/")[1]
                            , input.Split("/")[2]
                            , int.Parse(input.Split("/")[3])
                            ));
                }
            }

            
            if (catalog.Cars.Any())
            {
                Console.WriteLine("Cars:");
                foreach (var vehicleSpec in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{vehicleSpec.Brand}: {vehicleSpec.Model} - {vehicleSpec.HorsePawer}hp");
                }
            }

            if (catalog.Trucks.Any())
            {
                Console.WriteLine("Trucks:");
                foreach (var vehicleSpec in catalog.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{vehicleSpec.Brand}: {vehicleSpec.Model} - {vehicleSpec.Weight}kg");
                }
            }
            
            
        }
    }
}
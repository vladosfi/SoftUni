namespace CarDealer
{
    using System;
    using System.IO;
    using Newtonsoft.Json;

    using CarDealer.Data;
    using CarDealer.Models;
    using System.Linq;
    using CarDealer.DTO;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //var usersJson = File.ReadAllText("./../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, usersJson));

            //var usersJson = File.ReadAllText("./../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, usersJson));

            //var usersJson = File.ReadAllText("./../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, usersJson));

            var usersJson = File.ReadAllText("./../../../Datasets/customers.json");
            Console.WriteLine(ImportCustomers(context, usersJson));
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            return $"Successfully imported {Customers.Count}.";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson).ToList();

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };

                    carParts.Add(carPart);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson).ToArray();

            context.AddRange(suppliers);
            context.SaveChanges();


            return $"Successfully imported {suppliers.Length}.";
        }
    }
}
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
    using System.Globalization;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var context = new CarDealerContext();

            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //var suppliersJson = File.ReadAllText("./../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, suppliersJson));

            //var partsJson = File.ReadAllText("./../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, partsJson));

            //var carsJson = File.ReadAllText("./../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, carsJson));

            //var usersJson = File.ReadAllText("./../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, usersJson));

            //var salesJson = File.ReadAllText("./../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, salesJson));

            //Console.WriteLine(GetOrderedCustomers(context));
            //Console.WriteLine(GetCarsFromMakeToyota(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        //19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Take(10)
                .ProjectTo<SalseDto>()
                .ToList();

            var jsonSales = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return jsonSales;
        }

        //18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //var customers = context
            //    .Customers
            //    .Where(c => c.Sales.Count > 0)
            //    .Select(c => new SalesByCustomerDto
            //    {
            //        FullName = c.Name,
            //        BoughtCars = c.Sales.Count(),
            //        SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
            //    })
            //    .OrderByDescending(c => c.SpentMoney)
            //    .ThenByDescending(c => c.BoughtCars)
            //    .ToList();

            var customers = context
            .Customers
            .Where(c => c.Sales.Count > 0)
            .ProjectTo<SalesByCustomerDto>()
            .OrderByDescending(c => c.SpentMoney)
            .ThenByDescending(c => c.BoughtCars)
            .ToList();

            var jsonCustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);

             return jsonCustomers;
        }


        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .ProjectTo<CarDto>()
                .ToArray();

            var jsonCarParts = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return jsonCarParts;
        }

        //Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var filtredSuppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s=>new FilteredSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var jsonSuppliers = JsonConvert.SerializeObject(filtredSuppliers, Formatting.Indented);

            return jsonSuppliers;
        }

        //Query 15. Export Cars from make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make.ToLower() == "toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c=>new OrderedToyotaCarsDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var orderedCars = JsonConvert.SerializeObject(cars, Formatting.Indented);


            return orderedCars;
        }

        //Query 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var costumers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new OrderedCostumerDto
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(costumers, Formatting.Indented);

            return json;
        }
        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson).ToList();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson).ToList();

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
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
namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<CarDealerProfile>());

            using (var context = new CarDealerContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //var xmlSuppliers = File.ReadAllText(@".\..\..\..\Datasets\suppliers.xml");
                //Console.WriteLine(ImportSuppliers(context, xmlSuppliers));

                //var xmlParts = File.ReadAllText(@".\..\..\..\Datasets\parts.xml");
                //Console.WriteLine(ImportParts(context, xmlParts));

                //var xmlCars = File.ReadAllText(@".\..\..\..\Datasets\cars.xml");
                //Console.WriteLine(ImportCars(context, xmlCars));

                //var xmlCustomers = File.ReadAllText(@".\..\..\..\Datasets\customers.xml");
                //Console.WriteLine(ImportCustomers(context, xmlCustomers));

                var xmlSales = File.ReadAllText(@".\..\..\..\Datasets\sales.xml");
                Console.WriteLine(ImportSales(context, xmlSales));
            }
        }
        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSalesDto[]), new XmlRootAttribute("Sales"));

            var salesDtos = (ImportSalesDto[])serializer.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            var existingCarIds = context.Cars.Select(c => c.Id).ToHashSet();

            foreach (var saleDto in salesDtos)
            {
                if (existingCarIds.Contains(saleDto.CarId))
                {
                    var sale = Mapper.Map<Sale>(saleDto);
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomersDto[]), new XmlRootAttribute("Customers"));

            var customersDtos = (ImportCustomersDto[])serializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDtos)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarsDto[]), new XmlRootAttribute("Cars"));

            var CarDtos = (ImportCarsDto[])serializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            var existingParts = context.Parts.Select(p => p.Id).ToHashSet();

            foreach (var CarDto in CarDtos)
            {
                var car = new Car()
                {
                    Make = CarDto.Make,
                    Model = CarDto.Model,
                    TravelledDistance = CarDto.TraveledDistance
                };

                var validPartIds = CarDto.Parts.Where(p => existingParts.Contains(p.PartId)).Select(p => p.PartId).ToHashSet();

                foreach (var partId in validPartIds)
                {
                    var partCar = new PartCar()
                    {
                        PartId = partId,
                        Car = car
                    };

                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();


            return $"Successfully imported {cars.Count}";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var suppliersId = context.Suppliers.Select(s => s.Id).ToHashSet();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartsDto[]), new XmlRootAttribute("Parts"));

            var partDtos = (ImportPartsDto[])serializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            foreach (var partDto in partDtos)
            {
                if (suppliersId.Contains(partDto.SupplierId))
                {
                    var part = Mapper.Map<Part>(partDto);
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();


            return $"Successfully imported {parts.Count}";
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSuppliersDto[]), new XmlRootAttribute("Suppliers"));

            var supplierDtos = (ImportSuppliersDto[])serializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in supplierDtos)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}
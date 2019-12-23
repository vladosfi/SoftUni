
namespace PetStore.Services.Implementations
{
    using System;
    using System.Collections.Generic;

    using PetStore.Data;
    using PetStore.Services.Models.Brand;
    using PetStore.Data.Models;
    using System.Linq;
    using PetStore.Services.Models.Toy;

    public class BrandService : IBrandServices
    {
        private readonly PetStoreDbContext data;


        public BrandService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public int Create(string name)
        {
            if (name.Length > DataValidation.NameMaxLenght)
            {
                throw new InvalidOperationException($"Brand name cannot be more than {DataValidation.NameMaxLenght}");
            }

            if (this.data.Brands.Any(br => br.Name.ToLower() == name))
            {
                throw new InvalidOperationException($"Brand name {name} already exists.");
            }

            var brand = new Brand
            {
                Name = name
            };

            this.data.Brands.Add(brand);
            this.data.SaveChanges();

            return brand.Id;
        }

        public BrandWithToysServiceModel FindByIdWithToys(int id)
            => this.data
                .Brands
            .Where(br => br.Id == id)
            .Select(br => new BrandWithToysServiceModel
            {
                Name = br.Name,
                Toys = br.Toys.Select(t => new ToyListingServiceModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price,
                    TotalOrders = t.Orders.Count()
                })
                .ToList()
            })
            .FirstOrDefault();


        public IEnumerable<BrandListingServiceModel> SearchByName(string name)
            => this.data
                    .Brands
                    .Where(br => br.Name.ToLower().Contains(name.ToLower()))
                    .Select(br => new BrandListingServiceModel
                    {
                        Id = br.Id,
                        Name = br.Name
                    })
                    .ToList();

    }
}

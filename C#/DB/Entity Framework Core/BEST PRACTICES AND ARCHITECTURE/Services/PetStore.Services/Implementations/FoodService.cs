
namespace PetStore.Services.Implementations
{
    using System;
    using System.Linq;
    using Data.Models;
    using PetStore.Data;
    using Services.Models.Food;

    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext data;

        public FoodService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expirationDate, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space!");
            }

            //Proofit shoud be in range 0-500%
            if (profit < 0 || profit > 5)
            {
                throw new ArgumentException("Proofit must be higher tna zero and lower than 500%");
            }

            var food = new Food
            {
                Name = name,
                Weight = weight,
                DistributorPrice = price,
                Price = price + (price * (decimal)profit),
                ExpirationDate = expirationDate,
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Foods.Add(food);
            this.data.SaveChanges();
        }

        public void BuyFromDistributor(AddingFoodServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Name cannot be null or white space!");
            }

            //Proofit shoud be in range 0-500%
            if (model.Profit < 0 || model.Profit > 5)
            {
                throw new ArgumentException("Proofit must be higher tna zero and lower than 500%");
            }

            var food = new Food
            {
                Name = model.Name,
                Weight = model.Weight,
                DistributorPrice = model.Price,
                Price = model.Price + (model.Price * (decimal)model.Profit),
                ExpirationDate = model.ExpirationDate,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            this.data.Foods.Add(food);
            this.data.SaveChanges();
        }
    }
}

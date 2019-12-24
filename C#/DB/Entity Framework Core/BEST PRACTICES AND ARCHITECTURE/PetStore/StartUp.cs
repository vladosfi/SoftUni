
namespace PetStore
{
    using PetStore.Data;
    using PetStore.Services.Implementations;
    using System;

    public class StartUp
    {
        static void Main()
        {
            using var data = new PetStoreDbContext();

            var brandService = new BrandService(data);

            brandService.Create("Cat Food");

            //brandService.FindByIdWithToys(1);

            var foodService = new FoodService(data);

            foodService.BuyFromDistributor("Cat Food", 0.350, 1.1m, 0.3, DateTime.Now, 1, 1);
        }
    }
}

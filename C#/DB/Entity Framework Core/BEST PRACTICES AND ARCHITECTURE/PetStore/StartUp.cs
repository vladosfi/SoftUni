
namespace PetStore
{
    using PetStore.Data;
    using PetStore.Data.Models.Enums;
    using PetStore.Services.Implementations;
    using System;

    public class StartUp
    {
        static void Main()
        {
            using var data = new PetStoreDbContext();

            //var brandService = new BrandService(data);

            //brandService.Create("Cat Food");

            //brandService.FindByIdWithToys(1);

            //var foodService = new FoodService(data);

            //foodService.BuyFromDistributor("Cat Food", 0.350, 1.1m, 0.3, DateTime.Now, 1, 1);

            //var toyService = new ToyService(data);

            //toyService.BuyFromDistributor("Ball", null, 3.5m, 1.1, 1, 1);

            //var userService = new UserService(data);
            //var foodService = new FoodService(data, userService);

            //userService.Register("Pesho", "pesho@abv.bg");

            //foodService.SellFoodToUser(1, 1);

            //var userService = new UserService(data);
            //var toyService = new ToyService(data, userService);
            //toyService.SellToyToUser(1, 1);

            //var breedService = new BreedService(data);
            //breedService.Add("Persian");

            //var breedService = new BreedService(data);
            //var categoryService = new CategoryService(data);
            //var userService = new UserService(data);
            //var petService = new PetService(data, breedService, categoryService, userService);
            //petService.BuyPet(Gender.Male, DateTime.Now, 40, "Cute cat", 1, 1);
            //petService.SellPet(2, 1);
        }
    }
}

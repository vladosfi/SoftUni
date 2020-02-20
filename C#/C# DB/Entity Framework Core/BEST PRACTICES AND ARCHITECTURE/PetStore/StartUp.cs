
namespace PetStore
{
    using PetStore.Data;
    using PetStore.Data.Models;
    using PetStore.Data.Models.Enums;
    using PetStore.Services.Implementations;
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            using var data = new PetStoreDbContext();
            //Add Breed
            for (int i = 0; i < 10; i++)
            {
                var breed = new Breed
                {
                    Name = "Breed " + i
                };

                data.Breeds.Add(breed);
            }

            data.SaveChanges();

            //Add Category
            for (int i = 0; i < 30; i++)
            {
                var category = new Category
                {
                    Name = "Category " + i,
                    Description = "Category Description" + i
                };

                data.Categories.Add(category);
            }

            data.SaveChanges();



            //Add pets
            for (int i = 0; i < 100; i++)
            {
                //Get random id from database
                var categoryId = data
                    .Categories
                    .OrderBy(c => Guid.NewGuid())
                    .Select(c=>c.Id)
                    .FirstOrDefault();

                //Get random id from database
                var breedId = data
                    .Breeds
                    .OrderBy(c => Guid.NewGuid())
                    .Select(c => c.Id)
                    .FirstOrDefault();

                var pet = new Pet
                {
                    DateOfBirth = DateTime.Now.AddDays(-60),
                    Price = 50 + i,
                    Gender = (Gender)(i % 2),
                    Description = $"Some randoom description {i}",
                    CategoryId = categoryId,
                    BreedId = breedId
                };

                data.Pets.Add(pet);
            }

            data.SaveChanges();

            

            //var brandService = new BrandService(data);

            //brandService.Create("Cat Food");

            //brandService.FindByIdWithToys(1);

            
            var userService = new UserService(data);
            var foodService = new FoodService(data, userService);
            //foodService.BuyFromDistributor("Dog Food", 0.350, 1.1m, 0.3, DateTime.Now, 1, 1);
            
            //userService.Register("Pesho", "pesho@abv.bg");

            //foodService.SellFoodToUser(1, 1);
            //var toyService = new ToyService(data, userService);
            //toyService.BuyFromDistributor("Ball", null, 3.5m, 1.1, 1, 1);
            //toyService.SellToyToUser(1, 1);



            //var breedService = new BreedService(data);
            //breedService.Add("Persian");
            //var categoryService = new CategoryService(data);

            //var petService = new PetService(data, breedService, categoryService, userService);
            //petService.BuyPet(Gender.Male, DateTime.Now, 40, "Cute cat", 1, 1);
            //petService.SellPet(2, 1);
        }
    }
}

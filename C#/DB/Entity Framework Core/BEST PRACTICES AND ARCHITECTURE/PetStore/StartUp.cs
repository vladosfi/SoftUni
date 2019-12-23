
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

            //brandService.Create("TestBrand");

            brandService.FindByIdWithToys(1);
        }
    }
}

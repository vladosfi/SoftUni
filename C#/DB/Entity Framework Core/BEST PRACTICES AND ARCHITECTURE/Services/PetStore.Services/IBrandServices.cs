﻿
namespace PetStore.Services
{
    using System.Collections.Generic;
    using Models.Brand;

    public interface IBrandServices
    {
        int Create(string name);

        IEnumerable<BrandListingServiceModel> SearchByName(string name);

        BrandWithToysServiceModel FindByIdWithToys(int id);


    }
}

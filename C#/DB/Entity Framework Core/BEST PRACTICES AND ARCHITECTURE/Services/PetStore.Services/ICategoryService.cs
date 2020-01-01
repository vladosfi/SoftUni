namespace PetStore.Services
{
    using System.Collections.Generic;
    using Services.Models.Category;

    public interface ICategoryService
    {
        bool Exists(int categoryId);

        IEnumerable<AllCategoriesServiceModel> All();

        void Create(CreateCategoryServicesModel model);

        DetailsCategoryServiceModel GetById(int id);

        void Edit(EditCategoryServiceModel model);
    }
}

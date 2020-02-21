using Andreys.Models;
using Andreys.ViewModels.Products;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductsService
    {
        void Add(string name, string description, string imageUrl, decimal price, Category category, Gender gender);

        IEnumerable<ProductsViewModel> GetAll();

        DetailsViewModel Details(int id);
        void Delete(int id);
    }
}

using Andreys.Data;
using Andreys.Models;
using Andreys.ViewModels.Products;
using System.Collections.Generic;
using System.Linq;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, string description, string imageUrl, decimal price, Category category, Gender gender)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Price = price,
                Category = category,
                Gender = gender,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }


        public DetailsViewModel Details(int id)
        {
            return this.db
                .Products
                .Where(x => x.Id == id)
                .Select(x=> new DetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Category = x.Category.ToString(),
                    Gender = x.Gender.ToString(),
                })
                .FirstOrDefault();
        }

        public IEnumerable<ProductsViewModel> GetAll()
        {
            return this.db.Products
                .Select(x => new ProductsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var productToDelete = this.db.Products.Find(id);

            if (productToDelete != null)
            {
                this.db.Products.Remove(productToDelete);
                this.db.SaveChanges();
            }
        }
    }
}

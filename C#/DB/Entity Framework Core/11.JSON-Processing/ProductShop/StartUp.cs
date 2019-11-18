namespace ProductShop
{
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Models;
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //var usersJson = File.ReadAllText("./../../../Datasets/users.json");
            //Console.WriteLine(usersJson);
            //var results = ImportUsers(context, usersJson);

            //var productsJson = File.ReadAllText("./../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, productsJson));

            //var categoriesJson = File.ReadAllText("./../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, categoriesJson));


            var categoriesProductsJson = File.ReadAllText("./../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJson));
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)
                .ToArray();

            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null && c.Name.Trim().Length >= 3 && c.Name.Trim().Length <= 15)
                .ToArray();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //Query 2.Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(p => p.Name.Trim().Length >= 3)
                .ToArray();

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length >= 3)
                .ToArray();


            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}"; ;
        }
    }
}
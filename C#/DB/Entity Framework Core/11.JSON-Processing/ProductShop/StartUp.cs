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
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            //var usersJson = File.ReadAllText("./../../../Datasets/users.json");
            //Console.WriteLine(usersJson);
            //var results = ImportUsers(context, usersJson);

            var productsJson = File.ReadAllText("./../../../Datasets/products.json");
            Console.WriteLine(ImportProducts(context, productsJson));
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
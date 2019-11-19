namespace ProductShop
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
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


            //var categoriesProductsJson = File.ReadAllText("./../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJson));

            //Console.WriteLine(GetProductsInRange(context));
            Console.WriteLine(GetSoldProducts(context));
        }

        //Query 6. Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var filteredUsers = context
                .Users
                .Where(u=>u.ProductsSold.Any(ps => ps.Buyer!= null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => 
                    new 
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        SoldProducts = u.ProductsSold
                            .Select(ps => new 
                            {
                                Name = ps.Name,
                                Price = ps.Price,
                                BuyerFirstName = ps.Buyer.FirstName,
                                BuyerLastName = ps.Buyer.LastName,
                            })
                          .ToArray()  
                    })
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(filteredUsers, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return json;
        }

        //Query 5. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();


            var json = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return string.Join(Environment.NewLine, json);

        }


        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var validProdictId = new HashSet<int>
            (
                context
                .CategoryProducts
                .Select(p => p.ProductId));

            var validCategoryId = new HashSet<int>
            (
                context
                .CategoryProducts
                .Select(p => p.CategoryId));

            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)
                .Distinct()
                .ToArray();

            var validCategoriesProducts = new List<CategoryProduct>();

            foreach (var categoryProduct in categoriesProducts)
            {
                var isValid = validProdictId.Contains(categoryProduct.ProductId) &&
                                validCategoryId.Contains(categoryProduct.CategoryId);

                if (isValid)
                {
                    validCategoriesProducts.Add(categoryProduct);
                }
            }


            context.AddRange(validCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoriesProducts.Count}";
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
namespace P03_SalesDatabase
{
    using System.Collections.Generic;
    using Data;
    using P03_SalesDatabase.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            using(var db = new SalesContext())
            {
                var productsToAdd = GetProductsToSeed();

                db.Products.AddRange(productsToAdd);

                db.SaveChanges();
            }
        }

        private static List<Product> GetProductsToSeed()
        {
            List<Product> products = new List<Product>();

            Product product1 = new Product
            {
                Name = "Lemon",
                Quantity = 10,
                Price = 2.50m
            };

            Product product2 = new Product
            {
                Name = "Tomatoes",
                Quantity = 20,
                Price = 4.50m
            };

            Product product3 = new Product
            {
                Name = "Aple",
                Quantity = 15,
                Price = 1.50m
            };

            products.Add(product1);

            products.Add(product2);

            products.Add(product3);

            return products;
        }
    }
}
